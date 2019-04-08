using System;
namespace CalculatorApplication{
    class NullablesAtShow{
        static void Main(string[] args){
            double? n1 = null;
            double? n2 = 3.14;
            double n3;
            n3 = n1 ?? 5.34;
            Console.WriteLine("num3 = {0}", n3);
            n3 = n2 ?? 5.34;
            Console.WriteLine("num3 = {0}", n3);

        
        }
    }
}
