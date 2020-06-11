using System;
using System.Text;
class Test{
    static void Main(){
        StringBuilder ref1 = new StringBuilder("object1");
        Console.WriteLine(ref1); // ref1 will eligible for GC

        StringBuilder ref2 = new StringBuilder("object2");
        StringBuilder ref3 = ref2;
        Console.WriteLine(ref2);
    }
}
