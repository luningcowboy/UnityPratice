using System;
using System.Collections;
using System.Collections.Generic;
using Frameworks.XManager;
using UnityEngine;

namespace Frameworks
{
    public class Launcher : MonoBehaviour
    {
        private void Awake()
        {
            Log.D("Launcher", "Awake");
            DontDestroyOnLoad(gameObject);
            Init();
        }

        private void Init()
        {
            Log.D("Launcher", "Init");
            gameObject.AddComponent<XManager.XManager>();
            XManager.XManager.Instance.Init();
        }
    }
}