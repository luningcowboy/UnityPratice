using System;
namespace LoopForeach{
    class Program{
        static void Main(string[] args){
            int[] arr = new int[]{0,1,2,3,4,5,6};
            foreach(int ele in arr){
                Console.WriteLine("ele is {0}", ele);
            }
            Console.WriteLine();
            for(int i = 0; i < arr.Length; i++){
                Console.WriteLine("ele is {0}", arr[i]);
            }
            int count = 0;
            foreach(int ele in arr){
                count += 1;
                Console.WriteLine("Element #{0}:{1}", count, ele);
            }
            Console.WriteLine("Element #{0}", count);
        }
    }
}
