1. 算术运算符: +, -, * , / % ++ --
```c#
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
```
输出:
```shell
Line 1 - c = 31
Line 2 - c = 11
Line 3 - c = 210
Line 4 - c = 2
Line 5 - c = 1
Line 6 - c = 22
Line 7 - c = 21
```
2.  自增自减
```c#
            int a = 1;
            int b;

            b = a++;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = ++a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = a--;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a = 1;
            b = --a;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
```
```shell
a = 2
b = 1
a = 2
b = 2
a = 0
b = 1
a = 0
b = 0
```
3. 关系运算符
