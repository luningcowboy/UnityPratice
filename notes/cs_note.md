[TOC]
## 1.HelloWorld

```cs
using System;

namespace ConsoleApplication1{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hello,World!");
            Console.ReadLine();
        }
    }
}

```
运行:
csc helloworld.cs 编译生成helloworld.exe
mono helloworld.exe 执行helloworld.exe

分析:
- `using System;` 任何cs程序的第一行都是这句话，用来包含System名称空间,`using`关键字后面跟的应该是要倒入的名称空间.
- `namespace ConsoleApplication1` 声明一个名称空间，名称空间中通常包含了许多类
- `class Program` 声明一个类
-  `static void Main(string[] args)` 定义入口函数
-  `Console.WriteLine` 输出一句话
-  `Console.ReadLine` 等待输入

## 2.基本语法
```cs
using System;
namespace RectangleApplication{
    class Rectangle{
        double length;
        double width;
        public void Acceptdetails(){
            length = 4.5;
            width = 3.5;
        }
        public double getArea(){
            return length * width;
        }
        public void display(){
            Console.WriteLine("Length:{0}", this.length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area:{0}", getArea());
        }
    }

    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.display();
            Console.ReadLine();
        }
    }

}

```
需要注意的问题:
1. 关于命名: 一定要做好变量名称的区分，区分好属性方法，代码块局部变量，常量等
2. 类的属性可以通过`this`调用到
3. 类的实例化`new`
4. 定义方法注意`public private protected`, 做好封装

## 3.数据类型

分类:
- 值类型(Vlaue types)
- 引用类型(Reference types)
- 指针类型(Pointer types)

### 值类型
可以直接分配一个值，从System.ValueType派生.
| 类型 |描述  |范围  |默认值  |
| --- | --- | --- | --- |
|  bool|布尔  |True/False  |False  |
| byte |8位无符号  |[0,255]  | 0  |
| char |16位Unicode字符  |U+0000 到U+ffff  |'\0'  |
| decimal | 128位精确到十进制,28-29有效位数 |  |  |
| double | | | |
| float | | | |
| int | | | |
| long | | | |
| sbyte | | | |
| short | | | |
| uint | | | |
| ulong | | | |
| ushort | | | |

获取尺寸:
```cs
using System;
namespace GetDataSizeApplication{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("size of int {0}", sizeof(int));
        
        }
    
    }

}

```

### 引用类型
不包含存储在变量中的实际数据，包含对变量的引用。
它们指的是一个内存位置，使用多个变量的时候，引用类型可以指向一个内存位置。
内置的引用类型:object, dynamic, string
#### String
```cs
String str = "test string";
// 逐字字符串
String str = @"test string";
```
逐字字符串将转义字符(\)当作普通字符对待，比如:
```cs
string str = @"C:\Windows";
string str = "C:\\Windows";
```
#### 指针类型
```cs
type * identifier;
char* cptr;
int* iptr;
```
## 4. 类型转换
- 隐式类型转换:以安全的方式进行转换，不会导致数据丢失
- 显式类型转换:即强制类型转换，需要强制转换运算符，而强制转换会造成数据丢失

强制类型转换:
```cs
using System;
namespace TypeConversionApplication{
    class ExplicitConversion{
        static void Main(string[] args){
            double d = 5763.74;
            int i ;
            i = (int)d;
            Console.WriteLine(i);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
```
转换为字符串:
```cs
using System;
namespace TypeConversionApplication{
    class StringConversion{
        static void Main(string[] args){
            int i = 75;
            float f = 53.005f;
            double d = 2345.6543;
            bool b = true;

            Console.WriteLine(i.ToString());
            Console.WriteLine(f.ToString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(b.ToString());
            Console.ReadKey();
        }
    }
}
```
## 5.变量
定义变量:`data_type variable_list`
```cs
int d = 3, f = 5;
byte z = 22;
double pi = 3.14;
char x = 'x';
```
变量声明测试:
```cs
using System;
namespace VariableDefinition{
    class Program{
        static void Main(string[] args){
            short a;
            int b ;
            double c;

            a = 10;
            b = 20;
            c = a + b;
            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
            Console.ReadLine();
        }
    
    }

}

```
接受用户输入的值:
```cs
using System;

namespace TestGetVale{
    class Param{
        static void Main(string[] args){
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input={0}", num);
        }
    
    }

}
```
## 6.常量
定义常量:`const data_type constant_name = value;`

