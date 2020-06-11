using System;
namespace DecisionMaking{
    class Program{
        static void Main(string[] args){
            char grade = 'B';
            switch(grade){
                case 'A':
                    Console.WriteLine("Very good!");
                    break;
                case 'B':
                case 'C':
                    Console.WriteLine("Good");
                    break;
                case 'D':
                    Console.WriteLine("Pass");
                    break;
                case 'F':
                    Console.WriteLine("Try again");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.WriteLine("Your score is {0}", grade);
        }
    }
}
