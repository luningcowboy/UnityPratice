using System;
namespace RectangleApplication{
    class Rectangle{
        private double width;
        private double length;

        public void Acceptdetails(){
            Console.WriteLine("请输入长度:");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入宽度:");
            width = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度: {0}", length);
            Console.WriteLine("宽度: {0}", width);
            Console.WriteLine("面积: {0}", GetArea());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }
}
