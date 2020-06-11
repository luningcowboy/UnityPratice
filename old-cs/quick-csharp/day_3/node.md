## 常量
常量是固定值，程序执行期间不会改变
可以是任何基本数据类型,比如整型，浮点数，字符串，字符，枚举
### 字符串常量
放在双括号`""`或者`@""`中

### 定义常量
`const <dat_type> <constant_name> = value;`
```c#
using System;
namespace Test{
    class SampleClass{
        public int x;
        public int y;
        public const int c1 = 5;
        public const int c2 = c1 + 5;
        public SampleClass(int p1, int p2){
            x = p1;
            y = p2;
        }
    }
    class Application{
        static void TestSampleClass(){
            SampleClass mc = new SampleClass(11,22);
            Console.WriteLine("x={0},y = {1}", mc.x, mc.y);
            Console.WriteLine("c1 = {0}, c2 = {1}", SampleClass.c1, SampleClass.c2);
        }
        static void Main(string[] args){
            Console.WriteLine("Hello\tWorld\n\n");
            string a = "Hello,World";
            string b = @"Hello,World";
            string c = "Hello,\tWorld";
            string d = @"Hello,\tWorld";
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Application.TestSampleClass();
        }
    }
}
```
## 运算符
- 算术运算符
- 关系运算符
- 逻辑运算符
- 位运算符
- 赋值与算符
- 其他运算符
### 算术运算符
+, -, *, /, %, ++, --
