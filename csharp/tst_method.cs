using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int FindMax(int num1, int num2){
            int ret;
            if(num1 > num2) ret = num1;
            else ret = num2;
            return ret;

        }
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
