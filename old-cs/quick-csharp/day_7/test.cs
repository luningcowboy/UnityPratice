using System;
namespace Test{
    class TestArray{
        static void Test1(){
            int[] n = new int[10];
            int i, j;
            for(i = 0; i < 10; i++){
                n[i] = i + 100;
            }
            for(j = 0; j < 10; j++){
                Console.WriteLine("Elem:{0}={1}",j, n[j]);
            }
        }
        static void TestForeach(){
            int[] n = new int[10];
            for(int i = 0; i < 10; i++) n[i] = i + 100;
            foreach(int j in n){
                int i = j - 100;
                Console.WriteLine("Elem:{0}={1}", i, j);
            }
        }
        static void Test2(){
            int[,] a = new int[5,2]{{0,1},{1,2},{2,3},{3,4},{4,5}};
            int i, j;
            for(i = 0; i < 5; i++){
                for(j = 0; j < 2; j++){
                    Console.WriteLine("a[{0},{1}] = {2}", i, j, a[i,j]);
                }
            }
        }
        public static void runTest(){
            TestArray.Test1();
            TestArray.TestForeach();
            TestArray.Test2();
        }
    }
    class App{
        static void Test1(){
            int? n1 = null;
            int? n2 = 45;
            Nullable<int> i = new Nullable<int>(3);
            double? n3 = new double?();
            double? n4 = 3.1415;
            bool? b1 = new bool?();

            Console.WriteLine("{0},{1},{2},{3}", n1,n2,n3,n4);
            Console.WriteLine("bool{0}", b1);
        }
        static void Test2(){
            double? n1 = null;
            double? n2 = 3.14;
            double n3;
            n3 = n1 ?? 1.22;
            Console.WriteLine("n3 = {0}", n3);
            n3 = n2 ?? 1.1112;
            Console.WriteLine("n3 = {0}", n3);
        }
        static void Main(string[]args){
            App.Test1();
            App.Test2();
            TestArray.runTest();
        }
    }
}
