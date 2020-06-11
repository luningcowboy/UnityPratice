using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public void getValue(out int x){
            int tmp = 5;
            x = tmp;
        }
        static void Main(string[] args){
            NumberManipulator n = new NumberManipulator();
            int a = 100;
            Console.WriteLine("在方法调用之前， a = {0}", a);
            n.getValue(out a);
            Console.WriteLine("在方法调用之后， a = {0}", a);

        }
    }
}
