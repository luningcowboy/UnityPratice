using System;
class Test{
    static void split(string name, out string first, out string last){
        int i = name.LastIndexOf(' ');
        first = name.Substring(0, i);
        last = name.Substring(i + 1);
    }
    static void Main(){
        string a, b;
        split("Stevie Ray Vaughan", out a, out b);
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