常量定义测试代码:
```cs
using System;
namespace DefineConstValue{
    public class ConstTest{
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
        static void Main(){
            SampleClass mC = new SampleClass(11, 22);
            Console.WriteLine("x={0}, y = {1}", mC.x, mC.y);
            Console.WriteLine("c1={0}, c2 = {1}", SampleClass.c1, SampleClass.c2);
        }
    }
}
```
## 7.运算符
```cs
using System;
namespace OperatorsAppl{
    class Program{
        static void Main(string[] args){
            int a = 21;
            int b = 10;
            int c;

            c = a + b;
            Console.WriteLine("Line 1 - c = {0}", c);
            c = a - b;
            Console.WriteLine("Line 2 - c = {0}", c);
            c = a * b;
            Console.WriteLine("Line 3 - c = {0}", c);
            c = a / b;
            Console.WriteLine("Line 4 - c = {0}", c);
            c = a % b;
            Console.WriteLine("Line 5 - c = {0}", c);
            c = ++a;
            Console.WriteLine("Line 6 - c = {0}", c);
            c = --a;
            Console.WriteLine("Line 7 - c = {0}", c);
            Console.ReadLine();
        }
    
    }
}
```

自加自减代码测试:
```cs
using System;
namespace OperatorAppl{
    class Program{
        static void Main(string[] args){
            int a = 1;
            int b;
            
            b = a++;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

            a = 1;
            b = ++a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();
        
            a = 1;
            b = a--;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

            a = 1;
            b = --a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.ReadLine();

        }
    
    }

}

```
### 关系运算符
```cs
using System;
class Program{
    static void Main(string[] args){
        int a = 21;
        int b = 10;
        if(a == b){
            Console.WriteLine("Line 1 : a 等于 b");
        }
        else{
            Console.WriteLine("Line 1 : a 不等于 b");
        }
        if(a < b){
            Console.WriteLine("Line 2 : a 小于 b");
        }
        else{
            Console.WriteLine("Line 2 : a 不小于 b");
        }
        if(a > b){
            Console.WriteLine("Line 3 : a 大于 b");
        }
        else{
            Console.WriteLine("Line 3 : a 不大于 b");
        }

        a = 5;
        b = 21;
        if(a <= b){
            Console.WriteLine("Line 4: a 小于等于 b"); 
        }
        else{
            Console.WriteLine("Line 4: a 大于 b"); 
        }
        if(a >= b){
            Console.WriteLine("Line 5: a 大于等于 b"); 
        }
        else{
            Console.WriteLine("Line 5: a 小于 b"); 
        }
    }

}

```
### 逻辑运算符
```cs
using System;
namespace LogicOperatorAppl{
    class Program{
        static void Main(string[] args){
            bool a = true;
            bool b = true;

            if(a && b){
                Console.WriteLine("Line 1: 条件为真");
            }
            if(a || b){
                Console.WriteLine("Line 2: 条件为真");
            }
            a = false;
            b = true;
            if(a && b){
                Console.WriteLine("Line 3: 条件为真");
            }
            else{
                Console.WriteLine("Line 3: 条件不为真");
            }
            if(!(a && b)){
                Console.WriteLine("Line 4: 条件为真");
            }

        }
    }
}

```
### 位运算符
```cs
using System;
namespace OperatorsAppl{
    class Program{
        static void Main(string[] args){
            int a = 60;
            int b = 13;
            int c = 0;
            c = a & b;
            Console.WriteLine("Line 1 : c = {0}", c);
            c = a | b;
            Console.WriteLine("Line 2 : c = {0}", c);
            c = a ^ b;
            Console.WriteLine("Line 3 : c = {0}", c);
            c = ~a;
            Console.WriteLine("Line 4 : c = {0}", c);
            c = a << 2;
            Console.WriteLine("Line 5 : c = {0}", c);
            c = a >> 2;
            Console.WriteLine("Line 6 : c = {0}", c);
            Console.ReadLine();
        }
    }
}
```
## 8.判断
if
```cs
using System;
namespace DecisionMaking{
    class Program{
        static void Main(string[] args){
            int a = 10;
            if(a < 20){
                Console.WriteLine("a 小于 20");
            }
            Console.WriteLine("a = {0}", a);
        }
    }
}
```
switch
```cs
using System;
namespace DecisionMaking{
    class Program{
        static void Main(string[] args){
            char grade = 'B';
            switch(grade){
                case 'A':
                    Console.WriteLine("Very good!");
                    break;
                case 'B':
                case 'C':
                    Console.WriteLine("Good");
                    break;
                case 'D':
                    Console.WriteLine("Pass");
                    break;
                case 'F':
                    Console.WriteLine("Try again");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.WriteLine("Your score is {0}", grade);
        }
    }
}

```
## 9.循环
### while
```cs
using System;
namespace LoopWhile{
    class Program{
        static void Main(string[] args){
            int a = 10;
            while(a < 20){
                Console.WriteLine("a = {0}", a);
                a++;
            }

        }
    }
}
```
### for
```cs
using System;
namespace LoopFor{
    class Program{
        static void Main(string[] args){
            for(int i = 0; i < 10; ++i){
                Console.WriteLine("i = {0}", i);
            }
        }
    }
}

```
### foreach
```cs
using System;
namespace LoopForeach{
    class Program{
        static void Main(string[] args){
            int[] arr = new int[]{0,1,2,3,4,5,6};
            foreach(int ele in arr){
                Console.WriteLine("ele is {0}", ele);
            }
        }
    }
}

```
```cs
using System;
namespace LoopForeach{
    class Program{
        static void Main(string[] args){
            int[] arr = new int[]{0,1,2,3,4,5,6};
            foreach(int ele in arr){
                Console.WriteLine("ele is {0}", ele);
            }
            Console.WriteLine();
            for(int i = 0; i < arr.Length; i++){
                Console.WriteLine("ele is {0}", arr[i]);
            }
            int count = 0;
            foreach(int ele in arr){
                count += 1;
                Console.WriteLine("Element #{0}:{1}", count, ele);
            }
            Console.WriteLine("Element #{0}", count);
        }
    }
}

```
### 嵌套循环
```cs
using System;
namespace Loops{
    class Program{
        static void Main(string[] args){
            int i, j;
            for(i = 2; i < 100; ++i){
                for(j = 2; j < (i / j); ++j){
                    if((i % j) == 0) break;
                }
                if(j > (i / j)){
                    Console.WriteLine("{0}是质数", i);
                }
            }
        }
    }
}

```
## 10.封装
把一个活多个项目封闭在一个物理或逻辑的包中。
- public 所有对象都可以访问
- private 对象本身在对象内部可以访问
- protected 只有该类及其子类对象可以访问
- internal 同一个程序集的对象可以访问
- protected internal 访问限于当前程序集货或派生自包含类的类型
### public
```cs
using System;
namespace RectangleApplication{
    class Rectangle{
        public double length;
        public double width;
        public double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度: {0}", length);
            Console.WriteLine("宽度: {0}", width);
            Console.WriteLine("面积: {0}", GetArea());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }
}

```
### private
```cs
using System;
namespace RectangleApplication{
    class Rectangle{
        private double width;
        private double length;

        public void Acceptdetails(){
            Console.WriteLine("请输入长度:");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入宽度:");
            width = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度: {0}", length);
            Console.WriteLine("宽度: {0}", width);
            Console.WriteLine("面积: {0}", GetArea());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }
}

```

