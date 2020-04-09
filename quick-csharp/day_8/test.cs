using System;
namespace TestArray{

    class App{
        static void TestArray(){
            int [][] a = new int[][]{
                new int[] {0, 0}, 
                new int[] {1, 2}, 
                new int[] {2, 4}, 
                new int[] {3, 6},
                new int[] {4, 8}
            };
            int i, j;
            for(i = 0; i < 5; i++){
                for(j = 0; j < 2; j++){
                    Console.WriteLine("a[{0}][{1}] = {2}", i, j, a[i][j]);
                }
            }
        }
        static void TestString(){
            string fname, lname;
            fname = "Rowan";
            lname = "Atkinson";

            string fullName = fname + lname;
            Console.WriteLine("FullName:{0}", fullName);

            char[] letters = {'H', 'e', 'l', 'l', 'o'};
            string greetings = new string(letters);
            Console.WriteLine("Greeting:{0}", letters);

            string[] sarr = {"hello", "From", "tutorial", "point"};
            string msg = String.Join(" ", sarr);
            Console.WriteLine("Message: {0}", msg);

            DateTime waiting = new DateTime(2020, 02, 02, 17, 17, 17);
            string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
            Console.WriteLine("Message: {0}", chat);
        }
        static void TestStringCompare(){
            /*
            1 ： str1大于str2
            0 ： str1等于str2
            -1 ： str1小于str2
            */
            int ret = String.Compare("abc","abc");
            Console.WriteLine("TestStringCompare:abc,abc = {0}", ret); // 0
            ret = String.Compare("abc","bbc");
            Console.WriteLine("TestStringCompare:abc,bbc = {0}", ret); // -1
            ret = String.Compare("abc","123");
            Console.WriteLine("TestStringCompare:abc,123 = {0}", ret); // 1
            ret = String.Compare("abc","abd");
            Console.WriteLine("TestStringCompare:abc,abd = {0}", ret); // -1
            ret = String.Compare("abc","ABC");
            Console.WriteLine("TestStringCompare:abc,ABC = {0}", ret); // -1
        }
        static void Main(string[] args){
            App.TestStringCompare();
        }
    }
}
