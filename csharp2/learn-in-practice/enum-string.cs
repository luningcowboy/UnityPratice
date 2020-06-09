using System;
using System.Collections.Generic;
enum Test{
    Test1,
    Test2,
    Test3
}

class Program{
    static Dictionary<string, int> GetDic<TEnum>(){
        Dictionary<string, int> dic = new Dictionary<string, int>();
        Type t = typeof(TEnum);
        var arr = Enum.GetValues(t);
        foreach(var item in arr)
        {
            dic.Add(item.ToString(), (int)item);
        }
        return dic;
    }
    static T ConvertString2Enum<T>(string str){
        return (T)Enum.Parse(typeof(T), str, true);
    }
    static void Main(string[] args){
        var dic = GetDic<Test>();
        foreach(var e in dic){
            Console.WriteLine(e.Key, e.Value);
            var t = ConvertString2Enum<Test>(e.Key);
            Console.WriteLine("xxx", t.ToString());
        }

    }
}
