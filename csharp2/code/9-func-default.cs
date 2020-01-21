using System;
class Test{
    static void Foo(int x = 0, int y = 0){
        Console.WriteLine(x + "," + y);
    }
    static void Main(){
        Foo();
        Foo(1, 1);
    }
}
