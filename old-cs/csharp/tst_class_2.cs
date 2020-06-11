using System;
namespace BoxApplication{
    class Box{
        private double length;
        private double breadth;
        private double height;
        public void setLength(double len){
            length = len;
        }
        public void setBreadth(double bre){
            breadth = bre;
        }
        public void setHeight(double hei){
            height = hei;
        }
        public double getVolume(){
            return length * breadth * height;
        }

    }
    class Boxtester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();

            b1.setLength(6.0);
            b1.setBreadth(7.0);
            b1.setHeight(5.0);

            b2.setLength(12.0);
            b2.setBreadth(13.0);
            b2.setHeight(10.0);

            Console.WriteLine("Box1的体积:{0}",b1.getVolume());
            Console.WriteLine("Box2的体积:{0}",b2.getVolume());
        }
    }
}
