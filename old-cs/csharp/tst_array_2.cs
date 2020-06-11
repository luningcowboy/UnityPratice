using System;
namespace TestArray{
    class Program{
        static void Main(string[] args){
            // 二维数组
            int[,] arr = new int[3,4]{
                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11}
            };
            Console.WriteLine("0,1 {0}", arr[0,1]);
            int [,] arr2 = new int[5,2]{
                {0,0},
                {1,2},
                {2,4},
                {3,6},
                {4,8},
            };
            for(int i = 0; i < 5; ++i){
                for(int j = 0; j < 2; ++j){
                    Console.WriteLine("arr2[{0},{1}] = {2}", i, j, arr2[i, j]);
                }
            }
            // 三维数组
            double [,,] arr3 = new double[3,3,3]{
                {
                    {1.0,1.1,1.2},
                    {2.0,2.1,2.2},
                    {3.0,3.1,3.2}
                },
                {
                    {4.0,4.1,4.2},
                    {5.0,5.1,5.2},
                    {6.0,6.1,6.2}
                },
                {
                    {7.0,7.1,7.2},
                    {8.0,8.1,8.2},
                    {9.0,9.1,9.2}
                }
            };
            Console.WriteLine("arr3[{0},{1},{2}] = {3}", 1,1,1, arr3[1,1,1]);
        }
    }
}
