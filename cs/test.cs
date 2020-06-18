using System;
using System.Collections.Generic;

class A{
    public A(){}
    public string Show()
    {
        return "A:Show";
    }
}
class B{
    public B(){}
    public string Show()
    {
        return "B:Show";
    }
}
class LiteInstance
{
    private static Dictionary<string, object> _instances = new Dictionary<string, object>();
    public static T Instances<T>() where T : class, new()
    {
        var type = typeof(T);
        var key = type.ToString();
        if (_instances.ContainsKey(key))
        {
            return _instances[key] as T;
        }

        var instance = new T();
        _instances.Add(key, instance);
        return instance;
    }
}
class E{
    public static string xxxx = "xxxx";
    static E(){
        Console.WriteLine("initEEEEE");
    }
}
class C{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main=>{E.xxxx}");
        /*
        var a = typeof(A);
        var a1 = a.ToString();
        Console.WriteLine(a.ToString());
        Console.WriteLine(a1);
        Console.WriteLine("Hello World");

        var a2 = LiteInstance.Instances<A>();
        Console.WriteLine(a2.Show());
        var b1 = LiteInstance.Instances<B>();
        Console.WriteLine(b1.Show());

        var d1 = D1.Instance<D1>();
        var d2 = D2.Instance<D2>();
        var d = D.Instance<D>();
        Console.WriteLine(typeof(d));
        Console.WriteLine(typeof(d1));
        Console.WriteLine(typeof(d2));
        */
    }
}
