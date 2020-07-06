using System;
using UnityEngine;
using XLua;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Injection
    {
        public string name;
        public GameObject value;
    }
    public class UIEvent : MonoBehaviour
    {
        public TextAsset luaScript;
        public Injection[] injections;
        
        internal static LuaEnv luaEnv = new LuaEnv();
        internal static float lastGCTime = 0;
        internal static float GCInterval = 1;

        private Action luaStart;
        private Action luaUpdate;
        private Action luaOnDesctory;

        private LuaTable scriptEnv;

        void Awake()
        {
            Debug.Log("awake");
            scriptEnv = luaEnv.NewTable();

            LuaTable meta = luaEnv.NewTable();
            meta.Set("__index", luaEnv.Global);
            scriptEnv.SetMetaTable(meta);
            meta.Dispose();

            scriptEnv.Set("self", this);
            foreach (var injection in injections)
            {
                scriptEnv.Set(injection.name, injection.value);
            }

            luaEnv.DoString(luaScript.text, "LuaTestScirpt", scriptEnv);

            Action luaAwake = scriptEnv.Get<Action>("awake");
            scriptEnv.Get("start", out luaStart);
            scriptEnv.Get("update", out luaUpdate);
            scriptEnv.Get("ondestory", out luaOnDesctory);

            if (luaAwake != null)
            {
                luaAwake();
            }
        }

        void Start()
        {
            if (luaStart != null)
            {
                luaStart();
            }
        }

        void Update()
        {
            if (luaUpdate != null)
            {
                luaUpdate();
            }

            if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
            {
                luaEnv.Tick();
                LuaBehaviour.lastGCTime = Time.time;
            }
        }

        private void OnDestroy()
        {
            if (luaOnDesctory != null)
            {
                luaOnDesctory();
            }

            luaOnDesctory = null;
            luaUpdate = null;
            luaStart = null;
            scriptEnv.Dispose();
            injections = null;
        }
    }
}