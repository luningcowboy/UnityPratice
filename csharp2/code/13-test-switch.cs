using System;
class Test{
    static void Main(){
        TellMeTheType(12);
        TellMeTheType("hello");
        TellMeTheType(true);
    }
    static void TellMeTheType(object x){
        switch(x){
            case int i:
                Console.WriteLine("int ");
                break;
            case string str:
                Console.WriteLine(" string");
                break;
            default:
                Console.WriteLine("unkonwn type");
                break;
        }
    }
    static void SwitchTest(object x){
        switch(x){
            case float f when f > 1000:
            case double d when d > 1000:
            case decimal m when m > 1000:
                Console.WriteLine("We can refer to x here but not f or d or m");
                break;
        }
    }
}
