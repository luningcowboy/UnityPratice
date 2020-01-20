using System;
class Test{
    static void split(string name, out string first, out string last){
        int i = name.LastIndexOf(' ');
        first = name.Substring(0, i);
        last = name.Substring(i + 1);
    }
    static void Main(){
        string a, b;
        split("Stevie Ray Vaughan", out a, out b);
        Console.WriteLine(a);
        Console.WriteLine(b);
        // c# 7 新特性 允许在调用out参数的方法时直接声明变量
        split("Stevie Ray Vaughan", out string c, out string d);
        Console.WriteLine(c);
        Console.WriteLine(d);
        // 使用 _ 来丢弃不感兴趣的值
        split("Stevie Ray Vaughan", out string e, out _);
        Console.WriteLine(e);
    }
}
