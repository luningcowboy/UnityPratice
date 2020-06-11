using System;
namespace Test{
    class OperateTest{
        public static void Test1(){
            int a = 21;
            int b = 10;
            int c;
            c = a + b;
            Console.WriteLine("Line 1 - c = {0}", c);
            c = a - b;
            Console.WriteLine("Line 2 - c = {0}", c);
            c = a * b;
            Console.WriteLine("Line 3 - c = {0}", c);
            c = a / b;
            Console.WriteLine("Line 4 - c = {0}", c);
            c = a % b;
            Console.WriteLine("Line 5 - c = {0}", c);
            c = ++a;
            Console.WriteLine("Line 6 - c = {0}", c);
            c = --a;
            Console.WriteLine("Line 7 - c = {0}", c);
        }
        public static void Test2(){
            int a = 1;
            int b;

            b = a++;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = ++a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = a--;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = --a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
    class Application{
        static void Main(string[] args){
            OperateTest.Test1();
            OperateTest.Test2();
        }
    }
}