### Internal
```cs
using System;
namespace RectangleApplication{
    class Rectangle{
        internal double length;
        internal double width;
        double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度:{0}", length);
            Console.WriteLine("宽度:{0}", width);
            Console.WriteLine("面积:{0}", GetArea());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }

}

```
## 11.方法
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int FindMax(int num1, int num2){
            int ret;
            if(num1 > num2) ret = num1;
            else ret = num2;
            return ret;

        }
        static void Main(string[] args){
            int a = 100;
            int b = 200;
            int ret;
            NumberManipulator n = new NumberManipulator();
            ret = n.FindMax(a, b);
            Console.WriteLine("最大值是:{0}", ret);
        }
    }
}

```
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int FindMax(int n1, int n2){
            int ret;
            ret = n1 > n2 ? n1 : n2;
            return ret;
        }
    }
    class Test{
        static void Main(string[] args){
            int a = 100;
            int b = 200;
            int ret;
            NumberManipulator n = new NumberManipulator();
            ret = n.FindMax(a, b);
            Console.WriteLine("最大值是:{0}", ret);
        
        }
    }
}

```
### 递归方法调用
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public int factorail(int num){
            int ret;
            if(num == 1) return 1;
            else{
                ret = factorail(num - 1) * num;
                return ret;
            }
        }
        static void Main(string [] args){
            NumberManipulator n = new NumberManipulator();
            Console.WriteLine("6 的阶乘是: {0}", n.factorail(6));
            Console.WriteLine("7 的阶乘是: {0}", n.factorail(7));
            Console.WriteLine("8 的阶乘是: {0}", n.factorail(8));
        }
    }
}
```
### 按值传递参数
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public void swap(int x, int y){
            int tmp;
            tmp = x;
            x = y;
            y = tmp;
        }
        static void Main(string[] args){
            NumberManipulator n = new NumberManipulator();
            int a = 100;
            int b = 200;
            Console.WriteLine("在交换之前,a={0}", a);
            Console.WriteLine("在交换之前,b={0}", b);

            n.swap(a, b);
            Console.WriteLine("在交换之前,a={0}", a);
            Console.WriteLine("在交换之前,b={0}", b);

            Console.ReadLine();
        }
    }
}

```

