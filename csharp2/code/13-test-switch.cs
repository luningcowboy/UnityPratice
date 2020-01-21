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
}
