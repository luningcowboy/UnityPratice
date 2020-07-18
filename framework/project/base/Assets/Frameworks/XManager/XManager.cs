using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using XLua;

namespace Frameworks.XManager
{
    public class XManager : MonoBehaviour
    {
        private static XManager _instance = null;
        public static XManager Instance
        {
            get => _instance;
        }

        private LuaEnv _env = null;
        private Action _entry = null;
        private Action _onApplicationQuit = null;
        private Action _onApplicationPause = null;
        private Action _onApplicationResume = null;

        private Action<float, float> _update = null;
        private Action _lateUpdate = null;
        private Action<float> _fixedUpdate = null;
        private Action _slowUpdate = null;
        private Action _coroutineUpdate = null;

        private float _slowUpdateTimer = 0.0f;

        public void Init()
        {
            InitLuaEnv();
            BindEntry();
            BindUpdater();
            EnterLuaLogic();
        }

        private void InitLuaEnv()
        {
            Log.D("XManager", "InitLuaEnv");
            _env = _env ?? new LuaEnv();
            _env.AddLoader(LoaderForEditor);
            LoadScript(XConfig.MainPath);
        }

        private void BindEntry()
        {
            Log.D("XManager", "BindEntry");
            _entry = _env.Global.GetInPath<Action>(XConfig.EntryPath);
            _onApplicationQuit = _env.Global.GetInPath<Action>(XConfig.OnApplicationQuitPath);
            _onApplicationPause = _env.Global.GetInPath<Action>(XConfig.OnApplicationPausePath);
            _onApplicationResume = _env.Global.GetInPath<Action>(XConfig.OnApplicationResumePath);
        }

        private void BindUpdater()
        {
            Log.D("XManager", "BindUpdater");
            _update = _env.Global.GetInPath<Action<float, float>>(XConfig.Update);
            _lateUpdate = _env.Global.GetInPath<Action>(XConfig.LateUpdate);
            _fixedUpdate = _env.Global.GetInPath<Action<float>>(XConfig.FixedUpdate);
            _slowUpdate = _env.Global.GetInPath<Action>(XConfig.SlowUpdate);
            _coroutineUpdate = _env.Global.GetInPath<Action>(XConfig.CoroutineUpdate);
        }

        private void EnterLuaLogic()
        {
            Log.D("XManager", "EnterLuaLogic");
            SafeDoAction(_entry);
            StartCoroutine(CorcoutineEnumerator());
        }

        private static byte[] LoaderForEditor(ref string path)
        {
            path = Path.Combine(XConfig.SourcePath, path);
            path = path.Replace('.', '/') + ".lua";
            Log.D("XManager", "LoaderForEditor", path);
            return File.ReadAllBytes(path);
        }

        private void SafeDoAction(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                //TODO: Error LOG
                Log.E("XManager", "SafeDoAction", e.Message);
            }
        }

        private void SafeDoString(string script, string chunkName = "chunk", LuaTable env = null)
        {
            Log.D("XManager", "SafeDoString", script);
            try
            {
                _env?.DoString(script, chunkName, env);
            }
            catch (Exception e)
            {
                Log.E("XManager", "SafeDoString", e.Message);
            }
        }

        private void SafeDoActionFloat(Action<float> action, float param1)
        {
            try
            {
                action?.Invoke(param1);
            }
            catch (Exception e)
            {
                Log.E("XManager", "SafeDoActionFloat", e.Message);
            }
        }

        private void SafeDoActionFloatFloat(Action<float, float> action, float param1, float param2)
        {
            try
            {
                action?.Invoke(param1, param2);
            }
            catch (Exception e)
            {
                Log.E("XManager", "SafeDoActionFloatFloat", e.Message);
            }

        }

        private void LoadScript(string requirePath)
        {
            Log.D("XManager", "LoadScript", requirePath);
            SafeDoString($"require '{requirePath}'");
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            if (_env == null) return;
            _env.Tick();
            if (Time.frameCount % 100 == 0) _env.FullGc();
            NormalUpdate();
            SlowUpdate();
        }

        private void LateUpdate()
        {
            if(_lateUpdate != null) SafeDoAction(_lateUpdate);
        }

        private void FixedUpdate()
        {
            if(_fixedUpdate != null) SafeDoActionFloat(_fixedUpdate, Time.fixedDeltaTime);
        }

        private void NormalUpdate()
        {
            if (_update != null)
            {
                SafeDoActionFloatFloat(_update, Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        private void SlowUpdate()
        {
            if (_slowUpdate != null)
            {
                if (_slowUpdateTimer > XConfig.SlowDeltaTime)
                {
                    SafeDoAction(_slowUpdate);
                    _slowUpdateTimer = 0.0f;
                }
                else
                {
                    _slowUpdateTimer += Time.deltaTime;
                }
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            _entry = null;
            _onApplicationQuit = null;
            _onApplicationPause = null;
            _onApplicationResume = null;
            _update = null;
            _fixedUpdate = null;
            _lateUpdate = null;
            _fixedUpdate = null;
            _slowUpdate = null;
            _coroutineUpdate = null;
            
            _env?.Dispose();
            _env = null;
            _instance = null;
        }

        IEnumerator CorcoutineEnumerator()
        {
            while (true)
            {
                if(_coroutineUpdate != null) SafeDoAction(_coroutineUpdate);
                yield return 0;
            }
        }

        private void OnApplicationQuit()
        {
            if(_onApplicationQuit != null) SafeDoAction(_onApplicationQuit);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                if(_onApplicationPause != null) SafeDoAction(_onApplicationPause);
            }
            else
            {
                if(_onApplicationResume != null) SafeDoAction(_onApplicationResume);
            }
        }
    } 
}

