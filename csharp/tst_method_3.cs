using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int factorail(int num){
            int ret;
            if(num == 1) return 1;
            else{
                ret = factorail(num - 1) * num;
                return ret;
            }
        }
        static void Main(string [] args){
            NumberManipulator n = new NumberManipulator();
            Console.WriteLine("6 的阶乘是: {0}", n.factorail(6));
            Console.WriteLine("7 的阶乘是: {0}", n.factorail(7));
            Console.WriteLine("8 的阶乘是: {0}", n.factorail(8));
        }
    }
}
