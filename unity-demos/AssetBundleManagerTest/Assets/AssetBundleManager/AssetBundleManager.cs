using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace AssetBundles
{
    //加载的资源包包含可用于自动卸载依赖资源包的引用计数
    [System.Serializable]
    public class LoadedAssetBundle
    {
        public string name;
        public AssetBundle m_AssetBundle;
        public int m_ReferencedCount;

        public LoadedAssetBundle(AssetBundle assetBundle)
        {
            name = assetBundle.name;
            m_AssetBundle = assetBundle;
            m_ReferencedCount = 1;

            if (string.IsNullOrEmpty(name))
                name = Utility.GetPlatformName();
        }

        public LoadedAssetBundle(AssetBundle assetBundle, int referencedCount)
        {
            name = assetBundle.name;
            m_AssetBundle = assetBundle;
            m_ReferencedCount = referencedCount;
        }
    }

    // 自动加载assetBundle及其依赖项，自动加载变量
    public class AssetBundleManager : MonoBehaviour
    {
        public enum LogMode { All, JustErrors };
        public enum LogType { Info, Warning, Error };
        public enum LoadMode { Internal, Local, Remote, LocalFirst, RemoteFirst }; //内部（streamingAssetsPath），本地，远程

        static AssetBundleManifest m_AssetBundleManifest = null;

#if UNITY_EDITOR
        static int m_SimulateAssetBundleInEditor = -1;
        const string kSimulateAssetBundles = "SimulateAssetBundles";
        static List<string> m_SimulateAssetBundleList = new List<string>();
#endif

#if ODIN_INSPECTOR
        [SerializeField]
        private bool showOdinInfo;
#endif

#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        static Dictionary<string, LoadedAssetBundle> m_LoadedAssetBundles = new Dictionary<string, LoadedAssetBundle>();  //以加载的bundle
        static Dictionary<string, UnityWebRequestAsyncOperation> m_UnityWebRequests = new Dictionary<string, UnityWebRequestAsyncOperation>();  //网络加载
        static Dictionary<string, AssetBundleCreateRequest> m_CreatingAssetBundles = new Dictionary<string, AssetBundleCreateRequest>(); //正要加载的bundle

#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        static Dictionary<string, string> m_DownloadingErrors = new Dictionary<string, string>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        //在进行操作中的
        static List<AssetBundleLoadOperation> m_InProgressOperations = new List<AssetBundleLoadOperation>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        static Dictionary<string, string[]> m_Dependencies = new Dictionary<string, string[]>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        //本地加载 加载的引用
        static Dictionary<string, int> m_LocalLoadingReferenceCount = new Dictionary<string, int>(); 
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        //远程加载的资源
        static Dictionary<string, int> m_RemoteLoadingReferencedCount = new Dictionary<string, int>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        static Dictionary<string, List<string>> m_AllAssetBundlesWithVariant = new Dictionary<string, List<string>>();

#if UNITY_EDITOR
#if ODIN_INSPECTOR
        [ShowInInspector, HideIf("showOdinInfo"), ListDrawerSettings(IsReadOnly = true)]
#endif
        public List<LoadedAssetBundle> allLoaded = new List<LoadedAssetBundle>();
        private static bool isDirty;
#endif

        public static LoadMode loadMode { get; set; } = LoadMode.Local;

        public static LogMode logMode { get; set; } = LogMode.All;

        // 下载路径
        public static string BaseDownloadingURL { get; set; } = "";

        //本地路径
        public static string BaseLocalURL { get; set; } = "";

        // bundle变体的列表
        public static string[] ActiveVariants { get; set; } = { };

        // AssetBundleManifest对象，用于加载依赖关系并检查合适的assetBundle变体
        public static AssetBundleManifest AssetBundleManifestObject
        {
            get { return m_AssetBundleManifest; }
            set
            {
                if (m_AssetBundleManifest != null)
                    UnloadAssetBundle(Utility.GetPlatformName());

                m_AssetBundleManifest = value;

                string[] bundlesWithVariant = m_AssetBundleManifest.GetAllAssetBundlesWithVariant();

                InitAllAssetBundleWithVariants(bundlesWithVariant);
            }
        }

        private static void Log(LogType logType, string text)
        {
            if (logType == LogType.Error)
                Debug.LogError("[AssetBundleManager] " + text);
            else if (logMode == LogMode.All)
                Debug.Log("[AssetBundleManager] " + text);
        }

#if UNITY_EDITOR
        // 是否要在Editor中模拟assetBundle，但不是实际构建
        public static bool SimulateAssetBundleInEditor
        {
            get
            {
                if (m_SimulateAssetBundleInEditor == -1)
                    m_SimulateAssetBundleInEditor = EditorPrefs.GetBool(kSimulateAssetBundles, true) ? 1 : 0;

                return m_SimulateAssetBundleInEditor != 0;
            }
            set
            {
                int newValue = value ? 1 : 0;
                if (newValue != m_SimulateAssetBundleInEditor)
                {
                    m_SimulateAssetBundleInEditor = newValue;
                    EditorPrefs.SetBool(kSimulateAssetBundles, value);
                }
            }
        }

        private static void InitSimulateManifest()
        {
            string[] bundlesWithVariant = AssetDatabase.GetAllAssetBundleNames();
        }
#endif
        
        //设置BaseLocalURL 如果是空就从persistentDataPath中加载
        public static void SetLocalAssetBundleDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
                BaseLocalURL = Application.persistentDataPath;
            else
                BaseLocalURL = path;

            Log(LogType.Info, "SetLocalAssetBundleDirectory: " + BaseLocalURL);
        }

        public static void SetRemoteAssetBundleURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                SetDevelopmentAssetBundleServer();
            else
                BaseDownloadingURL = url;

            Log(LogType.Info, "SetRemoteAssetBundleURL: " + BaseDownloadingURL);
        }

        public static void SetSourceAssetBundleURL(string absolutePath)
        {
            BaseDownloadingURL = absolutePath;
        }

        public static void SetDevelopmentAssetBundleServer()
        {
#if UNITY_EDITOR
            // 如果处于编辑器模拟模式，则不必设置下载URL
            if (SimulateAssetBundleInEditor)
                return;
#endif

            TextAsset urlFile = Resources.Load("AssetBundleServerURL") as TextAsset;
            string url = urlFile?.text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                if (loadMode != LoadMode.Local && loadMode != LoadMode.Internal)
                    Log(LogType.Error, "Development Server URL could not be found.");
            }
            else
            {
                SetSourceAssetBundleURL(url);
            }
        }

        /// <summary>
        /// 清单中是否包含资产
        /// </summary>
        /// <returns><c>true</c>, if asset bundle asset was hased, <c>false</c> otherwise.</returns>
        /// <param name="assetBundle">Asset bundle name with variant.</param>
        public static bool HasAssetInternal(string assetBundle)
        {
            return m_AllAssetBundlesWithVariant.ContainsKey(assetBundle);
        }

        /// <summary>
        /// bundle是否存在本地
        /// </summary>
        /// <returns><c>true</c>, if asset in local was hased, <c>false</c> otherwise.</returns>
        /// <param name="assetBundle">Asset bundle.</param>
        public static bool HasAssetInLocal(string assetBundle, bool useSimulatePath = false)
        {
#if UNITY_EDITOR
            if (useSimulatePath && SimulateAssetBundleInEditor)
            {
                assetBundle = assetBundle.Replace(Path.GetFileName(assetBundle), Path.GetFileNameWithoutExtension(assetBundle));
                return HasAssetInternal(assetBundle);
            }
#endif
            string fullPath = Path.Combine(BaseLocalURL, assetBundle);
            if (File.Exists(fullPath))
                return true;

            return false;
        }

        public static List<string> GetAllAssetBundleNames()
        {
            List<string> list = new List<string>();
            list.AddRange(m_AllAssetBundlesWithVariant.Keys);
            return list;
        }

