using System;
namespace OperatorOvlApplication{
    class Box{
        private double length;
        private double breath;
        private double height;

        public double getVolume(){
            return length * breath * height;
        }
        public void setLength(double len){
            length = len;
        }
        public void setBreath(double bre){
            breath = bre;
        } 
        public void setHeight(double hei){
            height = hei;
        }
        public static Box operator+ (Box b, Box c){
            Box ret = new Box();
            ret.length = b.length + c.length;
            ret.height = b.height + c.height;
            ret.breath = b.breath + c.breath;
            return ret;
        }
    }
    class Tester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();
            double volume = 0;

            b1.setLength(6.0);
            b1.setBreath(7.0);
            b1.setHeight(5.0);
        
            b2.setLength(6.0);
            b2.setBreath(7.0);
            b2.setHeight(5.0);

            volume = b1.getVolume();
            Console.WriteLine("b1的面积:{0}", volume);
            
            volume = b2.getVolume();
            Console.WriteLine("b2的面积:{0}", volume);

            Box b3 = b1 + b2;
            volume = b3.getVolume();
            Console.WriteLine("b3的面积:{0}", volume);

        }
    }
}
