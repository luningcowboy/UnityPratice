using System;
namespace LogicOperatorAppl{
    class Program{
        static void Main(string[] args){
            bool a = true;
            bool b = true;

            if(a && b){
                Console.WriteLine("Line 1: 条件为真");
            }
            if(a || b){
                Console.WriteLine("Line 2: 条件为真");
            }
            a = false;
            b = true;
            if(a && b){
                Console.WriteLine("Line 3: 条件为真");
            }
            else{
                Console.WriteLine("Line 3: 条件不为真");
            }
            if(!(a && b)){
                Console.WriteLine("Line 4: 条件为真");
            }

        }
    }
}
