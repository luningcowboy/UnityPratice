using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var luaEnv = new LuaEnv();
        luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world')");
        luaEnv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
