using System;
class Test{
    static int x;
    static void Main(){
        Foo(out x);
    }
    static void Foo(out int y){
        Console.WriteLine(x);
        y = 1;
        Console.WriteLine(y);
    }
}
