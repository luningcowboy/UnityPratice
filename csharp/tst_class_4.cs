// 参数化构造函数
using System;
namespace LineApplication{
    class Line{
        private double length;
        public Line(double len){
            Console.WriteLine("对象已创建, length={0}", len);
            length = len;
        }
        public void setLength(double len){
            length = len;
        }
        public double getLength(){
            return length;
        }
        static void Main(string[] args){
            Line line = new Line(10.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
            line.setLength(6.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
        }
    }
}
