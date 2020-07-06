using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;

[System.Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}
[LuaCallCSharp]
public class LuaBehaviour: MonoBehaviour
{
    public TextAsset luaScript;
    public Injection[] Injections;
    
    internal static LuaEnv luaenv = new LuaEnv();
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;

    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestory;

    private LuaTable scriptEnv;

    private void Awake()
    {
        scriptEnv = luaenv.NewTable();
        var meta = luaenv.NewTable();
        meta.Set("__index", luaenv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in Injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        luaenv.DoString(luaScript.text, "LuaTestScript", scriptEnv);

        Action luaAwake = scriptEnv.Get<Action>("awake");
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestory", out luaOnDestory);

        if (luaAwake != null)
        {
            luaAwake();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }

        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaenv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
    }

    private void OnDestroy()
    {
        if (luaOnDestory != null)
        {
            luaOnDestory();
        }

        luaOnDestory = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();
        Injections = null;
    }
}
