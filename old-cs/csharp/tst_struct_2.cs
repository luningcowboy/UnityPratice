using System;
using System.Text;

struct Books{
    private string title;
    private string author;
    private string subject;
    private int book_id;
    public void getValues(string t, string a, string s, int id){
        title = t;
        author = a;
        subject = s;
        book_id = id;
    }
    public void display(){
        Console.WriteLine("Title:{0}", title);
        Console.WriteLine("Author:{0}", author);
        Console.WriteLine("Subject:{0}", subject);
        Console.WriteLine("Book_id:{0}", book_id);
    }
};
public class TestStructure{
    public static void Main(string[] args){
        Books b1 = new Books();
        Books b2 = new Books();
        b1.getValues("C Programming", "Nuha Ali", "C Programming Tutorial", 6495407);
        b2.getValues("Telecom Billing", "Zara Ali", "Telecom Billing Tutorial", 6495700);
        b1.display();
        b2.display();
    }
}
