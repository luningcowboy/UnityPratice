using System;
class TestArray{
    static void Main(){
        Console.WriteLine("Test Array");
        const int size = 100;
        byte[,] arr = new byte[size, size];
        unsafe
        {
            fixed (byte* ptr00 = &arr[0, 0], ptr01 = &arr[0, 1], ptr02 = &arr[1, 0])
            {
                Console.WriteLine("&a[0,0]={0}", (long)ptr00);
                Console.WriteLine("&a[0,1]={0}", (long)ptr01);
                Console.WriteLine("&a[1,0]={0}", (long)ptr02);
                /*
                   &a[0,0]=4490006856
                   &a[0,1]=4490006857
                   &a[1,0]=4490006956
                   矩形数组的内存是连续的，在创建的时候就已经决定了
                   */
            }
        }
        int[][] arr2 = new int[][]
        {
            new int[]{0,1,2},
                new int[]{3,4,5},
                new int[]{6,7,8, 9}
        };
        unsafe
        {
            fixed (int* ptr00 = &arr2[0][ 0], ptr01 = &arr2[0][1], ptr02 = &arr2[1][0])
            {
                Console.WriteLine("&a[0,0]={0}", (long)ptr00);
                Console.WriteLine("&a[0,1]={0}", (long)ptr01);
                Console.WriteLine("&a[1,0]={0}", (long)ptr02);
                /*
                   &a[0,0]=4315974824
                   &a[0,1]=4315974828
                   &a[1,0]=4315974872
                   锯齿形数组的内存并不是连续的
                   */
            }
        }
    }
}
