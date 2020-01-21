using System;
class Test{
    static void Main(){
        int i = 0;
        while(i < 3){
            Console.WriteLine(i);
            i++;
        }
        i = 0;
        do{
            Console.WriteLine(i);
            i++;
        }
        while(i < 3);
        for(int j = 0; j < 3; ++j) Console.WriteLine(j);
        foreach (char c in "bear") Console.WriteLine(c);
    }
}
