using System;
namespace OperatorOvlApplication{
    class Box{
        private double length;
        private double breath;
        private double height;

        public double getVolume(){
            return length * breath * height;
        }
        public void setHeight(double hei){
            height = hei;
        }
        public void setBreath(double bre){
            breath = bre;
        }
        public void setLength(double len){
            length = len;
        }
        public static Box operator+ (Box b, Box c){
            Box r = new Box();
            r.length = b.length + c.length;
            r.height = b.height + c.height;
            r.breath = b.breath + c.breath;
            return r;
        }
        public static bool operator == (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length == rhs.length && lhs.breath == rhs.breath && lhs.height == rhs.height){
                ret = true;
            }
            return ret;
        }
        public static  bool operator!= (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length != rhs.length || lhs.breath != rhs.breath || lhs.height != rhs.height){
                ret = true;
            }
            return ret;
        }
        public static  bool operator< (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length < rhs.length && lhs.breath < rhs.breath && lhs.height < rhs.height){
                ret = true;
            }
            return ret;
        }
        public static  bool operator> (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length > rhs.length && lhs.breath > rhs.breath && lhs.height > rhs.height){
                ret = true;
            }
            return ret;
        }
        public static  bool operator<= (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length <= rhs.length && lhs.breath <= rhs.breath && lhs.height <= rhs.height){
                ret = true;
            }
            return ret;
        }
        public static  bool operator >= (Box lhs, Box rhs){
            bool ret = false;
            if(lhs.length >= rhs.length && lhs.breath >= rhs.breath && lhs.height >= rhs.height){
                ret = true;
            }
            return ret;
        }
        public override string ToString(){
            return String.Format("({0}, {1}, {2})", length, breath, height);
        }
    }
    class Tester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();
            Box b3 = new Box();
            Box b4 = new Box();
            double v = 0;

            b1.setHeight(6.0);
            b1.setBreath(7.0);
            b1.setLength(5.0);


            b2.setHeight(6.0 * 2);
            b2.setBreath(7.0 * 2);
            b2.setLength(5.0 * 2);
            Console.WriteLine("B1:{0}", b1.ToString());
            Console.WriteLine("B2:{0}", b2.ToString());

            v = b1.getVolume();
            Console.WriteLine("B1 面积:{0}", v);

            v = b2.getVolume();
            Console.WriteLine("B2 面积:{0}", v);

            b3 = b1 + b2;
            Console.WriteLine("B3:{0}", b3.ToString());
            v = b3.getVolume();
            Console.WriteLine("B3 面积:{0}", v);

            b4 = b3;
            if(b4 == b3) Console.WriteLine("b4 == b3");
            else Console.WriteLine("b4 != b3");

            if (b1 > b2)
                Console.WriteLine("Box1 大于 Box2");
            else
                Console.WriteLine("Box1 不大于 Box2");
            if (b1 < b2)
                Console.WriteLine("Box1 小于 Box2");
            else
                Console.WriteLine("Box1 不小于 Box2");
            if (b1 >= b2)
                Console.WriteLine("Box1 大于等于 Box2");
            else
                Console.WriteLine("Box1 不大于等于 Box2");
            if (b1 <= b2)
                Console.WriteLine("Box1 小于等于 Box2");
            else
                Console.WriteLine("Box1 不小于等于 Box2");
            if (b1 != b2)
                Console.WriteLine("Box1 不等于 Box2");
            else
                Console.WriteLine("Box1 等于 Box2");
        }
    }
}
