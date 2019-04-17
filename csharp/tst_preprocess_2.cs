#define DEBUG
#define VS_V10
using System;
public class Test{
    public static void Main(){
#if (DEBUG && !VC_V10)
        Console.WriteLine("DEBUG is defined");
#elif (!DEBUG && VC_V10)
        Console.WriteLine("VS_V10 is defined");
#elif (DEBUG && VC_V10)
        Console.WriteLine("DEBUG VS_V10 is defined");
#else
        Console.WriteLine("DEBUG VS_V10 is not defined");
#endif
    }
}
