using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace Learning 
{
    public class LearnCSharp
    {
        public static void Syntax()
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("Integer:" + 10 +
                              "Double:" + 3.14 +
                              "Boolean" + true);
            Console.Write("Hello ");
            Console.Write("World");

            sbyte fooSbyte = 100;
            byte fooByte = 100;
            short fooShort = 10000;
            ushort fooUshort = 10000;
            int fooInt = 1;
            uint fooUint = 1;

            long fooLong = 1000000L;
            ulong fooUlong = 1000L;

            double fooDouble = 123.4; // 精度: 15-16
            float fooFloat = 234.5f; // 精度: 7位

            decimal fooDecimal = 150.3m; // decimal - 128-bits
            bool fooBoolean = true;

            char fooFar = 'A';

            string fooStr = "hello c sharp";
            Console.WriteLine(fooStr);

            char charFromStr = fooStr[0];

            string.Compare(fooStr, "X", StringComparison.CurrentCultureIgnoreCase);

            string fooFs = string.Format("Check Check ,{0} {1},{0} {1:0.1}", 1, 2);
            Console.WriteLine(fooFs);

            DateTime fooDate = DateTime.Now;
            Console.WriteLine(fooDate.ToString("hh:mm, dd MMM yyyy"));

        }

        public static void Main(string[] args)
        {
            LearnCSharp.Syntax();
        }

    }
}