using System;
public class EnumTest{
    enum Day {Sun, Mon, Tue, Web, Thu, Fri, Sat};
    static void Main(){
        int x = (int)Day.Sun;
        int y = (int)Day.Fri;
        Console.WriteLine("Sum={0}", x);
        Console.WriteLine("Fri={0}", y);
    }
}
