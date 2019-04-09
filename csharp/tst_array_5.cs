using System;
namespace ArrayApplication{
    class ParamArray{
        public int AddElements(params int[] arr){
            int sum = 0;
            foreach(int i in arr){
                sum += i;
            }
            return sum;
        }
    }
    class Test{
        static void Main(string[] args){
            ParamArray app = new ParamArray();
            int sum = app.AddElements(1,2,3,4,5);
            Console.WriteLine("sum:{0}",sum);
        }
    }
}
