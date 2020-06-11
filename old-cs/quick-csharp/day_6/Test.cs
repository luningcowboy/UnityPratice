using System;

namespace Test{
    class Rectangle{
        public double length;
        public double width;
        public double GetArea(){
            return length * width;
        }
        public void display(){
            Console.WriteLine("length = {0}", length);
            Console.WriteLine("width = {0}", width);
            Console.WriteLine("Area = {0}", GetArea());
        }
    }
    class Rectangle2{
        private double length;
        private double width;
        public Rectangle2(double length, double width){
            this.length = length;
            this.width = width;
        }
        public double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("length = {0}", length);
            Console.WriteLine("width = {0}", width);
            Console.WriteLine("Area = {0}", GetArea());
        }
    }
    class TestMethod{
        public int FindMax(int num1, int num2){
            return num1 > num2 ? num1 : num2;
        }
        // 递归调用
        public int Factorial(int num){
            if(num == 1) return 1;
            else return Factorial(num - 1) * num;
        }
        public void swap1(int x, int y){
            int tmp;
            tmp = y;
            y = x;
            x = tmp;
        }
        public void swap2(ref int x , ref int y){
            int tmp = y;
            y = x;
            x = tmp;
        }
        public void getValue(out int x){
            int tmp = 5;
            x = tmp;
        }
    }
    class Application{
        static void TestRectangle(){
            Rectangle r = new Rectangle();
            r.length = 1.2;
            r.width = 2.5;
            r.display();
        }
        static void TestRectangle2(){
            Rectangle2 r = new Rectangle2(2.5, 1.2);
            r.Display();
        }
        static void TestMethod1(){
            TestMethod tm = new TestMethod();
            Console.WriteLine("max:{0}",tm.FindMax(1,2));
        }
        static void TestMethod2(){
            TestMethod tm = new TestMethod();
            Console.WriteLine("Factorial:{0}",tm.Factorial(5));
        }
        static void TestMethod3(){
            TestMethod tm = new TestMethod();
            int x = 1;
            int y = 2;
            Console.WriteLine("x={0}, y = {1}", x, y);
            tm.swap1(x, y);
            Console.WriteLine("[swap1]x={0}, y = {1}", x, y);
            tm.swap2(ref x, ref y);
            Console.WriteLine("[swap2]x={0}, y = {1}", x, y);
        }
        static void TestMethod4(){
            TestMethod tm = new TestMethod();
            int x = 1;
            Console.WriteLine("x = {0}", x);
            tm.getValue(out x);
            Console.WriteLine("x = {0}", x);
        }
        static void Main(string[] args){
            Application.TestRectangle();
            Application.TestRectangle2();
            Application.TestMethod1();
            Application.TestMethod2();
            Application.TestMethod3();
            Application.TestMethod4();
        }
    }
}
