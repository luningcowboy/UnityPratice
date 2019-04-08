using System;
class Program{
    static void Main(string[] args){
        int a = 21;
        int b = 10;
        if(a == b){
            Console.WriteLine("Line 1 : a 等于 b");
        }
        else{
            Console.WriteLine("Line 1 : a 不等于 b");
        }
        if(a < b){
            Console.WriteLine("Line 2 : a 小于 b");
        }
        else{
            Console.WriteLine("Line 2 : a 不小于 b");
        }
        if(a > b){
            Console.WriteLine("Line 3 : a 大于 b");
        }
        else{
            Console.WriteLine("Line 3 : a 不大于 b");
        }

        a = 5;
        b = 21;
        if(a <= b){
            Console.WriteLine("Line 4: a 小于等于 b"); 
        }
        else{
            Console.WriteLine("Line 4: a 大于 b"); 
        }
        if(a >= b){
            Console.WriteLine("Line 5: a 大于等于 b"); 
        }
        else{
            Console.WriteLine("Line 5: a 小于 b"); 
        }
    }

}
