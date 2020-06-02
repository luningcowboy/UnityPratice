using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XLuaTest
{
public class TestXLuaHello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XLua.LuaEnv luaEnv = new XLua.LuaEnv();
        luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world')");
        luaEnv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    
}
