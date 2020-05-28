using System;
class Program{
    static void Operate(){
        Console.WriteLine("千位" + 1234 / 1000);
        Console.WriteLine("百位" + 1234 / 100 % 10);
        Console.WriteLine("十位" + 1234 / 10 % 10);
        Console.WriteLine("个位" + 1234 % 10);
    }
    static void Operate2(){
        bool a = true;
        bool b = true;
        bool c = false;
        if(a && b){
            Console.WriteLine("a && b");
        }
        if(a || b){
            Console.WriteLine("a || b");
        }
        if(!c){
            Console.WriteLine("!c");
        }
    }
    static void Operate3(){
        int a = 1;
        int b = 2;
        int c = 3;
        if(b > a) Console.WriteLine("b > a");
        if(a < c) Console.WriteLine("a < c");
        if(c >= a) Console.WriteLine("c >= a");
        if(a <= b) Console.WriteLine("a <= b");
    }
    static void Operate4(){
        Console.WriteLine("2的立方:" + (2<<2));
        Console.WriteLine("3<<3:" + (3<<3));
        bool a = true;
        Console.WriteLine(a ? "a = true" : "a = false");
    }
    static void Main(){
        Operate();
        Operate2();
        Operate3();
        Operate4();
    }
}
