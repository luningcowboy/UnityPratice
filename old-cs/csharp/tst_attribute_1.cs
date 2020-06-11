#define DEBUG
using System;
using System.Diagnostics;
public class MyClass{
    [Conditional("DEBUG")]
    public static void Message(string msg){
        Console.WriteLine(msg);
    }
}
class Test{
    static void fun1(){
        MyClass.Message("In fun1");
        fun2();
    }
    static void fun2(){
        MyClass.Message("In fun2");
    }
    public static void Main(){
        MyClass.Message("In Main function");
        fun1();
    }
}
