using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XLua;

namespace XLuaTutorial
{
    public class PropertyChangeEventArgs : EventArgs
    {
        public string name;
        public object value;
    }

    public class InvokeLua : MonoBehaviour
    {
        public TextAsset luaScript;
        [CSharpCallLua]
        public interface ICalc
        {
            event EventHandler<PropertyChangeEventArgs> PropertyChanged;
            int Add(int a, int b);
            int Mult { get; set; }

            object this[int index] { get; set; }
        }

        [CSharpCallLua]
        public delegate ICalc CalcNew(int mult, params string[] args);
        

        // Start is called before the first frame update
        void Start()
        {
            LuaEnv luaEnv = new LuaEnv();
            Test(luaEnv);
            luaEnv.Dispose();
        }

        void Test(LuaEnv luaEnv)
        {
            luaEnv.DoString(luaScript.text);
            CalcNew calc_new = luaEnv.Global.GetInPath<CalcNew>("Calc.New");
            ICalc calc = calc_new(10, "hi", "john");
            Debug.Log("sum(*10) = " + calc.Add(1, 2));
            calc.Mult = 100;
            Debug.Log("sum(*100) = " + calc.Add(1, 2));
            Debug.Log("list[0]=" + calc[0]);
            Debug.Log("list[1]=" + calc[1]);

            calc.PropertyChanged += Notify;
            calc[1] = "dddd";
            Debug.Log("List[1]=" + calc[1]);

            calc.PropertyChanged -= Notify;
            calc[1] = "eeee";
            Debug.Log("List[1]=" + calc[1]);

        }

        void Notify(object sender, PropertyChangeEventArgs e)
        {
            Debug.Log(string.Format("{0} has property changed {1}={2}", sender, e.name, e.value));
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}