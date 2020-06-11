using System;
namespace Program{
    public class Data{
        public Result result;
    }
    public class DataA : Data{
        public ResultA result;
    }

    public class Result{
        public int a = 0;
        public string b = "";
    }
    public class ResultA : Result{
        public int c = 0;
        public int b = 0;
    }

    class App{
        public static void Main(string[] args){
            Data d = new Data();
            Data a = new DataA();
            //Console.WriteLine(d.result.a);
            //Console.WriteLine(a.result.c);
        }
    }
}
