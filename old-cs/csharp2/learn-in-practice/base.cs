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
    static void Variable(){
        int a = 1, b = 2;
        Console.WriteLine("a = {0}, b = {1}",a, b);
    }
    static void Variable1(){
        int num1 = 100;
        double num2 = 100.123;
        bool isFlag = true;
        string name = "Hello";

        Console.WriteLine("num1=" + num1);
        Console.WriteLine("num2=" + num2);
        Console.WriteLine("isFlag=" + isFlag);
        Console.WriteLine("name=" + name);
    }
    static void Variable2(){
        int a = 10;
        int b = 20;
    }
    static void Main(){
        Variable();
        Variable1();
    }
}
