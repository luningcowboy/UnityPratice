using System;
namespace Test{
    struct Books{
        public string title;
        public string author;
        public string subject;
        public int book_id;
        public void setValues(string t, string a, string s, int id){
            title = t;
            author = a;
            subject = s;
            book_id = id;
        }
    };
    class App{
        static void TestFunc1(){
            Books book1;
            Books book2;

            book1.title = "C programming";
            book1.author = "Nuha Ali";
            book1.subject = "C Programming Tutorial";
            book1.book_id = 12345;

            book2.title = "Telecom Billing";
            book2.author = "Zara Ali";
            book2.subject = "Telecom Billing Tutorial";
            book2.book_id = 123456;

            Console.WriteLine("Book1 title:{0}",book1.title);
        }
        static void Main(string[] args){
            App.TestFunc1();
        }
    }
}
