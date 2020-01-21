using System;
class Test{
    static void Foo(int x, int y){
        Console.WriteLine(x + "," + y);
    }
    static void Main(){
        Foo(x: 1, y: 1);
        Foo(y: 2, x: 1);
    }
}
