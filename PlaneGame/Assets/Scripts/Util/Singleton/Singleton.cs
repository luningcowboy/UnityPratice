using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>  where T: class,new()
{
    private static T _single;

    public static T Single
    {
        get
        {
            if (_single != null) return _single;
            var t = new T();
            return t is MonoBehaviour ? null : _single;
        }
    }
}