### 按引用传递参数
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public void swap(ref int x, ref int y){
            int tmp;
            tmp = x;
            x = y;
            y = tmp;
        }
        static void Main(string[] args){
            NumberManipulator n = new NumberManipulator();
            int a = 100;
            int b = 200;
            Console.WriteLine("在交换之前，a的值:{0}", a);
            Console.WriteLine("在交换之前，b的值:{0}", b);
            n.swap(ref a, ref b);
            Console.WriteLine("在交换之前，a的值:{0}", a);
            Console.WriteLine("在交换之前，b的值:{0}", b);
        }
    }

}
```
### 按输出传递参数
```cs
using System;
namespace CalculatorApplication{
    class NumberManipulator{
        public void getValue(out int x){
            int tmp = 5;
            x = tmp;
        }
        static void Main(string[] args){
            NumberManipulator n = new NumberManipulator();
            int a = 100;
            Console.WriteLine("在方法调用之前， a = {0}", a);
            n.getValue(out a);
            Console.WriteLine("在方法调用之后， a = {0}", a);

        }
    }
}
```
```cs
using System;
namespace CalculaorApplication{
    class NumberMainpulator{
        public void getValues(out int x, out int y){
            Console.WriteLine("Please input first number:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input second number:");
            y = Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args){
            NumberMainpulator n = new NumberMainpulator();
            int a, b;
            n.getValues(out a, out b);
            Console.WriteLine("在方法调用之后，a的值:{0}", a);
            Console.WriteLine("在方法调用之后，b的值:{0}", b);
        }
    }
}

```
## 12.可空类型(Nullable)
```cs
using System;
namespace CalculatorApplication{
    class NullablesAtShow{
        static void Main(string[] args){
            int? n1 = null;
            int? n2 = 45;
            double? n3 = new double?();
            double? n4 = 3.14;
            bool? boolval = new bool?();

            Console.WriteLine("显示可空类型:{0}, {1}, {2}, {3}", n1, n2, n3, n4);
            Console.WriteLine("一个可空的布尔值:{0}", boolval);
        }
    
    }

}
```
### Null合并运算符
Null 合并运算符用于定义可空类型和引用类型的默认值。Null 合并运算符为类型转换定义了一个预设值，以防可空类型的值为 Null。Null 合并运算符把操作数类型隐式转换为另一个可空（或不可空）的值类型的操作数的类型。

如果第一个操作数的值为 null，则运算符返回第二个操作数的值，否则返回第一个操作数的值。
```cs
using System;
namespace CalculatorApplication{
    class NullablesAtShow{
        static void Main(string[] args){
            double? n1 = null;
            double? n2 = 3.14;
            double n3;
            n3 = n1 ?? 5.34;
            Console.WriteLine("num3 = {0}", n3);
            n3 = n2 ?? 5.34;
            Console.WriteLine("num3 = {0}", n3);

        
        }
    }
}

```
## 13.数组
声明数组: `datatype[] arrayName;`
初始化数组: `datatype[] arrayName = new datatype[length];`
赋值给数组: `datatype[] arrayName = {};`
```cs
double[] balance = new double[10];
balance[0] = 3.14;
```
```cs
using System;
namespace ArrayApplication{
    class MyArray{
        static void Main(string[] args){
            int[] n = new int[10];
            int i, j;
            for(i = 0; i < 10; ++i) n[i] = i + 100;
            for(j = 0; j < 10; ++j) Console.WriteLine("Elemennt[{0}] = {1}", j, n[j]);
            Console.ReadKey();
        }
    }
}

```
### 多维数组
```cs
using System;
namespace TestArray{
    class Program{
        static void Main(string[] args){
            // 二维数组
            int[,] arr = new int[3,4]{
                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11}
            };
            Console.WriteLine("0,1 {0}", arr[0,1]);
            int [,] arr2 = new int[5,2]{
                {0,0},
                {1,2},
                {2,4},
                {3,6},
                {4,8},
            };
            for(int i = 0; i < 5; ++i){
                for(int j = 0; j < 2; ++j){
                    Console.WriteLine("arr2[{0},{1}] = {2}", i, j, arr2[i, j]);
                }
            }
            // 三维数组
            double [,,] arr3 = new double[3,3,3]{
                {
                    {1.0,1.1,1.2},
                    {2.0,2.1,2.2},
                    {3.0,3.1,3.2}
                },
                {
                    {4.0,4.1,4.2},
                    {5.0,5.1,5.2},
                    {6.0,6.1,6.2}
                },
                {
                    {7.0,7.1,7.2},
                    {8.0,8.1,8.2},
                    {9.0,9.1,9.2}
                }
            };
            Console.WriteLine("arr3[{0},{1},{2}] = {3}", 1,1,1, arr3[1,1,1]);
        }
    }
}


