using System;
namespace InheritanceApplication{
    class Shape{
        public void setWidth(int w){
            width = w;
        }
        public void setHeight(int h){
            height = h;
        }
        protected int width;
        protected int height;
    }
    class Rectangle: Shape{
        public int getArea(){
            return (width * height);
        }
    }
    class RectangleTester{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.setWidth(5);
            r.setHeight(7);
            Console.WriteLine("总面积:{0}", r.getArea());
        }
    }
}
