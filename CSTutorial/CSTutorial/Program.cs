using System;
namespace TestPrograms {
    class Test { }
    class Test2 { }
    public class UnitConverter {
        int ratio;
        public UnitConverter(int unitRatio) {
            ratio = unitRatio;
        }
        public int Convert(int unit) {
            return unit * ratio;
        }
    }
}
namespace CSTutorial
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string msg = "Hello World";
            Console.WriteLine(msg);
            string upMsg = msg.ToUpper();
            Console.WriteLine(upMsg);
            int x = 2015;
            msg = msg + x.ToString();
            Console.WriteLine(msg);

            TestPrograms.UnitConverter feet = new TestPrograms.UnitConverter(12);
            TestPrograms.UnitConverter mile = new TestPrograms.UnitConverter(5280);
        }
    }
}
