// 交错数组
using System;
namespace ArrayApplication{
    class MyArray{
        static void Main(string[] args){
            int [][] a = new int[][]{
                new int[]{0,0},
                new int[]{1,2},
                new int[]{3,4,5}
            };
            for(int i = 0; i < a.Length; ++i){
                for(int j = 0; j < a[i].Length; ++j){
                    Console.WriteLine("a[{0}][{1}]={2}", i, j, a[i][j]);
                    // 这样输出会报错，交错数组跟正常数组是不一样的
                    Console.WriteLine("a[{0},{1}]={2}", i, j, a[i,j]);
                }
            }
        }
    }
}