```
### 交错数组
```cs
// 交错数组
using System;
namespace ArrayApplication{
    class MyArray{
        static void Main(string[] args){
            int [][] a = new int[][]{
                new int[]{0,0},
                new int[]{1,2},
                new int[]{3,4,5}
            };
            for(int i = 0; i < a.Length; ++i){
                for(int j = 0; j < a[i].Length; ++j){
                    Console.WriteLine("a[{0}][{1}]={2}", i, j, a[i][j]);
                    // 这样输出会报错，交错数组跟正常数组是不一样的
                    Console.WriteLine("a[{0},{1}]={2}", i, j, a[i,j]);
                }
            }
        }
    }
}

```
### 传递数组给函数
```cs
using System;
namespace ArrayApplication{
    class MyArray{
        double getAverage(int[] arr, int size){
            int i;
            double avg;
            int sum = 0;
            for(i = 0; i < size; ++i){
                sum += arr[i];
            }
            avg = (double) sum / size;
            return avg;
        }
        static void Main(string[] args){
            MyArray app = new MyArray();
            int [] balance = new int[]{1000,2,3, 17, 50};
            double avg;
            avg = app.getAverage(balance, 5);
            Console.WriteLine("平均值:{0}", avg);
        }
    }
}

```
### 参数数组
接收的时候会把参数整理成数组，但是传入的时候并不是以数组的形式传入的。
```cs
using System;
namespace ArrayApplication{
    class ParamArray{
        public int AddElements(params int[] arr){
            int sum = 0;
            foreach(int i in arr){
                sum += i;
            }
            return sum;
        }
    }
    class Test{
        static void Main(string[] args){
            ParamArray app = new ParamArray();
            int sum = app.AddElements(1,2,3,4,5);
            Console.WriteLine("sum:{0}",sum);
        }
    }
}

```
### Array类
```cs
/// Array的属性
// isFixedSize 获取一个值，该值知识数组是否带有固定大小
// isReadOnly 数组是否只读
// Length 获取数组的长度 32位整数
// LongLength 获取数组长度 64位整数
// Rank 获取数组的秩(纬度)
//
//
// Array类的方法
// Clear 
//
//
using System;
namespace ArrayApplication{
    class MyArray{
        static void Main(string[] args){
            int[] list = {1,2,3,9,5,6,7,8};

            Console.WriteLine("原始数组:");
            foreach(int i in list) Console.Write(i + " ");
            Console.WriteLine();

            Array.Reverse(list);
            Console.WriteLine("逆序数组:");
            foreach(int i in list) Console.Write(i + " ");
            Console.WriteLine();

            Array.Sort(list);
            Console.WriteLine("排序数组:");
            foreach(int i in list) Console.Write(i + " ");
            Console.WriteLine();


            Console.WriteLine(list.ToString());
        }
    }
}

