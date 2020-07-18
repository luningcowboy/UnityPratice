using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Frameworks
{
    public class Log
    {
        private static string GetTimeStamp()
        {
            var dt = new DateTime(1970,1,1,0,0,0);
            var ts = DateTime.Now - dt;
            var time = Convert.ToInt64(ts.TotalSeconds);
            var ret = dt.AddSeconds(time).ToLocalTime();
            return ret.ToString();
        }

        public static void D(string tag, params string[] arr)
        {
            var info = $"[DEBUG] [{GetTimeStamp()}] [{tag}] {string.Join(" ", arr)}";
            Debug.Log(info);
        }

        public static void W(string tag, params string[] arr)
        {
            var info = $"[WARNING] [{GetTimeStamp()}] [{tag}] {string.Join(" ", arr)}";
            Debug.LogWarning(info);
        }

        public static void E(string tag, params string[] arr)
        {
            var info = $"[ERROR] [{GetTimeStamp()}] [{tag}] {string.Join(" ", arr)}";
            Debug.LogError(info);
        }
    }
}