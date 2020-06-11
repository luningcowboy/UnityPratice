using System;
namespace StringApplication{
    class Program{
        static void Main(string[] args){
            string fname, lname;
            fname = "Rowan";
            lname = "Atkinson";

            string fullname = fname + lname;;
            Console.WriteLine("Full Name:{0}", fullname);


            char[] letters = {'H','e','l','l','o'};
            string greetings = new string(letters);
            Console.WriteLine("Greeting:{0}", greetings);

            string[] sarray = {"Hello", "From", "Tutorials", "Point"};
            string message = String.Join(" ", sarray);
            Console.WriteLine("Message:{0}", message);

            DateTime waiting = new DateTime(2012, 10,10, 17, 58, 1);
            string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
            Console.WriteLine("Message:{0}", chat);
        }
    }
}