```
## 14.字符串
```cs
using System;
namespace StringApplication{
    class Program{
        static void Main(string[] args){
            string fname, lname;
            fname = "Rowan";
            lname = "Atkinson";

            string fullname = fname + lname;;
            Console.WriteLine("Full Name:{0}", fullname);

            char[] letters = {'H','e','l','l','o'};
            string greetings = new string(letters);
            Console.WriteLine("Greeting:{0}", greetings);

            string[] sarray = {"Hello", "From", "Tutorials", "Point"};
            string message = String.Join(" ", sarray);
            Console.WriteLine("Message:{0}", message);

            DateTime waiting = new DateTime(2012, 10,10, 17, 58, 1);
            string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
            Console.WriteLine("Message:{0}", chat);
        }
    }
}
```
### 属性
|属性名称|描述|
|--------|----|
|Chars|在当前String对象中获取Char对象的指定对象|
|Length|在当前的String对象中获取字符数|
### 类的方法
|方法名称|描述|
|--------|----|
|public static int Compare(string strA, string strB)|比较两个指定的string对象，并返回一个表示它们在排列顺中相对位置的整数，该方法区分大小写|
|public static int Compare(string strA, string strB, bool ignoreCase)|比较两个指定的string对象，并返回一个表示它们在排列顺序中相对位置的整数，但是，如果布尔参数为真时，该方法不区分大小写|
|public static string Concat(string str0, string str1)|连击两个string对象|
|public static string Concat(string str0, string str1, string str2)|连击三个string对象|
|public static string Concat(string str0, string str1, string str2, string str3)|连接四个string对象|
|public bool Contains(string value)|返回一个表示指定string对象是否出现在字符串中的值|
|public static string Copy(string str)|创建一个与指定字符串具有相同值的新的String对象|
|public void CopyTo(int sourceindex, char[] destination, int destinationIndex, int countt)|从string对象指定的位置开始服务指定数量的字符串到Unicode字符数组中的指定位置|
|public bool EndsWidth(string value)|判断string对象是否与指定的string对象具有相同的值|
|public static bool Equals(string a, string b)|判断两个指定的string对象是否具有相同的值|
|public stati string Format(string format, Object arg0)|把指定字符串中一个或多个格式项替换为指定对象的字符串表示形式|
|public int IndexOf(char value)|返回指定Unicode字符在当前字符串中第一次出现的索引，索引从0开始|
|public int IndexOf(string value)|返回指定字符串在该实例中第一次出现的索引，索引从0开始|
|public int IndexOf(string value, int startIndex)|返回指定字符串从该实例中指定字符位置开始搜索第一次出现的索引，索引从0开始|
|public int IndexOf(char value, int startIndex)|返回指定Unicode字符从该实例中指定字符位置开始搜索第一次出现的索引，索引从0开始|
|public int IndexOfAny(char[] anyOf)|返回某一个指定Unicode字符数组中任意字符在该实例中第一次出现的索引，索引从0开始|
|public int IndexOfAnd(char[] anyOf, int startIndex)|返回某一个指定的Unicode字符数组中任意字符从该实例中指定字符位置开始搜索第一次出现的索引，索引从0开始|
|public string Insert(int sstartIndex, string value)|返回一个新的字符串，其中，指定字符串被插入在当前string对象的指定索引位置|
|public static bool IsNullOrEmpty(string value)|指示指定的字符串是否为null或者是否为一个空的字符串|
|public static string Join(string separator, string[] value)|连接一个字符串数组中所有元素，使用指定的分隔每个元素|
|public static string Join(string ssparator, string[] value, int startIndex, int count)|连接一个字符串数组中的指定位置开始的指定元素，使用指定的分隔符分隔每个元素|
|public int LastIndexOf(char value)|返回指定Unicode字符在当前string对象中最后一次出现的索引位置，索引从0开始|
|public int LastIndexOf(string value)|返回指定字符串在当前string对象中最后一次出现的索引位置，索引从0开始|
|public string Remove(int startIndex)|移除当前实例中的所有字符，从指定位置开始，一直到最后一个位置为止，并返回字符串|
|public string Remove(int startIndex, int count)|从当前字符串的指定位置开始移除指定数量的字符串，并返回字符串|
|public string Replace(char oldChar, char new Char)|把当前string对象中， 所有指定的Unicode字符替换为另一个指定的Unicode字符，并返回新的字符串|
|public string Replace(string oldValue, string newValue)|把当前string对象中，索引指定的字符串替换为另一个指定的字符串，并返回新的字符串|
|public string[] Split(params char[] separator)|返回一个字符串数组，包含当前的string对象中的子字符串， 子字符串是使用指定的Unicode字符数组中的元素进行分隔的|
|public string[] Split(char[] separator, int count)|返回一个字符串数组，包含当前的string对象中的子字符串，子字符串是使用指定的Unicode字符数组中的元素进行分隔的。int参数指定要返回的子字符串的最大数目|
|public bool StartsWith(string value)|判断字符串实例的开通是否匹配指定的字符串|
|public char[] ToCharArray()|返回一个带有当前string对象中所有字符的Unicode字符数组|
|public char[] ToCharArray(int startIndex, int length)|返回一个带有当前string对象中所有字符的Unicode字符数组，从指定的索引开始，直到指定的长度为止|
|public string ToLower()|百字符串转换为小写并返回|
|public string ToUpper()|把字符串转换为大写并返回|
|public string Trim()|移除当前string对象中索引前导空白字符和后置空白字符|
```cs
using System;
namespace StringApplication{
    class StringProg{
        static void Main(string[] args){
            string str1 = "This is test";
            string str2 = "This is text";
            if(String.Compare(str1, str2) == 0){
                Console.WriteLine(str1 + " and " + str2 + " are equal.");
            }
            else{
                Console.WriteLine(str1 + " and " + str2 + " are not equal.");
            }
        }
    }
}
```
```cs
using System;
namespace StringApplication{
    class StringProg{
        static void Main(string[] args){
            string str = "Last night I dreamt of San Pedro";
            Console.WriteLine(str);
            string substr = str.Substring(23);
            Console.WriteLine(substr);
        }
    }
}
```
获取子字符串
```cs
using System;
namespace StringApplication{
    class StringProg{
        static void Main(string[] args){
            string str = "Last night I dreamt of San Pedro";
            Console.WriteLine(str);
            string substr = str.Substring(23);
            Console.WriteLine(substr);
        }
    }
}
```
连接字符串
```cs
using System;
namespace StringApplication{
    class StringProg{
        static void Main(string[] args){
            string[] starray = new string[]{
                "Down the way nights are dark",
                "And the sun shines daily on the mountain top",
                "I took a trip on a sailing ship",
                "And when I reached Jamaica",
                "I made a stop"
            };
            string str = String.Join("\n", starray);
            Console.WriteLine(str);
        }
    }
}
```
## 15.结构体(Struct)
```cs
struct Books{
    public string title;
    public string author;
    public string subject;
    public int book_id;
};
```
```cs
using System;
using System.Text;

