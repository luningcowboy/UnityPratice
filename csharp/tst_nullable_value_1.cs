using System;
namespace CalculatorApplication{
    class NullablesAtShow{
        static void Main(string[] args){
            int? n1 = null;
            int? n2 = 45;
            double? n3 = new double?();
            double? n4 = 3.14;
            bool? boolval = new bool?();

            Console.WriteLine("显示可空类型:{0}, {1}, {2}, {3}", n1, n2, n3, n4);
            Console.WriteLine("一个可空的布尔值:{0}", boolval);
        }
    
    }

}
