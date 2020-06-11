using System;
namespace HelloWorldApplication{
    class Rectangle{
        double length;
        double width;
        public void Acceptdetails(){
            this.length = 4.5;
            this.width = 3.5;
        }
        public double GetArea(){
            return this.length * this.width;
        }
        public void Display(){
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
            Console.WriteLine("{0} {0} {2}", length, width, GetArea());
            Console.WriteLine("{0} {1} {2}", length, width, GetArea());
            //Console.WriteLine("{} {} {}", length, width, GetArea()); ERROR
        }
    }
    class A{
        public static void M1(){
            Console.WriteLine("A::M1");
        }
        public static void TestTypeConversion(){
            double d = 123.123123123;
            int i;
            i = (int)d;
            Console.WriteLine(i);
        }
    }
    class HelloWorld{
        static void TestValueTypes(){
            Console.WriteLine("Size of int: {0}", sizeof(int));
        }
        static void Main(string[] args){
            Console.WriteLine("HelloWorld");
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            HelloWorld.TestValueTypes();
            A.M1();
            A.TestTypeConversion();
        }
    }
}