#if UNITY_EDITOR
        public static bool GetLoadedSimulateAssetBundle(string assetBundleName)
        {
            if (m_SimulateAssetBundleList.Contains(assetBundleName))
                return true;
            else
                return false;
        }
#endif

        // 加载AssetBundle，仅当所有依赖项下载成功时返回对象。
        internal static LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName, out string error)
        {
            if (m_DownloadingErrors.TryGetValue(assetBundleName, out error))
                return null;

            m_LoadedAssetBundles.TryGetValue(assetBundleName, out LoadedAssetBundle bundle);
            if (bundle == null)
                return null;

            // 不记录任何依赖项，只需要绑定包本身
            if (!m_Dependencies.TryGetValue(assetBundleName, out string[] dependencies))
                return bundle;

            // 确保所有依赖项都已加载
            foreach (var dependency in dependencies)
            {
                if (m_DownloadingErrors.TryGetValue(dependency, out error))
                    return bundle;

                // 检查所有的依赖包都已经加载完毕。
                m_LoadedAssetBundles.TryGetValue(dependency, out LoadedAssetBundle dependentBundle);
                if (dependentBundle == null)
                    return null;
            }

            return bundle;
        }

        public static AssetBundleLoadManifestOperation Initialize()
        {
            return Initialize(Utility.GetPlatformName());
        }

        public static bool IsInited = false;
        // 加载 AssetBundleManifest.
        public static AssetBundleLoadManifestOperation Initialize(string manifestAssetBundleName)
        {
#if UNITY_EDITOR
            Log(LogType.Info, "Simulation Mode: " + (SimulateAssetBundleInEditor ? "Enabled" : "Disabled"));
#endif

            AssetBundleManager mgr = FindObjectOfType<AssetBundleManager>();
            if (mgr == null)
                mgr = new GameObject("AssetBundleManager").AddComponent<AssetBundleManager>();
            DontDestroyOnLoad(mgr.gameObject);
            IsInited = true;
#if UNITY_EDITOR
            // 编辑器下不需要 manifest assetBundle.
            if (SimulateAssetBundleInEditor)
            {
                InitAllAssetBundleWithVariants(AssetDatabase.GetAllAssetBundleNames());
                return null;
            }
#endif
            
            LoadAssetBundle(manifestAssetBundleName, true);
            //加载mainfest
            var operation = new AssetBundleLoadManifestOperation(manifestAssetBundleName, "AssetBundleManifest", typeof(AssetBundleManifest));
            m_InProgressOperations.Add(operation);
            return operation;
        }

        private static void InitAllAssetBundleWithVariants(string[] bundlesWithVariant)
        {
            m_AllAssetBundlesWithVariant.Clear();
            // 循环所有带有variant的assetBundle，以找到最合适的variant assetBundle
            for (int i = 0; i < bundlesWithVariant.Length; i++)
            {
                string[] curSplit = bundlesWithVariant[i].Split('.');

                if (curSplit.Length > 1)
                {
                    if (m_AllAssetBundlesWithVariant.ContainsKey(curSplit[0]))
                    {
                        m_AllAssetBundlesWithVariant[curSplit[0]].Add(curSplit[1]);
                    }
                    else
                    {
                        m_AllAssetBundlesWithVariant[curSplit[0]] = new List<string> { curSplit[1] };
                    }
                }
                else
                {
                    Log(LogType.Error, bundlesWithVariant[i] + " has no variant name");
                }
            }
        }

        // 加载AssetBundle及其依赖项
        protected static void LoadAssetBundle(string assetBundleName, bool isLoadingAssetBundleManifest = false)
        {
            Log(LogType.Info, "Loading Asset Bundle " + (isLoadingAssetBundleManifest ? "Manifest: " : ": ") + assetBundleName);

#if UNITY_EDITOR
            // 如果处于编辑器模拟模式，不必真正加载assetBundle及其依赖项
            if (SimulateAssetBundleInEditor)
                return;
#endif

            if (!isLoadingAssetBundleManifest)
            {
                if (m_AssetBundleManifest == null)
                {
                    Log(LogType.Error, "Please load assetbundle " + assetBundleName + " after AssetBundleManager.Initialize()");
                    Log(LogType.Error, "Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
                    return;
                }
            }

            // 查看资源包是否已被处理，没加载会加载bundle
            bool isAlreadyProcessed = LoadAssetBundleInternal(assetBundleName, isLoadingAssetBundleManifest, loadMode);

            // 加载依赖关系,如果是加载AssetBundleManifest就不用加载了
            if (!isAlreadyProcessed && !isLoadingAssetBundleManifest)
                LoadDependencies(assetBundleName);
        }

        // 获得变体的名称.
        protected static string RemapVariantName(string assetBundleName)
        {
            string[] split = assetBundleName.Split('.');
            
            if (split.Length == 1)
                 return split[0];
            
            assetBundleName = split[0];

#if UNITY_EDITOR
            if (SimulateAssetBundleInEditor)
            {
                return assetBundleName + "." + ActiveVariants[ActiveVariants.Length - 1];
            }
#endif

            if (m_AllAssetBundlesWithVariant.TryGetValue(assetBundleName, out List<string> variants))
            {
                int bestFit = int.MaxValue;
                int bestFitIndex = -1;
                for (int i = 0; i < variants.Count; ++i)
                {
                    int found = System.Array.IndexOf(ActiveVariants, variants[i]);
                    
                    if (found == -1)
                        found = int.MaxValue - 1;

                    if (found < bestFit)
                    {
                        bestFit = found;
                        bestFitIndex = i;
                    }
                }

                if (bestFit == int.MaxValue - 1)
                {
                    Log(LogType.Warning, "Ambigious asset bundle variant chosen because there was no matching active variant: " + variants[bestFitIndex]);
                }

                return assetBundleName + "." + variants[bestFitIndex];
            }
            else
            {
                return assetBundleName + "." + ActiveVariants[ActiveVariants.Length - 1];
            }

        }

        /// <summary>
        /// 加载bundle : 之前有加载错误 -> bundle是否已加载成功 -> bundle是否正在加载中(本地或网络) -> 加载bundle -> 从 本地/内部 加载 -> 尝试persistentDataPath路径 -> 尝试StreamingDataPath路径
        ///                                                                                              -> 从 远端 加载 ->  使用 UnityWebRequest  
        /// </summary>
        /// <returns><c>true</c> bundle已经被处理 <c>false</c> bundle 未被处理 </returns>
        protected static bool LoadAssetBundleInternal(string assetBundleName, bool isLoadingAssetBundleManifest, LoadMode mode, int refCount = 1)
        {
            // 加载过程产生过错误
            if (m_DownloadingErrors.ContainsKey(assetBundleName))
            {
                return true;
            }
            // 以加载完成的
            if (m_LoadedAssetBundles.TryGetValue(assetBundleName, out LoadedAssetBundle bundle))
            {
                bundle.m_ReferencedCount += refCount;
                return true;
            }
            
            // 理想情况是每次远程加载资源只调用一次 LoadAssetAsync（）/ LoadLevelAsync（）
            // 实际情况下，可能会多次调用LoadAssetAsync（）/ LoadLevelAsync（），然后等待它们完成，这可能会有重复的WWW

            if (m_LocalLoadingReferenceCount.ContainsKey(assetBundleName))
            {
                m_LocalLoadingReferenceCount[assetBundleName] += refCount;
                return true;
            }

            if (m_RemoteLoadingReferencedCount.ContainsKey(assetBundleName))
            {
                m_RemoteLoadingReferencedCount[assetBundleName] += refCount;
                return true;
            }
            
            if (mode == LoadMode.Local || mode == LoadMode.LocalFirst || mode == LoadMode.Internal)
            {
                //添加正在加载资源名称
                m_LocalLoadingReferenceCount.Add(assetBundleName, refCount);

                string url = Path.Combine(BaseLocalURL, assetBundleName); //SetLocalAssetBundleDirectory() 设置BaseLocalURL在Application.persistentDataPath

                if (mode == LoadMode.Internal || !HasAssetInLocal(assetBundleName))  //文件不存BaseLocalURL 从 streamingAssetsPath 中查找
                    url = Path.Combine(Utility.GetStreamingAssetsDirectory(), assetBundleName);

                AssetBundleCreateRequest request = null;

                if (isLoadingAssetBundleManifest)  // 是否加载AssetBundleManifest
                    request = AssetBundle.LoadFromFileAsync(url);
                else
                    request = AssetBundle.LoadFromFileAsync(url, 0); // TODO CRC校验

                request.priority = (int)Application.backgroundLoadingPriority;  //设置加载资源的数据传输，设置为ThreadPriority.High，会加速资源加载，但是会导致帧率下降

                m_CreatingAssetBundles.Add(assetBundleName, request);
            }
            else if (mode == LoadMode.Remote || mode == LoadMode.RemoteFirst)
            {
                m_RemoteLoadingReferencedCount.Add(assetBundleName, refCount);

                string url = Path.Combine(BaseDownloadingURL, assetBundleName);

                //if (isLoadingAssetBundleManifest)
                //    WebRequestManager.Instance.LoadAssetBundle(url, OnRemoteCallback, (int)ThreadPriority.BelowNormal, assetBundleName);
                //else
                //WebRequestManager.Instance.LoadAssetBundle(url, m_AssetBundleManifest.GetAssetBundleHash(assetBundleName), OnRemoteCallback, (int)ThreadPriority.BelowNormal, assetBundleName);

                //网络加载使用 UnityWebRequest ，
                UnityWebRequest download = null;

                //For manifest assetbundle, always download it as we don't have hash for it.
                if (isLoadingAssetBundleManifest)
                    download = UnityWebRequestAssetBundle.GetAssetBundle(url);
                else
                    download = UnityWebRequestAssetBundle.GetAssetBundle(url, m_AssetBundleManifest.GetAssetBundleHash(assetBundleName), 0); // TODO CRC校验

                UnityWebRequestAsyncOperation request = download.SendWebRequest();
                request.priority = (int)Application.backgroundLoadingPriority;

                m_UnityWebRequests.Add(assetBundleName, request);
            }

            return false;
        }

        // 获得依赖，并加载所有资源。
        protected static void LoadDependencies(string assetBundleName)
        {
            if (m_AssetBundleManifest == null)
            {
                Log(LogType.Error, "Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
                return;
            }

            // 从 AssetBundleManifest 获得依赖对象
            string[] dependencies = m_AssetBundleManifest.GetAllDependencies(assetBundleName);
            if (dependencies.Length == 0)
                return;

            for (int i = 0; i < dependencies.Length; i++)
                dependencies[i] = RemapVariantName(dependencies[i]);

            // 记录并加载所有依赖项
            m_Dependencies.Add(assetBundleName, dependencies);
            for (int i = 0; i < dependencies.Length; i++)
                LoadAssetBundleInternal(dependencies[i], false, loadMode);
        }

        // Unload assetbundle and its dependencies.
        public static void UnloadAssetBundle(string assetBundleName)
        {
#if UNITY_EDITOR
            // If we're in Editor simulation mode, we don't have to load the manifest assetBundle.
            if (SimulateAssetBundleInEditor)
            {
                if (m_SimulateAssetBundleList.Contains(assetBundleName))
                    m_SimulateAssetBundleList.Remove(assetBundleName);

                return;
            }
#endif

            //Log(LogType.Info, m_LoadedAssetBundles.Count + " assetbundle(s) in memory before unloading " + assetBundleName);

            UnloadAssetBundleInternal(assetBundleName);
            UnloadDependencies(assetBundleName);

            if (m_DownloadingErrors.ContainsKey(assetBundleName))
                m_DownloadingErrors.Remove(assetBundleName);

            //Log(LogType.Info, m_LoadedAssetBundles.Count + " assetbundle(s) in memory after unloading " + assetBundleName);
        }

        protected static void UnloadDependencies(string assetBundleName)
        {
            if (!m_Dependencies.TryGetValue(assetBundleName, out string[] dependencies))
                return;

            // Loop dependencies.
            foreach (var dependency in dependencies)
            {
                UnloadAssetBundleInternal(dependency);
            }

            m_Dependencies.Remove(assetBundleName);
        }

        protected static void UnloadAssetBundleInternal(string assetBundleName)
        {
            string error;
            LoadedAssetBundle bundle = GetLoadedAssetBundle(assetBundleName, out error);
            if (bundle == null)
                return;

            if (--bundle.m_ReferencedCount == 0)
            {
                bundle.m_AssetBundle.Unload(true);
                m_LoadedAssetBundles.Remove(assetBundleName);

#if UNITY_EDITOR
                isDirty = true;
#endif
            }

            Log(LogType.Info, string.Format(UNLOADSTR, assetBundleName, bundle.m_ReferencedCount));
        }

//        static void OnRemoteCallback(UnityWebRequest request, string err, object userdata)
//        {
//            string key = userdata as string;
//            if (request.isDone)
//            {
//                int refCount = m_RemoteLoadingReferencedCount[key];
//                m_RemoteLoadingReferencedCount.Remove(key);

//                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

//                if (bundle == null)
//                {
//                    if (loadMode == LoadMode.RemoteFirst)
//                    {
//                        Log(LogType.Info, string.Format("No asset in remote {0}, try local {1}: {2}", BaseDownloadingURL, BaseLocalURL, key));
//                        LoadAssetBundleInternal(key, m_AssetBundleManifest == null, LoadMode.Local, refCount);
//                    }
//                    else
//                    {
//                        if (!m_DownloadingErrors.ContainsKey(key))
//                        {
//                            if (request.isNetworkError || request.isHttpError)
//                                m_DownloadingErrors.Add(key, string.Format("Failed downloading bundle {0} from {1}: {2}", key, request.url, err));
//                            else
//                                m_DownloadingErrors.Add(key, string.Format("{0} is not a valid asset bundle.", key));
//                        }
//                    }
//                }
//                else
//                {
//                    if (refCount > 1)
//                        m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle, refCount));
//                    else
//                        m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle));

//                    if (m_DownloadingErrors.ContainsKey(key))
//                        m_DownloadingErrors.Remove(key);
//#if UNITY_EDITOR
//                    isDirty = true;
//#endif
        //        }
        //    }
        //}

        /// <summary>
        /// 检查加载中的AssetBundleCreateRequest，加载完成就放到bundle列表（m_LoadedAssetBundles）。
        /// </summary>
        void UpdateLocal()
        {
            //todo 静态链表，不要每次都null一个新的，添加一个最大的解析数量。
            var keysToRemove = new List<string>();

            Dictionary<string, AssetBundleCreateRequest>.Enumerator e = m_CreatingAssetBundles.GetEnumerator();
            while (e.MoveNext())
            {
                string key = e.Current.Key;
                AssetBundleCreateRequest request = e.Current.Value;

                if (request.isDone)
                {
                    int refCount = m_LocalLoadingReferenceCount[key];
                    m_LocalLoadingReferenceCount.Remove(key); //从加载计数中移除
                    keysToRemove.Add(key);

                    AssetBundle bundle = request.assetBundle;
                    if (bundle == null) //加载bundle失败 会尝试从远端加载
                    {
                        if (loadMode == LoadMode.LocalFirst)
                        {
                            Log(LogType.Info, string.Format("No asset[{2}] in local {0}, try remote {1}", BaseLocalURL, BaseDownloadingURL, key));
                            LoadAssetBundleInternal(key, m_AssetBundleManifest == null, LoadMode.Remote, refCount);
                        }
                        else
                        {
                            if (!m_DownloadingErrors.ContainsKey(key))
                                m_DownloadingErrors.Add(key, string.Format("{0} is not exist.", key));
                        }
                    }
                    else
                    {
                        if (refCount > 1)
                            m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle, refCount));
                        else
                            m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle));
#if UNITY_EDITOR
                        isDirty = true;
#endif
                    }
                }
            }

            for (int i = 0; i < keysToRemove.Count; ++i)
            {
                string key = keysToRemove[i];
                AssetBundleCreateRequest download = m_CreatingAssetBundles[key];
                m_CreatingAssetBundles.Remove(key);
            }
        }

        void UpdateRemote()
        {
            // Collect all the finished WWWs.
            var keysToRemove = new List<string>();

            Dictionary<string, UnityWebRequestAsyncOperation>.Enumerator e = m_UnityWebRequests.GetEnumerator();

            while (e.MoveNext())
            {
                string key = e.Current.Key;
                UnityWebRequestAsyncOperation download = e.Current.Value;

                if (download.isDone)
                {
                    int refCount = m_RemoteLoadingReferencedCount[key];
                    m_RemoteLoadingReferencedCount.Remove(key);
                    keysToRemove.Add(key);

                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(download.webRequest);

                    if (bundle == null)
                    {
                        if (loadMode == LoadMode.RemoteFirst)
                        {
                            Log(LogType.Info, string.Format("No asset[{2}] in remote {0}, try local {1}", BaseDownloadingURL, BaseLocalURL, key));
                            LoadAssetBundleInternal(key, m_AssetBundleManifest == null, LoadMode.Local, refCount);
                        }
                        else
                        {
                            if (!m_DownloadingErrors.ContainsKey(key))
                            {
                                if (download.webRequest.isNetworkError || download.webRequest.isHttpError)
                                    m_DownloadingErrors.Add(key, string.Format("Failed downloading bundle {0} from {1}: {2}", key, download.webRequest.url, download.webRequest.error));
                                else
                                    m_DownloadingErrors.Add(key, string.Format("{0} is not a valid asset bundle.", key));
                            }
                        }
                    }
                    else
                    {
                        if (refCount > 1)
                            m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle, refCount));
                        else
                            m_LoadedAssetBundles.Add(key, new LoadedAssetBundle(bundle));
#if UNITY_EDITOR
                        isDirty = true;
#endif
                    }
                }
            }

            for (int i = 0; i < keysToRemove.Count; ++i)
            {
                string key = keysToRemove[i];

                UnityWebRequestAsyncOperation download = m_UnityWebRequests[key];
                m_UnityWebRequests.Remove(key);
                download.webRequest.Dispose();
                System.GC.SuppressFinalize(download.webRequest);
            }
        }

        void Update()
        {
            if (loadMode != LoadMode.Remote)
                UpdateLocal();

            if (loadMode != LoadMode.Local)
                UpdateRemote();

            // 刷新所有的进度
            if (m_InProgressOperations.Count > 0)
            {
                int count = m_InProgressOperations.Count;
                float time = Time.realtimeSinceStartup;
                int i = 0;
                while (i < m_InProgressOperations.Count)
                {
                    if (!m_InProgressOperations[i].Update()) //返回false 所有的依赖项全部加载成功
                    {
                        m_InProgressOperations.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                    //为了比较平滑的刷新，设置的加载时间。但是有比较大的bundle加载时，可能还是会卡
                    if (Time.realtimeSinceStartup - time >= Time.fixedDeltaTime)
                    {
                        Log(LogType.Info, "Handled " + (count - m_InProgressOperations.Count));
                        break;
                    }
                }
            }

#if UNITY_EDITOR
            if (isDirty)
            {
                isDirty = false;
                allLoaded.Clear();
                allLoaded.AddRange(m_LoadedAssetBundles.Values);
                //allLoaded.Sort((a, b) =>
                //{
                //    return string.Compare(a.name, b.name);
                //});
                allLoaded.Sort((a, b) =>
                {
                    if (b.m_ReferencedCount != a.m_ReferencedCount)
                        return b.m_ReferencedCount - a.m_ReferencedCount;
                    else
                        return string.Compare(a.name, b.name);
                });
            }
#endif
        }
        
        public static AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundleName, string assetName, System.Type type)
        {
            Log(LogType.Info, string.Format(LOADSTR, assetName, type, assetBundleName, Time.realtimeSinceStartup));

            AssetBundleLoadAssetOperation operation = null;
#if UNITY_EDITOR
            if (SimulateAssetBundleInEditor)
            {
                m_SimulateAssetBundleList.Add(assetBundleName);
                string variant = RemapVariantName(assetBundleName);
                operation = new AssetBundleLoadAssetOperationSimulation(assetBundleName, variant, assetName, type);
                m_InProgressOperations.Add(operation);
            }
            else
#endif
            {
                string variant = RemapVariantName(assetBundleName);
                Debug.Log("Load Asset Name: " + variant);
                LoadAssetBundle(variant);
                operation = new AssetBundleLoadAssetOperationFull(assetBundleName, variant, assetName, type);

                m_InProgressOperations.Add(operation);
            }

            return operation;
        }

        
        public static AssetBundleLoadLevelOperation LoadLevelAsync(string assetBundleName, string levelName, bool isAdditive, bool allowSceneActivation)
        {
            Log(LogType.Info, string.Format(LOADSTR, levelName, typeof(UnityEngine.SceneManagement.Scene), assetBundleName, Time.realtimeSinceStartup));

            AssetBundleLoadLevelOperation operation = null;
#if UNITY_EDITOR
            if (SimulateAssetBundleInEditor)
            {
                m_SimulateAssetBundleList.Add(assetBundleName);
                assetBundleName = RemapVariantName(assetBundleName);
                operation = new AssetBundleLoadLevelSimulationOperation(assetBundleName, levelName, isAdditive, allowSceneActivation);
            }
            else
#endif
            {
                assetBundleName = RemapVariantName(assetBundleName);
                LoadAssetBundle(assetBundleName);
                operation = new AssetBundleLoadLevelOperation(assetBundleName, levelName, isAdditive, allowSceneActivation);
            }

            m_InProgressOperations.Add(operation);
            return operation;
        }

        public const string LOADSTR = "Loading [{0}][{1}] from assetbundle [{2}] at realtime since startup [{3}]";
        public const string UNLOADSTR = "Unloading assetbundle reference [{0}], now ref count [{1}]";
    }
}