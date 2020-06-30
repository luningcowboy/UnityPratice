﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class SingletonParent : SingletonBehaviour<SingletonParent>
    {
        void OnApplicationQuit()
        {
            Debug.LogWarning("ApplicationQuit");

            transform.BroadcastMessage("Release", SendMessageOptions.DontRequireReceiver);
        }
    }

    /// <summary>
    /// Be aware this will not prevent a non singleton constructor
    ///   such as `T myT = new T();`
    /// To prevent that, add `protected T () {}` to your singleton class.
    /// 
    /// As a note, this is made as MonoBehaviour because we need Coroutines.
    /// </summary>
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {

#if ODIN_INSPECTOR
        [SerializeField]
        protected bool showOdinInfo;
#endif

        protected static T _instance;
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                                     "' already destroyed on application quit." +
                                     " Won't create again - returning null.");
                    return null;
                }

                // Double-Checked Locking
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = FindObjectOfType<T>();

                            if (FindObjectsOfType<T>().Length > 1)
                            {
                                Debug.LogError("[Singleton] Something went really wrong " +
                                               " - there should never be more than 1 singleton!" +
                                               " Reopenning the scene might fix it.");
                                return _instance;
                            }

                            if (_instance == null)
                            {
                                GameObject singleton = new GameObject("(Singleton) " + typeof(T).ToString());
                                _instance = singleton.AddComponent<T>();

                                DontDestroyOnLoad(singleton);

                                singleton.transform.SetParent(SingletonParent.Instance.transform);

                                Debug.Log("[Singleton] An instance of " + typeof(T) +
                                          " is needed in the scene, so '" + singleton +
                                          "' was created with DontDestroyOnLoad.");
                            }
                            else
                            {
                                Debug.Log("[Singleton] Using instance already created: " +
                                          _instance.gameObject.name);
                            }
                        }
                    }
                }

                return _instance;
            }
        }

        protected static bool applicationIsQuitting = false;
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        public void OnDestroy()
        {
            _instance = null;
            applicationIsQuitting = true;
        }

        public virtual void Release()
        {
            Debug.Log("[Release] " + gameObject.name);
        }

        public enum UpdateMode { FIXED_UPDATE, UPDATE, LATE_UPDATE }
        public UpdateMode updateMode = UpdateMode.UPDATE;
        private void Update()
        {
            if (updateMode == UpdateMode.UPDATE) OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (updateMode == UpdateMode.FIXED_UPDATE) OnUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            if (updateMode == UpdateMode.LATE_UPDATE) OnUpdate(Time.deltaTime);
        }

        protected virtual void OnUpdate(float delta)
        {

        }

        public static void DestroySingleton()
        {
            if (Instance != null)
            {
                Destroy(_instance.gameObject);
            }
        }
    }

    public abstract class Singleton<T> where T : new()
    {
        protected static T _instance;
        private static readonly object _lock;

        static Singleton()
        {
            _lock = new object();
        }

        protected Singleton() { }

        public static T Instance
        {
            get
            {
                // Double-Checked Locking
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = default(T) == null ? Activator.CreateInstance<T>() : default;
                        }
                    }
                }

                return _instance;
            }
        }

        public virtual void Initialize() { }
        public virtual void Release() { }
    }

    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component comp, bool set_enable = false) where T : Component
        {
            if (comp == null)
                return null;

            return GetOrAddComponent<T>(comp.gameObject, set_enable);
        }

        public static T GetOrAddComponent<T>(this GameObject go, bool set_enable = false) where T : Component
        {
            if (go == null)
                return null;

            T result = go.GetComponent<T>();
            if (result == null)
                result = go.AddComponent<T>();

            var bcomp = result as Behaviour;
            if (set_enable && bcomp != null)
                bcomp.enabled = set_enable;

            return result;
        }

        public static Component GetOrAddComponent(this Component comp, Type type, bool set_enable = false)
        {
            if (comp == null)
                return null;

            return GetOrAddComponent(comp.gameObject, type, set_enable);
        }

        public static Component GetOrAddComponent(this GameObject go, Type type, bool set_enable = false)
        {
            if (go == null)
                return null;

            Component result = go.GetComponent(type);
            if (result == null)
                result = go.AddComponent(type);

            var bcomp = result as Behaviour;
            if (set_enable && bcomp != null)
                bcomp.enabled = set_enable;

            return result;
        }
    }

    public static class TransformExtentions
    {
        public static Transform GetOrAddTransform(this Transform parent, string childName, Vector3 position, Vector3 roll)
        {
            Transform t = GetOrAddTransform(parent, childName);
            if (t != null)
            {
                t.localPosition = position;
                t.localRotation = Quaternion.Euler(roll);
            }

            return t;
        }

        public static Transform GetOrAddTransform(this Transform parent, string childName, Vector3 position, Quaternion rotation)
        {
            Transform t = GetOrAddTransform(parent, childName);
            if (t != null)
            {
                t.localPosition = position;
                t.localRotation = rotation;
            }

            return t;
        }

        public static Transform GetOrAddTransform(this Transform parent, string childName)
        {
            if (string.IsNullOrEmpty(childName))
                return parent;

            Transform t = parent?.Find(childName);
            if (t == null)
            {
                int index = childName.IndexOf('/');
                if (index >= 0)
                {
                    string folder = childName.Substring(0, index);
                    childName = childName.Substring(index + 1);

                    return GetOrAddTransform(GetOrAddTransform(parent, folder), childName);
                }

                t = new GameObject(childName).transform;
                t.SetParent(parent, false);
            }

            return t;
        }
    }
}