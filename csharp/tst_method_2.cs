using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int FindMax(int n1, int n2){
            int ret;
            ret = n1 > n2 ? n1 : n2;
            return ret;
        }
    }
    class Test{
        static void Main(string[] args){
            int a = 100;
            int b = 200;
            int ret;
            NumberManipulator n = new NumberManipulator();
            ret = n.FindMax(a, b);
            Console.WriteLine("最大值是:{0}", ret);
        
        }
    }
}
