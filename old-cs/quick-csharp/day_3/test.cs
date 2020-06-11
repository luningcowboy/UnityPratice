using System;
namespace Test{
    class SampleClass{
        public int x;
        public int y;
        public const int c1 = 5;
        public const int c2 = c1 + 5;
        public SampleClass(int p1, int p2){
            x = p1;
            y = p2;
        }
    }
    class Application{
        static void TestSampleClass(){
            SampleClass mc = new SampleClass(11,22);
            Console.WriteLine("x={0},y = {1}", mc.x, mc.y);
            Console.WriteLine("c1 = {0}, c2 = {1}", SampleClass.c1, SampleClass.c2);
        }
        static void TestOprator(){
            int a = 21;
            int b = 10;
            int c;

            c = a + b;
            Console.WriteLine(c);
            c = a - b;
            Console.WriteLine(c);
            c = a * b;
            Console.WriteLine(c);
            c = a / b;
            Console.WriteLine(c);
            c = a % b;
            Console.WriteLine(c);
            c = ++a;
            Console.WriteLine(c);
            c = --a;
            Console.WriteLine(c);
        }
        static void TestString(){
            Console.WriteLine("Hello\tWorld\n\n");
            string a = "Hello,World";
            string b = @"Hello,World";
            string c = "Hello,\tWorld";
            string d = @"Hello,\tWorld";
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
        }
        static void Main(string[] args){
            Application.TestString();
            Application.TestSampleClass();
            Application.TestOprator();
        }
    }
}
