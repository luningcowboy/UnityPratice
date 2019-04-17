using System;
public class MyClass{
    [Obsolete("Do not use OldMethod, use NewMethod instead", true)]
    static void OldMethod(){
        Console.WriteLine("It is OldMethod");
    }
    static void NewMethod(){
        Console.WriteLine("It is NewMethod");
    }
    public static void Main(){
        OldMethod();
    }
}
