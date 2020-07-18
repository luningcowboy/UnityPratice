using System;
using UnityEngine;

namespace Frameworks.XManager
{
    public class XConfig
    {
        public static readonly string SourcePath = Application.dataPath.Replace("/Assets", "/XScripts");
        public const string Main = "Main";
        public const string MainPath = "" + Main;
        public const string EntryPath = Main + ".Entry";
        public const string OnApplicationQuitPath = Main + ".OnApplicationQuit";
        public const string OnApplicationPausePath = Main + ".OnApplicationPause";
        public const string OnApplicationResumePath = Main + ".OnApplicationResume";

        public const string Updater = "Frameworks.Unity.Updater";
        public const string Update = Updater + ".Update";
        public const string LateUpdate = Updater + ".LateUpdate";
        public const string FixedUpdate = Updater + ".FixedUpdate";
        public const string SlowUpdate = Updater + ".SlowUpdate";
        public const string CoroutineUpdate = Updater + ".CorooutineUpdate";

        public const float SlowDeltaTime = 1.0f;
    }
}