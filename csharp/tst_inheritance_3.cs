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
    public interface PaintCost{
        int getCost(int area);
    }
    class Rectangle : Shape, PaintCost{
        public int getArea(){
            return width * height;
        }
        public int getCost(int area){
            return area * 70;
        }
    }
    class RectangleTester{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            int area;
            r.setWidth(5);
            r.setHeight(7);
            area = r.getArea();
            Console.WriteLine("总面积:{0}", r.getArea());
            Console.WriteLine("油漆总成本:{0}", r.getCost(area));
        }
    }
}
