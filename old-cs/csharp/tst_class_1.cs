using System;
namespace BoxApplication{
    class Box{
        public double length;
        public double breadth;
        public double height;
    }
    class Boxtester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();
            double volume = 0.0;

            b1.height = 5.0;
            b1.length = 6.0;
            b1.breadth = 7.0;

            b2.height = 5.0;
            b2.length = 6.0;
            b2.breadth = 7.0;

            volume = b1.height * b1.length * b1.breadth;
            Console.WriteLine("Box1 的体积:{0}", volume);

            volume = b2.height * b2.length * b2.breadth;
            Console.WriteLine("Box1 的体积:{0}", volume);
        }
    }
}
