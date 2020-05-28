using System;
using System.Text.RegularExpressions;

public class Example{
    public static void Main(){
        string pattern = "My name is {user}! 哈哈!😄";
        pattern = pattern.Replace("{user}", "Tom");
        Console.WriteLine(pattern);
    }
}
