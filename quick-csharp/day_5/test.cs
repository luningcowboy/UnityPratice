using System;

namespace Test{
    class TestGXOperate{
        public static void Test1(){
            int a = 21;
            int b = 10;
            if (a == b){
                Console.WriteLine("a == b");
            }
            else{
                Console.WriteLine("a != b");
            }
            if(a < b){
                Console.WriteLine("a < b");
            }
            else{
                Console.WriteLine("a >= b");
            }
            if(a > b){
                Console.WriteLine("a > b");
            }
            else{
                Console.WriteLine("a <= b");
            }
        }
        public static void Test2(){
            bool a = true;
            bool b = true;
            if(a && b){
                Console.WriteLine("a && b = true");
            }
            else{
                Console.WriteLine("a && b = false");
            }
            if(a || b){
                Console.WriteLine("a || b = true");
            }
            else{
                Console.WriteLine("a || b = true");
            }
            if(!(a && b)){
                Console.WriteLine("!(a&&b) = true");
            }
            else{
                Console.WriteLine("!(a&&b) = false");
            }
        }
        public static void Test3(){
            Console.WriteLine("int 的大小={0}",sizeof(int));
            Console.WriteLine("short 的大小={0}",sizeof(short));
            Console.WriteLine("double 的大小={0}",sizeof(double));

            int a, b;
            a = 10;
            b = (a == 1) ? 20 : 30;
            Console.WriteLine("b = {0}", b);

            b = (a == 10) ? 20 : 30;
            Console.WriteLine("b = {0}", b);
        }
        public static void Test4(){
            int a = 10;
            if(a < 20){
                Console.WriteLine("a 小于 20");
            }
            else{
                Console.WriteLine("a 大于 20");
            }
            Console.WriteLine("a = {0}", a);

            a = 100;
            int b = 200;
            if (a == 100){
                if(b == 200){
                    Console.WriteLine("a = 100, b= 200");
                }
            }
        }
        public static void Test5(){
            char grade = 'B';
            switch (grade){
                case 'A':
                    Console.WriteLine("A");
                    break;
                case 'B':
                case 'C':
                    Console.WriteLine("B/C");
                    break;
                case 'D':
                    Console.WriteLine("D");
                    break;
                case 'F':
                    Console.WriteLine("F");
                    break;
                default:
                    Console.WriteLine("无效");
                    break;
            }
        }
        public static void Test6(){
            int a = 100;
            int b = 200;
            switch(a){
                case 100:
                    Console.WriteLine("switch 1");
                    switch(b){
                        case 200:
                            Console.WriteLine("switch 2");
                            break;
                    }
                    break;
            }
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
        public static void Test7(){
            int a = 10;
            while(a < 20){
                Console.WriteLine("while loop a = {0}", a);
                a++;
            }
        }
        public static void Test8(){
            for(int a = 10; a < 20; a = a + 1){
                Console.WriteLine("for==>{0}",a);
            }
        }
        public static void Test9(){
            int a = 10;
            do{
                Console.WriteLine("do while ==>{0}", a);
                a = a + 1;
            }while(a < 20);
        }
        public static void Test10(){
            int i, j;
            for (i = 2; i < 100; i++){
                for(j = 2; j <= (i / j); j++){
                    if((i % j) == 0) break;
                }
                if(j > (i / j))
                    Console.WriteLine("{0} 是质数", i);
            }
        }
    }
    class Application{
        static void Main(string[] args){
            TestGXOperate.Test1();
            TestGXOperate.Test2();
            TestGXOperate.Test3();
            TestGXOperate.Test4();
            TestGXOperate.Test5();
            TestGXOperate.Test6();
            TestGXOperate.Test7();
            TestGXOperate.Test8();
            TestGXOperate.Test9();
            TestGXOperate.Test10();
        }
    }
}
