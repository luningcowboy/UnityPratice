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
    public class Bicycle{
        public int Cadence{
            get{
                return _cadence;
            }
            set{
                _cadence = value;
            }
        }
        private int _cadence;

        protected virtual int Gear{
            get;
            set;
        }

        internal int Wheels{
            get;
            private set;
        }

        int _speed; // 默认 private
        public string Name {get; set;}

        public enum BikeBrand{
            AIST,
            BMC,
            Electra = 42,
            Gitane
        }

        public BikeBrand Brand;

        static public int BicyclesCreated = 0;
        readonly bool _hasCardsInSpokes = false;

        public Bicycle()
        {
            this.Gear = 1;
            Cadence = 50;
            _speed = 5;
            Name = "Bontrager";
            Brand = BikeBrand.AIST;
            BicyclesCreated++;
        }

        public Bicycle(
                int startCadence,
                int startSpeed,
                int startGear,
                string name,
                bool hasCardsInSpokes,
                BikeBrand brand):base() // 首先调用base
        {
            Gear = startGear;
            Cadence = startCadence;
            _speed = startSpeed;
            Name = name;
            _hasCardsInSpokes = hasCardsInSpokes;
            Brand = brand;
        }

        public Bicycle(int startCadence, int startSpeed, BikeBrand brand):this(startCadence, startSpeed, 0, "big wheels", true, brand)
        {
        }

        public void SpeedUp(int increment = 1)
        {
            _speed += increment;
        }

        public void SlowDown(int decrement = 1){
            _speed -= decrement;
        }

        private bool _hasTassles;
        public bool HasTassles
        {
            get {return _hasTassles;}
            set {_hasTassles = value;}
        }

        public bool IsBroken {get; private set;}

        public int FrameSize{
            get;
            private set;
        }

        public virtual string Info(){
            return "Gear: " + Gear +
                " Cadence:" + Cadence +
                " Speed: " + _speed +
                " Name: " + Name +
                " Cards in Spokes: " + (_hasTassles ? "yes" : "no") +
                "\n---------------------------\n";
        }

        public static bool DidWeCreateEnoughBycles(){
            return BicyclesCreated > 9000;
        }


    }
    public class PennyFarthing : Bicycle{
        public PennyFarthing(int startCadence, int startSpeed):
            base(startCadence, startSpeed, 0, "PennyFarthing", true, BikeBrand.Electra)
        {
        }

        protected override int Gear
        {
            get
            {
                return 0;
            }
            set
            {

                //throw new ArgumentException("");
            }
        }
        public override string Info(){
            string result = "PennyFarthing bicycle";
            result += base.ToString();
            return result;
        }

    }
    public static class Extensions{
        public static void Print(this object obj){
            Console.WriteLine(obj.ToString());
        }
    }
    interface IJumpable{
        void Jump(int meters);
    }

    interface IBreakable{
        bool Broken{get;}
    }

    public class TmpClass : IJumpable, IBreakable{
        int damage = 0;
        public void Jump(int meters)
        {
            damage += meters;
        }
        public bool Broken
        {
            get
            {
                return damage > 100;
            }
        }
    }
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

            string bazString = @"Here's some stuff
                on a new ling: ""Wow"" , the messes cried";
            Console.WriteLine(bazString);

            const int HOURS_I_WOrK_PER_WEEK = 9001;

            int[] intArray = new int[10];
            int[] y = {1, 2, 3};
            Console.WriteLine("intArray @ 0:" + intArray[1]);
            Console.WriteLine("intArray @ 0:" + y[1]);

            // List<type> <var_name> = new List<type>();
            List<int> intList = new List<int>();
            List<string> strList = new List<string>();
            List<int> z = new List<int>{1,2,3,4};

            intList.Add(100);

            Console.WriteLine("intList @ 0:" + intList[0]);

            int j = 10;
            if (j == 10){
                Console.WriteLine("I get printed");
            }
            else if(j > 10){
                Console.WriteLine("J > 10");
            }
            else{
                Console.WriteLine("J = 10");
            }

            int toCompare = 17;
            string isTrue = toCompare == 12 ? "True" : "False";

            int fooWhile = 0;
            while(fooWhile < 100){
                fooWhile++;
            }

            int fooDoWhile = 0;
            do{
                fooDoWhile++;
            }while(fooWhile < 100);

            for(int fooFor = 0; fooFor < 10; fooFor++){
            }

            foreach(char c in "Hello World".ToCharArray()){
                Console.WriteLine(c);
            }

            int month = 3;
            string monthStr;
            switch(month){
                case 1:
                    monthStr = "January";
                    break;
                case 2:
                    monthStr = "February";
                    break;
                case 3:
                    monthStr = "March";
                    break;
                case 6:
                case 7:
                case 8:
                    monthStr = "Some Time";
                    break;
                default:
                    monthStr = "Some other month";
                    break;
            }
            Console.WriteLine(monthStr);

            int.Parse("123");
            int tryInt;
            if(int.TryParse("123", out tryInt)){
                Console.WriteLine(tryInt);
            }

            Convert.ToString(123);
            tryInt.ToString();



        }
        public static void Classes(){
            Bicycle trek = new Bicycle();
            trek.SpeedUp(3);
            trek.Cadence = 10;
            Console.WriteLine("trek info:" + trek.Info());

            PennyFarthing funbike = new PennyFarthing(1, 10);
            Console.WriteLine("funbike info:" + funbike.Info());
        }

        public static void MethodSignature(
                int max,  // 正常的参数
                int count = 1,  // 有默认值的参数
                int another = 3,
                params string[] otherParams) // 捕获其他参数
        {
        }
        public static int MethodSignature(string maxCount)
        {
        }

        public static TValue SetDefault<TKey, TValue>(
                IDictionary<TKey, TValue> dic,
                TKey key,
                TValue v
                )
        {
            TValue ret;
            if(!dic.TryGetValue(key, out ret))
                return dic[key] = v;
            return ret;
        }

        public static void IterateAndPrint<T>(T toPoint) where T:IEnumerable<int>
        {
            foreach(var item in toPoint){
                Console.WriteLine(item.ToString());
            }
        }
        public static void OtherFeat()
        {
            MethodSignature(3, 1, 3, "Some", "Extra", "Strings");
            MethodSignature(3, another: 3); // 显式指定参数，忽略可选参数

            int i = 3;
            i.Print();

            int? nullable = null; // Nullable<int> 的简写形式
            Console.WriteLine("Nullable variable: " + nullable);
            bool hasValue = nullable.HasValue;
            int notNullable = nullable ?? 0;

            var magic = "编译器确定magic式一个字符串";

            var phonebook = new Dictionary<string, string>(){
                {"Sarah", "212 555 5555"}
            };

            Console.WriteLine(SetDefault<string, string>(phonebook, "Shaun", "No Phone"));
            Console.WriteLine(SetDefault(phonebook, "Sarah", "No Phone"));

            Func<int, int> square = (x)=> x * x;
            Console.WriteLine(square(3));

            using (StreamWriter writer = new StreamWriter("log.txt"))
            {
                writer.WriteLine("test test");
            }

            var websites = new string[]{
                "www.baidu.com",
                    "www.sina.com",
                    "www.google.com"
            };
            var response = new Dictionary<string, string>();

            dynamic student = new ExpandoObject();
            student.FirstName = "First Name";
            student.Introduce = new Fuc<string, string>(
                    (introduceTo)=>string.Format("Hey {0}, this is {1}", student.FirstName, introduceTo));
            Console.WriteLine(student.Introduce("Beth"));

            var bikes = new List<Bicycle>();
            bikes.Sort();
            bikes.Sort((b1, b2)=> b1.Wheels.CompareTo(b2.Wheels));
            var result = bikes
                .Where((b) => b.Wheels > 3)
                .Where((b) => b.IsBroken && b.HasTassles)
                .Select((b) => b.ToString());

            var sum = bikes.Sum((b) => b.Wheels);

            var bikeSummaries = bikes.Select(b=>new {Name = b.name, IsAwesome = !b.IsBroken && b.HasTassles});
            foreach(var bikeSummary in bikeSummaries.Where(b=>b.IsAwesome))
                Console.WriteLine(bikeSummary.Name);
        }

        public static void Main(string[] args)
        {
            LearnCSharp.Syntax();
            LearnCSharp.Classes();
        }

    }
}
