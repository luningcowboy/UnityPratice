using System;
namespace RectangleApplication{
    class Rectangle{
        double length;
        double width;
        public void Acceptdetails(){
            length = 4.5;
            width = 3.5;
        }
        public double getArea(){
            return length * width;
        }
        public void display(){
            Console.WriteLine("Length:{0}", this.length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area:{0}", getArea());
        }
    }

    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.display();
            Console.ReadLine();
        }
    }

}
