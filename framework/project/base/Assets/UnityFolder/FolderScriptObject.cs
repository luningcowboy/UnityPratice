using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif
[System.Serializable]
public class FolderData : Attribute
{
    [SerializeField] public string name;
    public string folderPath;
    private string shellPath;
    [Button(Name = "Open Folder")]
    public void OpenFolder()
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            folderPath = EditorUtility.OpenFolderPanel("Select Path", "", "Select Path");
            if (string.IsNullOrEmpty(folderPath))
            {
                return;
            }
            else
            {
                var temp = folderPath.Split('/');
                name = temp.Last();
            }
        }

        DirectoryInfo mydir = new DirectoryInfo(folderPath);
        if (!mydir.Exists)
        {
            bool create = UnityEditor.EditorUtility.DisplayDialog("Error", "创建文件夹：" + folderPath, "确认" ,"取消");
            if (create)
            {
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                return;
            }
        }

        OpenDirectory(folderPath);
    }
    
    private void OpenDirectory(string path)
    {
        if (string.IsNullOrEmpty(path)) return;
 
        if (!Directory.Exists(path))
        {
            UnityEngine.Debug.LogError("No Directory: " + path);
            return;
        }
 
        //Application.dataPath 只能在主线程中获取
        int lastIndex = Application.dataPath.LastIndexOf("/");
        shellPath = Application.dataPath.Substring(0, lastIndex) + "/Shell/";
 
        // 新开线程防止锁死
        Thread newThread = new Thread(new ParameterizedThreadStart(CmdOpenDirectory));
        newThread.Start(path);
    }
 
    private void CmdOpenDirectory(object obj)
    {
        Process p = new Process();
#if UNITY_EDITOR_WIN
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = "/c start " + obj.ToString();
#elif UNITY_EDITOR_OSX
        p.StartInfo.FileName = "bash";
        string shPath = shellPath + "openDir.sh";
        p.StartInfo.Arguments = shPath + " " + obj.ToString();
#endif
        //UnityEngine.Debug.Log(p.StartInfo.Arguments);
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
 
        p.WaitForExit();
        p.Close();
    }
}

[CreateAssetMenu(menuName = "UnityTools/FolderAsset" ,fileName = "FolderAsset")]
public class FolderScriptObject : ScriptableObject
{
    private void Awake()
    {
        Reset();
    }
    
    [TitleGroup("CustomFolder")] [SerializeField]
    private List<FolderData> CustomFolder = new List<FolderData>();
    [TitleGroup("UnityEditorFolder")] [SerializeField]
    private FolderData[] UnityFolder = new FolderData[4];
    
    [Button]
    public void Reset()
    {
        UnityFolder[0] = new FolderData {name = "Assets", folderPath = Application.dataPath};
        UnityFolder[1] = new FolderData {name = "StreamingAssetsPath", folderPath = Application.streamingAssetsPath};
        UnityFolder[2] = new FolderData {name = "PersistentDataPath", folderPath = Application.persistentDataPath};
        UnityFolder[3] = new FolderData {name = "Resources", folderPath = Path.Combine(Application.dataPath,"Resources")};
    }
    
 
    
}
