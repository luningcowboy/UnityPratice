using System;
class Test{
    //params参数修饰符只能修饰方法中的最后一个参数，它能够使方法接受任意数量的指定类型参数。参数类型必须声明为数
    static int Sum(params int[] ints){
        int sum = 0;
        for (int i = 0; i < ints.Length; ++i){
            sum += ints[i];
        }
        return sum;
    }
    static void Main(){
        int total = Sum(1,2,3,4);
        Console.WriteLine(total);
        int total2 = Sum(new int[]{1,2,3,4});
        Console.WriteLine(total2);
    }
}
