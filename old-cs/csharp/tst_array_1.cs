using System;
namespace ArrayApplication{
    class MyArray{
        static void Main(string[] args){
            int[] n = new int[10];
            int i, j;
            for(i = 0; i < 10; ++i) n[i] = i + 100;
            for(j = 0; j < 10; ++j) Console.WriteLine("Elemennt[{0}] = {1}", j, n[j]);
            Console.ReadKey();
        }
    }
}
