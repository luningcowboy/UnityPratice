using System;
class A{
    private int x = 10;
    public static int X = 10;
    public static ref int GetX() => ref X;
    public A(){
    }
    public int getX(){
        return x;
    }
    public ref int getX2(){
        return ref x;
    }
}
class Test{
    
    static void Main(){
        // 引用局部变量
        int [] numbers = {0,1,2,3,4};
        ref int numRef = ref numbers[2];
        numRef *= 10;
        Console.WriteLine(numRef);
        Console.WriteLine(numbers[2]);
        // 属性不能被这样操作
        // 类变量可以
        /*
        A tmpA = new A();
        ref int xRef = ref tmpA.getX();
        xRef = xRef * 10;
        Console.WriteLine(xRef);
        Console.WriteLine(tmpA.getX());
        */
        ref int xRef = ref A.X;
        xRef = xRef * 10;
        Console.WriteLine(xRef);
        Console.WriteLine(A.X);

        // 引用返回值
        var tmpA = new A();
        ref var xRef2 = ref tmpA.getX2();
        xRef2 *= 2;
        Console.WriteLine(xRef2);
        Console.WriteLine(tmpA.getX2());

        ref var XRef2 = ref A.GetX();
        XRef2 += 5;
        Console.WriteLine(XRef2);
        Console.WriteLine(A.GetX());
    }
}
