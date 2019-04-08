using System;
namespace CalculaorApplication{
    class NumberMainpulator{
        public void getValues(out int x, out int y){
            Console.WriteLine("Please input first number:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input second number:");
            y = Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args){
            NumberMainpulator n = new NumberMainpulator();
            int a, b;
            n.getValues(out a, out b);
            Console.WriteLine("在方法调用之后，a的值:{0}", a);
            Console.WriteLine("在方法调用之后，b的值:{0}", b);
        }
    }
}
