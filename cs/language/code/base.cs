using System;
class Program{
    static void Switch1(out int a, out int b){
        int tmp = a;
        a = b;
        b = tmp;
    }
    static void Switch2(out int a, out int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }
    static void Switch3(out int a, out int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
    }
    static void Test1(){
        int num1 = 100;
        double num2 = 100.23;
        bool isFlag = true;
        string name = "hello";

        Console.WriteLine("num1 = " + num1);
        Console.WriteLine("num2 = " + num2);
        Console.WriteLine("isFlag = " + isFlag);
        Console.WriteLine("name = " + name);

        var num3 = 101;
        var num4 = 1.12;
        var isEnd = false;
        var world = "world";
        Console.WriteLine("world = " + world);
    }
    static void Test2(){
        const double PI = 3.14;
        int r = 3;
        Console.WriteLine("周长:" + 2 * PI * r);
        Console.WriteLine("面积:" + PI * r * r);
    }
    static void Main(string[] args){
        Test2();
    }
}
