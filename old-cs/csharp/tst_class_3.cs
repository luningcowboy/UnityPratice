using System;
namespace LineApplication{
    class Line{
        private double length;
        public Line(){
            Console.WriteLine("对象已创建");
        }
        public void setLength(double len){
            length = len;
        }
        public double getLength(){
            return length;
        }
        static void Main(string[] args){
            Line line = new Line();
            line.setLength(6.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
        }
    }
}
