using System;
namespace OperatorAppl{
    class Program{
        static void Main(string[] args){
            int a = 1;
            int b;
            
            b = a++;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

            a = 1;
            b = ++a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();
        
            a = 1;
            b = a--;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

            a = 1;
            b = --a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

        }
    
    }

}
