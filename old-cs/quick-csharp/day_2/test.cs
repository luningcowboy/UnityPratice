using System;
namespace TypeConversionApplication{
    class ExplicitConversion{
        static void Test2(){
            int i = 75;
            float f = 53.005f;
            double d = 2345.7652;
            bool b = true;

            Console.WriteLine(i.ToString());
            Console.WriteLine(f.ToString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(b.ToString());

        }
        static void Test3(){
            int d = 3, f = 5;
            byte z = 22;
            double pi = 3.1415;
            char x = 'x';
            Console.WriteLine(d.ToString(), f.ToString());
            Console.WriteLine(z.ToString());
            Console.WriteLine(pi.ToString());
            Console.WriteLine(x.ToString());
        }
        static void Test4(){
            short a;
            int b;
            double c;

            a = 10;
            b = 20;
            c = a + b;
            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
        }
        static void Test5(){
            int num;
            Console.WriteLine("Please input a num:\n");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input={0}", num);
        }
        static void Main(string[] args){
            double d = 123.1223;
            int i ;
            // 小数部分丢失
            i = (int)d;
            Console.WriteLine(i);
            ExplicitConversion.Test2();
            ExplicitConversion.Test3();
            ExplicitConversion.Test4();
            //ExplicitConversion.Test5();
        }
    }
}
