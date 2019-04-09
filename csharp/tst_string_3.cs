using System;
namespace StringApplication{
    class StringProg{
        static void Main(string[] args){
            string str = "This is Test.";
            if(str.Contains("Test")){
                Console.WriteLine("This sequence 'test' was found.");
            }
        }
    }
}