struct Books{
    public string title;
    public string author;
    public string subject;
    public int book_id;
};
public class TestStructure{
    public static void Main(string[] args){
        Books b1;
        Books b2;

        b1.title = "C Programming";
        b1.author = "Nuha Ali";
        b1.subject = "C Programming Tutorial";
        b1.book_id = 6495407;


        b2.title = "Telecom Billing";
        b2.author = "Zara Ali";
        b2.subject = "Telecom Billing Tutorial";
        b2.book_id = 6495700;

        /*打印b1信息*/
        Console.WriteLine("book1 title:{0}", b1.title);
        Console.WriteLine("book1 author:{0}", b1.author);
        Console.WriteLine("book1 subject:{0}", b1.subject);
        Console.WriteLine("book1 book_id:{0}", b1.book_id);

        /*打印b2信息*/
        Console.WriteLine("book2 title:{0}", b2.title);
        Console.WriteLine("book2 author:{0}", b2.author);
        Console.WriteLine("book2 subject:{0}", b2.subject);
        Console.WriteLine("book2 book_id:{0}", b2.book_id);
    }

}
```
### 类vs结构
- 类是引用类型，结构是值类型
- 结构不支持继承
- 结构不能声明默认的构造函数
```cs
using System;
using System.Text;

struct Books{
    private string title;
    private string author;
    private string subject;
    private int book_id;
    public void getValues(string t, string a, string s, int id){
        title = t;
        author = a;
        subject = s;
        book_id = id;
    }
    public void display(){
        Console.WriteLine("Title:{0}", title);
        Console.WriteLine("Author:{0}", author);
        Console.WriteLine("Subject:{0}", subject);
        Console.WriteLine("Book_id:{0}", book_id);
    }
};
public class TestStructure{
    public static void Main(string[] args){
        Books b1 = new Books();
        Books b2 = new Books();
        b1.getValues("C Programming", "Nuha Ali", "C Programming Tutorial", 6495407);
        b2.getValues("Telecom Billing", "Zara Ali", "Telecom Billing Tutorial", 6495700);
        b1.display();
        b2.display();
    }
}
```
## 16.枚举(Enum)
枚举是椅子命名整型常量
```cs
enum Days {Sun, Mon, Tue, Web, Thu, Fri, Sat};
```
```cs
using System;
public class EnumTest{
    enum Day {Sun, Mon, Tue, Web, Thu, Fri, Sat};
    static void Main(){
        int x = (int)Day.Sun;
        int y = (int)Day.Fri;
        Console.WriteLine("Sum={0}", x);
        Console.WriteLine("Fri={0}", y);
    }
}
```
## 17.类(Class)

### 类的定义
```cs
using System;
namespace BoxApplication{
    class Box{
        public double length;
        public double breadth;
        public double height;
    }
    class Boxtester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();
            double volume = 0.0;

            b1.height = 5.0;
            b1.length = 6.0;
            b1.breadth = 7.0;

            b2.height = 5.0;
            b2.length = 6.0;
            b2.breadth = 7.0;

            volume = b1.height * b1.length * b1.breadth;
            Console.WriteLine("Box1 的体积:{0}", volume);

