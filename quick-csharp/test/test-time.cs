using System;
class Pragrom{
    public static string GetTimeStamp1(){
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }
    public static string GetTimeStamp2(){
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }
    static void Main(string[] args){
        Console.WriteLine(GetTimeStamp1());
        Console.WriteLine(GetTimeStamp2());
    }
}
