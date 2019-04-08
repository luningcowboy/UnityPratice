using System;
namespace LoopForeach{
    class Program{
        static void Main(string[] args){
            int[] arr = new int[]{0,1,2,3,4,5,6};
            foreach(int ele in arr){
                Console.WriteLine("ele is {0}", ele);
            }
        }
    }
}
