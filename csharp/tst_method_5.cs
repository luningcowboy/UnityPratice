using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public void swap(ref int x, ref int y){
            int tmp;
            tmp = x;
            x = y;
            y = tmp;
        }
        static void Main(string[] args){
            NumberManipulator n = new NumberManipulator();
            int a = 100;
            int b = 200;
            Console.WriteLine("在交换之前，a的值:{0}", a);
            Console.WriteLine("在交换之前，b的值:{0}", b);
            n.swap(ref a, ref b);
            Console.WriteLine("在交换之前，a的值:{0}", a);
            Console.WriteLine("在交换之前，b的值:{0}", b);
        }
    }

}
