using System;
namespace RectangleApplication{
    class Rectangle{
        internal double length;
        internal double width;
        double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度:{0}", length);
            Console.WriteLine("宽度:{0}", width);
            Console.WriteLine("面积:{0}", GetArea());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }

}
