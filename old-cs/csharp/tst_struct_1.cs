using System;
using System.Text;

struct Books{
    public string title;
    public string author;
    public string subject;
    public int book_id;
};
public class TestStructure{
    public static void Main(string[] args){
        Books b1;
        Books b2;

        b1.title = "C Programming";
        b1.author = "Nuha Ali";
        b1.subject = "C Programming Tutorial";
        b1.book_id = 6495407;


        b2.title = "Telecom Billing";
        b2.author = "Zara Ali";
        b2.subject = "Telecom Billing Tutorial";
        b2.book_id = 6495700;

        /*打印b1信息*/
        Console.WriteLine("book1 title:{0}", b1.title);
        Console.WriteLine("book1 author:{0}", b1.author);
        Console.WriteLine("book1 subject:{0}", b1.subject);
        Console.WriteLine("book1 book_id:{0}", b1.book_id);
        
        /*打印b2信息*/
        Console.WriteLine("book2 title:{0}", b2.title);
        Console.WriteLine("book2 author:{0}", b2.author);
        Console.WriteLine("book2 subject:{0}", b2.subject);
        Console.WriteLine("book2 book_id:{0}", b2.book_id);
    }

}
