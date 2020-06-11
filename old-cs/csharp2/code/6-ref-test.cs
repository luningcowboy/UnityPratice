using System;
class Test{
    // ref 修饰参数表示操作的是同一块内存地址
    static void Foo(ref int p){
        p = p + 1;
        Console.WriteLine(p);
    }
    static void swap(ref string a, ref string b){
        string tmp = a;
        a = b;
        b = tmp;
    }
    static void Main(){
        int x = 0;
        Foo(ref x);
        Console.WriteLine(x);
        string s1 = "aaaaa";
        string s2 = "bbbbb";
        swap(ref s1, ref s2);
        Console.WriteLine(s1);
        Console.WriteLine(s2);
    }
}