            volume = b2.height * b2.length * b2.breadth;
            Console.WriteLine("Box1 的体积:{0}", volume);
        }
    }
}
```
### 成员函数和封装
```cs
using System;
namespace BoxApplication{
    class Box{
        private double length;
        private double breadth;
        private double height;
        public void setLength(double len){
            length = len;
        }
        public void setBreadth(double bre){
            breadth = bre;
        }
        public void setHeight(double hei){
            height = hei;
        }
        public double getVolume(){
            return length * breadth * height;
        }

    }
    class Boxtester{
        static void Main(string[] args){
            Box b1 = new Box();
            Box b2 = new Box();
            double volume;

            b1.setLength(6.0);
            b1.setBreadth(7.0);
            b1.setHeight(5.0);

            b2.setLength(12.0);
            b2.setBreadth(13.0);
            b2.setHeight(10.0);

            Console.WriteLine("Box1的体积:{0}",b1.getVolume());
            Console.WriteLine("Box2的体积:{0}",b2.getVolume());
        }
    }
}
```
### 构造函数
```cs
using System;
namespace LineApplication{
    class Line{
        private double length;
        public Line(){
            Console.WriteLine("对象已创建");
        }
        public void setLength(double len){
            length = len;
        }
        public double getLength(){
            return length;
        }
        static void Main(string[] args){
            Line line = new Line();
            line.setLength(6.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
        }
    }
}
```

```cs
// 参数化构造函数
using System;
namespace LineApplication{
    class Line{
        private double length;
        public Line(double len){
            Console.WriteLine("对象已创建, length={0}", len);
            length = len;
        }
        public void setLength(double len){
            length = len;
        }
        public double getLength(){
            return length;
        }
        static void Main(string[] args){
            Line line = new Line(10.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
            line.setLength(6.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
        }
    }
}
```

### 析构函数
```cs
using System;
namespace LineApplication{
    class Line{
        private double length;
        public Line(){
            Console.WriteLine("对象已创建");
        }
        ~Line(){
            Console.WriteLine("对象已经删除");
        }
        public void setLength(double len){
            length = len;
        }
        public double getLength(){
            return length;
        }
        static void Main(string[] args){
            Line line = new Line();
            line.setLength(6.0);
            Console.WriteLine("线条的长度:{0}", line.getLength());
        }
    }
}
```
### 类的静态成员
```cs
using System;
namespace StaticVarApplication{
    class StaticVar{
        public static int num;
        public void count(){
            num++;
        }
        public int getNum(){
            return num;
        }
    }
    class StaticTester{
        static void Main(string[] args){
            StaticVar s1 = new StaticVar();
            StaticVar s2 = new StaticVar();
            s1.count();
            s1.count();
            s1.count();
            s2.count();
            s2.count();
            s2.count();
            Console.WriteLine("s1 的变量num:{0}", s1.getNum());
            Console.WriteLine("s2 的变量num:{0}", s2.getNum());
        }
    }
}
```
静态函数:
```cs
using System;
namespace StaticVarApplication{
    class StaticVar{
        public static int num;
        public void count(){
            num++;
        }
        public static int getNum(){
            return num;
        }
    }
    class StaticTester{
        static void Main(string[] args){
            StaticVar s = new StaticVar();
            s.count();
            s.count();
            s.count();
            Console.WriteLine("变量num: {0}", StaticVar.getNum());
        }
    }
}
```
## 18. 继承
```cs
using System;
namespace InheritanceApplication{
    class Shape{
        public void setWidth(int w){
            width = w;
        }
        public void setHeight(int h){
            height = h;
        }
        protected int width;
        protected int height;
    }
    class Rectangle: Shape{
        public int getArea(){
            return (width * height);
        }
    }
    class RectangleTester{
        static void Main(string[] args){
            Rectangle r = new Rectangle();
            r.setWidth(5);
            r.setHeight(7);
            Console.WriteLine("总面积:{0}", r.getArea());
        }
    }
}
```
### 基类的初始化
```cs
using System;
namespace RectangelApplication{
    class Rectangle{
        protected double length;
        protected double width;
        public Rectangle(double l , double w){
            length = l;
            width = w;
        }
        public double GetArea(){
            return length * width;
        }
        public void Display(){
            Console.WriteLine("长度:{0}",length);
            Console.WriteLine("宽度:{0}",width);
            Console.WriteLine("面积:{0}",GetArea());
        }
    }
    class Tabletop : Rectangle{
        private double cost;
        public Tabletop(double l , double w):base(l, w){}
        public double GetCost(){
            double cost;
            cost = GetArea() * 70;
            return cost;
        }
        public void Display(){
            base.Display();
            Console.WriteLine("成本:{0}",GetCost());
        }
    }
    class ExecuteRectangle{
        static void Main(string[] args){
            Tabletop r = new Tabletop(1.2,3.3);
            r.Display();
        }
    }
}
```



























