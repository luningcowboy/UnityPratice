using System;
class Test{
    // ref 修饰参数表示操作的是同一块内存地址
    static void Foo(ref int p){
        p = p + 1;
        Console.WriteLine(p);
    }
    static void Main(){
        int x = 0;
        Foo(ref x);
        Console.WriteLine(x);
    }
}
