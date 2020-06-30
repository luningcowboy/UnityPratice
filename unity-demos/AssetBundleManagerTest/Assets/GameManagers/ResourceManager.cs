using System.Collections;
using System.Collections.Generic;
using AssetBundles;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GameManager
{
    public class ResourceManager : SingletonBehaviour<ResourceManager>
    {
        public enum MemeryHold
        {
            Once = 0,   // 进出牌局自动释放或者自己调用释放
            Normal, // 自己调用释放
            Always, // 在关闭游戏的时候释放
        }

        [System.Serializable]
        public class AssetCache
        {
            public string assetName;            // AssetBundle中的资源名字
            public string assetbundleName;      // AssetBundle的名字
            public string assetbundleVariant;   // 实际加载的AssetBundle的变体的名字
            public System.Type type;            // 资源类型
            public MemeryHold hold;             // 内存持久类型
            public int refCount;                // 被引用次数

            public object obj;                  // 缓存中的资源对象

            public void Release()
            {
                if (obj != null)
                {
                    if (obj is GameObject prefab)
                    {
                        prefab.RecycleAll();
                        prefab.DestroyPooled();
                    }
                }

                obj = null;

                if (!string.IsNullOrEmpty(assetbundleVariant))
                    AssetBundleManager.UnloadAssetBundle(assetbundleVariant);
            }
        }

        private const string AssetKeyFormat = "{0}@{1}@{2}";
        private const int RemoveAssetDelay = 60;

        private bool IsInited;
        private AssetBundleLoadLevelOperation m_LoadSceneOpration;  // 单场景读取进程
        private AssetBundleLoadManifestOperation m_AssetBundleLoadManifestOperation;

        public delegate void OnLoadComplete(string key, object asset, string err);

#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo")]
#endif
        public float LoadingSceneProgress
        {
            get;
            private set;
        }

#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo")]
#endif
        public bool IsLoadingScene
        {
            get;
            private set;
        }

#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), ListDrawerSettings(IsReadOnly = true)]
#endif
        private List<AssetBundleLoadAssetOperation> m_InProgressOperations = new List<AssetBundleLoadAssetOperation>(); //正在加载的资源
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        private readonly Dictionary<string, List<System.Delegate>> m_CallbackStack = new Dictionary<string, List<System.Delegate>>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true, DisplayMode = DictionaryDisplayOptions.Foldout)]
#endif
        private readonly Dictionary<string, AssetCache> m_AssetCaches = new Dictionary<string, AssetCache>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        private readonly Dictionary<string, string> m_LoadedScenesAssetBundle = new Dictionary<string, string>();
#if ODIN_INSPECTOR
        [ShowInInspector, ShowIf("showOdinInfo"), DictionaryDrawerSettings(IsReadOnly = true)]
#endif
        private readonly Dictionary<object, string> m_ObjectKeyMap = new Dictionary<object, string>();

        private readonly List<string> m_CallbackTemp = new List<string>();


#if UNITY_EDITOR
        private bool isDirty;
#if ODIN_INSPECTOR
        [ShowInInspector, HideIf("showOdinInfo"), ListDrawerSettings(IsReadOnly = true, Expanded = true)]
#endif
        private List<AssetCache> InspectorShower = new List<AssetCache>();
