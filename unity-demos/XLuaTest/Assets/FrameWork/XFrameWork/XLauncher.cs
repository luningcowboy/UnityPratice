using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork.XFrameWork
{
    public class XLauncher : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            Initialize();
        }

        private void Initialize()
        {
        }
    }
}