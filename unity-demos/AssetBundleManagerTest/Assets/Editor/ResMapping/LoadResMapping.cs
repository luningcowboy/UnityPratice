using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using LitJson;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

/// <summary>
/// 资源类型
/// </summary>
[System.Serializable]
public class ResType
{
    public string fullName;
    public string type;
    public string bundleName;
    public string editorPath;
    public string bundlePath;
}

/// <summary>
/// 资源数组
/// </summary>
public class ResList
{
    public List<ResType> list;
}

[System.Serializable]
public class ResConfig : ScriptableObject
{
    #if ODIN_INSPECTOR
    [DictionaryDrawerSettings(KeyLabel = "name",ValueLabel = "value")]
    [ShowInInspector]
    #endif
    public Dictionary<string, ResType> configs;
    
    public void AddConf(string key, ResType value)
    {
       configs.Add(key, value);
    }
}

public class LoadResMapping
{
    private static Dictionary<string, ResConfig> resConfigs = new Dictionary<string, ResConfig>();
    
    [MenuItem("Tools/ResMapping/CreateResMapping")]
    static void CreateResMapping()
    {
        ReadJsonConfig();
    }

    [MenuItem("Tools/ResMapping/TestLoadResMapping")]
    static void TestLoadResMapping()
    {
        var content = Resources.Load<ResConfig>("hall_hall_1Mapping");
        foreach (var config in content.configs)
        {
            Debug.Log($"{config.Key} {config.Value.bundleName}");
        }
        
    }

    private static void ReadJsonConfig()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Editor/ResMapping/Configs/mapping.json");
        string str = reader.ReadToEnd();
        Debug.Log(str);
        var resList = JsonMapper.ToObject<ResList>(str);

        var config = ScriptableObject.CreateInstance<ResConfig>();
        config.configs = new Dictionary<string, ResType>();
        foreach (var resConf in resList.list)
        {
            Debug.Log(resConf.fullName);
            config.AddConf(resConf.fullName, resConf);
        }
        AssetDatabase.CreateAsset(config, $"Assets/Editor/ResMapping/Configs/ResMapping.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static ResConfig GetResConfigByName(string name)
    {
        if (resConfigs.ContainsKey(name))
        {
            return resConfigs[name];
        }
        
        var config = ScriptableObject.CreateInstance<ResConfig>();
        config.configs = new Dictionary<string, ResType>();
        resConfigs.Add(name, config);
        
        return config;
    }

    private static void SaveResConfigs()
    {
        foreach (var resConfig in resConfigs)
        {
            AssetDatabase.CreateAsset(resConfig.Value, $"Assets/Editor/ResMapping/Configs/{resConfig.Key}Mapping.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