#endif

        public override void Release()
        {
            base.Release();

            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;


            UnloadUnusedAssets();
        }

        public void Initialize(OnLoadComplete callback = null, AssetBundleManager.LoadMode loadMode = AssetBundleManager.LoadMode.Internal, AssetBundleManager.LogMode logMode = AssetBundleManager.LogMode.JustErrors)
        {
            Initialize(null, null, callback, loadMode, logMode);
        }

        public void Initialize(string localAssetBundlePath, string remoteAssetBundlePath, OnLoadComplete callback, AssetBundleManager.LoadMode loadMode = AssetBundleManager.LoadMode.Internal, AssetBundleManager.LogMode logMode = AssetBundleManager.LogMode.JustErrors)
        {
            if (!AssetBundleManager.IsInited)
            {
                //1.场景的加载/卸载管理
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.sceneUnloaded += OnSceneUnloaded;

                //bundle的加载/卸载管理
                AssetBundleManager.loadMode = loadMode;
                AssetBundleManager.logMode = logMode;

                //设置本地资源加载路径，和远端资源加载路径
                AssetBundleManager.SetLocalAssetBundleDirectory(localAssetBundlePath);
                AssetBundleManager.SetRemoteAssetBundleURL(remoteAssetBundlePath);

                //todo 需要和热更逻辑配合
                // string file = Path.Combine(AssetBundleManager.BaseLocalURL, Utility.GetPlatformName());
                // if (File.Exists(file))
                // {
                //     File.Delete(file);
                // }

                AssetBundleManager.ActiveVariants = new string[] { "bundle" };

                RegistCallback(Utility.GetPlatformName(), callback); //资源初始化完成的回调
                m_AssetBundleLoadManifestOperation = AssetBundleManager.Initialize();
            }
            else
            {
                StartCoroutine(_YieldCallback(callback));
            }
        }

        IEnumerator _YieldCallback(OnLoadComplete callback)
        {
            yield return new WaitForEndOfFrame();
            callback(Utility.GetPlatformName(), AssetBundleManager.AssetBundleManifestObject, null);
        }

        #region load scene
        public string LoadSceneAsync(string assetBundle, string sceneName, bool isAdditive, bool allowSceneActivation = true, OnLoadComplete callback = null)
        {
            if (string.IsNullOrEmpty(assetBundle))
                return string.Empty;

            assetBundle = assetBundle.ToLower();

            if (IsInLoading(sceneName))
            {
                RegistCallback(sceneName, callback);
                return sceneName;
            }

            RegistCallback(sceneName, callback);
            m_LoadSceneOpration = AssetBundleManager.LoadLevelAsync(assetBundle, sceneName, isAdditive, allowSceneActivation);
            LoadingSceneProgress = 0;

            return sceneName;
        }

        public AsyncOperation UnloadScene(string levelName)
        {
            AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

            return ao;
        }

        public string[] GetLoadedScenes()
        {
            string[] array = new string[m_LoadedScenesAssetBundle.Keys.Count];
            m_LoadedScenesAssetBundle.Keys.CopyTo(array, 0);
            return array;
        }

        public bool SceneIsLoaded(string sceneName)
        {
            return m_LoadedScenesAssetBundle.ContainsKey(sceneName);
        }
        #endregion

        #region load asset async
        /// <summary>
        /// Loads the asset async.
        /// </summary>
        /// <param name="assetBundle">Asset bundle.</param>
        /// <param name="assetName">Asset name.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="preload">If set to <c>true</c> preload.</param>
        /// <param name="memeryHold">Memery hold.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public string LoadAssetAsync<T>(string assetBundle, string assetName = null, OnLoadComplete callback = null, bool preload = false, MemeryHold memeryHold = MemeryHold.Once) where T : Object
        {
            return LoadAssetAsync(assetBundle, assetName, typeof(T), callback, preload, memeryHold);
        }

        /// <summary>
        /// Loads the asset async.
        /// </summary>
        /// <param name="assetBundle">Asset bundle.</param>
        /// <param name="assetName">Asset name.</param>
        /// <param name="type">Type.</param>
        /// <param name="callback">Callback.</param>
        /// <param name="preload">If set to <c>true</c> preload asset and if <paramref name="memeryHold"/> is not "Always", ref count will no increase.</param>
        /// <param name="memeryHold">Memery hold.</param>
        public string LoadAssetAsync(string assetBundle, string assetName, System.Type type, OnLoadComplete callback = null, bool preload = false, MemeryHold memeryHold = MemeryHold.Once)
        {
            if (string.IsNullOrEmpty(assetBundle))
                return string.Empty;

            //Debug.Log(string.Format("LoadAssetAsync {0}, {1}", assetName, Time.frameCount));

            // if (type != typeof(UnityEngine.U2D.SpriteAtlas))
            //     assetBundle = assetBundle.ToLower();
            //根据项目 获得资源的主键，主要是处理特殊资源
            string key = AssetKey(assetBundle, assetName, type); 

            // 查找或创建一个AssetCache
            AssetCache cache = GenAssetCache(key, assetBundle, assetName, type, memeryHold, preload);

            // 判断是否正在Loading
            if (IsInLoading(key))
            {
                // 如果同一个资源已经在Loading，不用再新开加载
                RegistCallback(key, callback);
                return key;
            }

            // 注册回调
            RegistCallback(key, callback);

            // 如果缓存区已经有资源
            if (cache.obj != null)
            {
                m_CallbackTemp.Add(key);
                return key;
            }

            AssetBundleLoadAssetOperation ao = AssetBundleManager.LoadAssetAsync(assetBundle, assetName, type);

            if (ao != null)
            {
                m_InProgressOperations.Add(ao);
            }

            return key;
        }
        #endregion

        #region load asset sync
        /// <summary>
        /// Gets the cached asset.
        /// </summary>
        /// <returns>The cached asset.</returns>
        /// <param name="assetBundleName">Asset bundle name.</param>
        /// <param name="assetName">Asset name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T GetCachedAsset<T>(string assetBundleName, string assetName) where T : Object
        {
            string key = AssetKey(assetBundleName, assetName, typeof(T));

            object obj = GetCachedAsset(key);
            if (obj != null)
                return obj as T;
            else
                return null;
        }

        public object GetCachedAsset(string key)
        {
            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                if (cache.obj != null)
                {
#if UNITY_EDITOR
                    isDirty = true;
#endif
                    cache.refCount++;
                    return cache.obj;
                }
            }

            return null;
        }
        #endregion

        [System.Obsolete]
        public bool HasCachedAsset(object obj)
        {
            return m_ObjectKeyMap.ContainsKey(obj);
        }

        #region unload assets
        /// <summary>
        /// Unloads the asset.
        /// </summary>
        /// <param name="key">Key.</param>
        public void UnloadAssetWithKey(string key, bool immediately = false)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("key is null");
                return;
            }

            AssetCache cache = UnloadCachedAsset(key); //减少计数

            if (cache != null && cache.refCount == 0 && cache.hold != MemeryHold.Always)
            {
                if (applicationIsQuitting || immediately)
                    RemoveCachedAsset(key);
                else
                    RemoveCachedAssetDelay(key, RemoveAssetDelay);
            }
        }

        /// <summary>
        /// Unloads the unused assets.
        /// </summary>
        public void UnloadUnusedAssets(MemeryHold hold = MemeryHold.Once)
        {
            List<string> tempList = new List<string>();
            Dictionary<string, AssetCache>.Enumerator e = m_AssetCaches.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Value.hold <= hold && e.Current.Value.refCount == 0)
                {
                    tempList.Add(e.Current.Key);
                }
            }
            for (int i = 0; i < tempList.Count; ++i)
            {
                // 立即移除
                RemoveCachedAsset(tempList[i]);
            }
            tempList.Clear();
            tempList = null;

            System.GC.Collect();
        }

        public void ForceUnloadAssets(MemeryHold hold = MemeryHold.Once)
        {
            List<string> tempList = new List<string>();
            Dictionary<string, AssetCache>.Enumerator e = m_AssetCaches.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Value.hold <= hold)
                {
                    tempList.Add(e.Current.Key);
                }
            }
            for (int i = 0; i < tempList.Count; ++i)
            {
                // 立即移除
                RemoveCachedAsset(tempList[i]);
            }
            tempList.Clear();
            tempList = null;

            System.GC.Collect();
        }
        #endregion

        public void StopAllLoadingProgress()
        {
            AssetBundleLoadAssetOperation operation = null;
            for (int i = 0; i < m_InProgressOperations.Count; i++)
            {
                operation = m_InProgressOperations[i];
                string key = AssetKey(operation.assetBundleName, operation.assetName, operation.type);
                UnregistCallback(key);
            }
        }

        protected override void OnUpdate(float delta)
        {
            base.OnUpdate(delta);

            if (!IsInited)
            {
                // 等AssetBundleManifest初始化完成，再继续更新其他Operation
#if UNITY_EDITOR
                if (AssetBundleManager.SimulateAssetBundleInEditor)
                {
                    IsInited = true;
                    Callback(Utility.GetPlatformName());
                }
                else
                {
#endif
                if (m_AssetBundleLoadManifestOperation != null && m_AssetBundleLoadManifestOperation.IsDone())
                {
                    IsInited = true;
                    Callback(Utility.GetPlatformName(), m_AssetBundleLoadManifestOperation.GetAsset<AssetBundleManifest>(), m_AssetBundleLoadManifestOperation.Error);
                    m_AssetBundleLoadManifestOperation = null;
                }
#if UNITY_EDITOR
                }
#endif
            }
            else
            {
                
                //bundle
                UpdateLoadAssets();

                //场景
                if (m_LoadSceneOpration != null)
                {
                    IsLoadingScene = true;
                    LoadingSceneProgress = m_LoadSceneOpration.Progress();

                    if (m_LoadSceneOpration.IsDone() && !string.IsNullOrEmpty(m_LoadSceneOpration.Error))
                    {
                        IsLoadingScene = false;
                        Callback(m_LoadSceneOpration.LevelName, null, m_LoadSceneOpration.Error);
                        m_LoadSceneOpration = null;
                    }
                }
            }

#if UNITY_EDITOR
            if (isDirty)
            {
                isDirty = false;
                InspectorShower.Clear();
                InspectorShower.AddRange(m_AssetCaches.Values);
                InspectorShower.Sort(
                    (a, b) =>
                    {
                        if (a.hold != b.hold)
                            return a.hold - b.hold;
                        else if (a.refCount != b.refCount)
                            return b.refCount - a.refCount;
                        else
                            return string.Compare(a.assetName, b.assetName);
                    });
            }
#endif
        }

        private void UpdateLoadAssets()
        {
            AssetBundleLoadAssetOperation operation = null;
            for (int i = 0; i < m_InProgressOperations.Count;)
            {
                operation = m_InProgressOperations[i];
                if (operation.IsDone())
                {
                    // 如果完成直接移除，避免后面回调方法中上层逻辑错误导致不停Update
                    m_InProgressOperations.RemoveAt(i);
                    string key = AssetKey(operation.assetBundleName, operation.assetName, operation.type);

                    if (string.IsNullOrEmpty(operation.Error))
                    {
                        AssetCache asset = CacheAsset(key, operation.GetAsset());
                        if (asset != null)
                        {
                            asset.assetbundleVariant = operation.assetBundleVariant;

                            m_CallbackTemp.Add(key);
                        }
                        else
                        {
                            AssetBundleManager.UnloadAssetBundle(operation.assetBundleVariant);
                            Callback(key, null, string.Format("[{0} no asset error!]", key));
                        }
                    }
                    else
                    {
                        if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
                        {
                            cache.assetbundleVariant = operation.assetBundleVariant;
                        }

                        RemoveCachedAsset(key);
                        Callback(key, null, operation.Error);
                    }
                }
                else
                {
                    i++;
                }
            }

            //todo 同一帧可能返回多个，这里还是需要保护一下，
            while (m_CallbackTemp.Count > 0)
            {
                string key = m_CallbackTemp[0];

                if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
                {
                    if (cache != null && cache.obj != null)
                    {
                        Callback(key, cache.obj, string.Empty);
                    }
                    else
                    {
                        Debug.LogErrorFormat("{0} is Null", key);
                    }
                }

                m_CallbackTemp.RemoveAt(0);
            }
        }

        private void Callback(string key, object t = null, string err = null)
        {
            if (!string.IsNullOrEmpty(err))
                Debug.LogError(err);

            if (m_CallbackStack.TryGetValue(key, out List<System.Delegate> callbackList))
            {
                m_CallbackStack.Remove(key);
                foreach (OnLoadComplete callback in callbackList)
                {
                    try
                    {
                        if (callback != null)
                            callback.Invoke(key, t, err);
                        else
                            UnloadAssetWithKey(key);
                    } catch (System.Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
            else
            {
                RemoveCachedAsset(key);
            }
        }

        private void RegistCallback(string key, System.Delegate callback)
        {
            if (callback != null && !string.IsNullOrEmpty(key))
            {
                if (!m_CallbackStack.ContainsKey(key))
                    m_CallbackStack.Add(key, new List<System.Delegate>());
                if (!m_CallbackStack[key].Contains(callback))
                    m_CallbackStack[key].Add(callback);
            }
        }

        private void UnregistCallback(string key)
        {
            if (m_CallbackStack.TryGetValue(key, out List<System.Delegate> callbackList))
            {
                m_CallbackStack.Remove(key);
            }
        }

        private bool IsInLoading(string key)
        {
            return m_CallbackStack.ContainsKey(key);
        }

        private void RemoveCachedAssetDelay(string key, float delay)
        {
            StartCoroutine(_RemoveCachedAssetDelay(key, delay));
        }

        private IEnumerator _RemoveCachedAssetDelay(string key, float delay)
        {
            yield return new WaitForSeconds(delay);

            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                // 避免延迟期间，又被重新引用
                if (cache.refCount == 0)
                {
                    if (cache.obj != null)
                        m_ObjectKeyMap.Remove(cache.obj);
                    cache.Release();
                    m_AssetCaches.Remove(key);
#if UNITY_EDITOR
                    isDirty = true;
#endif
                }
            }
        }

        private AssetCache RemoveCachedAsset(string key)
        {
            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                if (cache.obj != null)
                    m_ObjectKeyMap.Remove(cache.obj);
                cache.Release();
                m_AssetCaches.Remove(key);
#if UNITY_EDITOR
                isDirty = true;
#endif
            }

            return cache;
        }

        private AssetCache UnloadCachedAsset(string key)
        {
            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                cache.refCount--;
#if UNITY_EDITOR
                isDirty = true;
#endif
            }

            return cache;
        }

        private AssetCache CacheAsset(string key, object obj)
        {
            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                cache.obj = obj;
                if (m_ObjectKeyMap.ContainsKey(obj))
                {
                    if (!m_ObjectKeyMap[obj].Equals(key))
                        Debug.LogErrorFormat("{0} and {1} has same object", m_ObjectKeyMap[obj], key);
                }
                else
                    m_ObjectKeyMap.Add(obj, key);

                // 处理Preload的情况下，自动释放
                if (cache.refCount == 0 && cache.hold != MemeryHold.Always)
                    RemoveCachedAssetDelay(key, RemoveAssetDelay);

#if UNITY_EDITOR
                isDirty = true;
#endif
            }
            else
            {
                Debug.LogWarningFormat("There is no asset cache with key : {0}, so {1} can not be cached.", key, ((Object)obj).name);
            }

            return cache;
        }

        /// <summary>
        /// 查找或创建 AssetCache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="assetBundle"></param>
        /// <param name="assetName"></param>
        /// <param name="type"></param>
        /// <param name="hold"></param>
        /// <param name="preload"></param>
        /// <returns></returns>
        private AssetCache GenAssetCache(string key, string assetBundle, string assetName, System.Type type, MemeryHold hold, bool preload = false)
        {
            if (m_AssetCaches.TryGetValue(key, out AssetCache cache))
            {
                Debug.Assert(assetBundle == cache.assetbundleName && assetName == cache.assetName && type == cache.type, "Cached Asset is not same.");

                if (cache.hold < hold)
                    cache.hold = hold;

                if (!preload)
                    cache.refCount++;
            }
            else
            {
                cache = new AssetCache
                {
                    assetName = assetName,
                    assetbundleName = assetBundle,
                    type = type,
                    hold = hold,
                    refCount = preload ? 0 : 1,
                };

                m_AssetCaches.Add(key, cache);
            }

#if UNITY_EDITOR
            isDirty = true;
#endif

            return cache;
        }

        #region SceneManager callback
        private LoadSceneMode m_LoadSceneMode;
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_LoadSceneMode = mode;

            if (m_LoadSceneOpration != null)
            {
                m_LoadedScenesAssetBundle[scene.name] = m_LoadSceneOpration.AssetBundle;
            }

            if (mode == LoadSceneMode.Single)
            {
                IsLoadingScene = false;
                LoadingSceneProgress = 1;
                Callback(scene.name);
                m_LoadSceneOpration = null;
            }
            else if (mode == LoadSceneMode.Additive)
            {
                IsLoadingScene = false;
                LoadingSceneProgress = 1;
                Callback(scene.name);
                m_LoadSceneOpration = null;
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            if (m_LoadedScenesAssetBundle.ContainsKey(scene.name))
            {
                AssetBundleManager.UnloadAssetBundle(m_LoadedScenesAssetBundle[scene.name]);
                m_LoadedScenesAssetBundle.Remove(scene.name);
            }
        }
        #endregion

        public int GetInProgressCount()
        {
            return m_InProgressOperations.Count;
        }


        #region static methods

        public static string AssetKey(string assetBundle, string assetName, System.Type type)
        {
            if (string.IsNullOrEmpty(assetBundle))
            {
                Debug.LogError("AssetBundleName is Null");
                return string.Empty;
            }

            if (type == typeof(UnityEngine.U2D.SpriteAtlas))
            {
                return assetBundle;
            }

            assetBundle = assetBundle.ToLower();

            return string.Format(AssetKeyFormat, assetName ?? "", assetBundle, type);
        }

        public static void ParseAssetKey(string key, out string assetName, out string assetBundleName, out System.Type type)
        {
            assetName = "";
            assetBundleName = "";
            type = null;

            if (string.IsNullOrEmpty(key))
                return;

            string[] split = key.Split('@');
            if (split.Length < 3)
                return;

            assetName = split[0];
            assetBundleName = split[1];
            type = System.Type.GetType(split[2]);
        }
        #endregion
    }
}
