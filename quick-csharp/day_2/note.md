## 类型转换:
    - 隐式类型转换:C#默认的以安全的方式进行转换，不会导致数据丢失。
    - 显式类型转换:即强类型转换，主要强制转换符，会造成数据丢失。
## 类型转换方法
- ToBoolean 把类型转换为boolean值
- ToByte 把类型转换为字节类型
- ToChar 如果可能的话把类型转换为单个Unicode字符类型
- ToDateTime 把类型(整数或者字符串类型)转换为 日期-时间 结构
- ToDecimal 把浮点型或整数类型转换为十进制类型
- ToDouble 把类型转换为双精度浮点类型
- ToInt16 把类型转换为16位整数类型
- ToInt32 转换为32位整数类型
- ToInt64 转换为64整数类型
- ToSbyte 把类型转换为有符号字节类型
- ToSingle 把类型转换为小浮点数类型
- ToString 把类型转换为字符串类型
- ToType 把类型转换为指定类型
- ToUInt32 把类型转换为无符号32位整数类型
- ToUInt64 把类型转换为无符号64位整数类型

## 变量
一个变量就是一个供程序操作的存储区域的名字。
每个变量都有一个类型名， **决定了变量的内存大小和布局**
### 值类型
- 整数类型: sbyte, byte, short, ushort, int, uint, long, ulong, char
- 浮点数: float, double
- 十进制: decimal
- 布尔值: true, false
- 空类型: 可为空值的数据类型
### 变量的定义
`<data_type> <variable_list>;`
```c#
int i, j, k;
char c, ch;
float f, salary;
double d;
int n = 100; // 可以在变量定义的时候对变量进行初始化
```
```c#
    short a;
    int b;
    double c;

    a = 10;
    b = 20;
    c = a + b;
    Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
```
### 接受来自用户的值
```c#
            int num;
            Console.WriteLine("Please input a num:\n");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input={0}", num);
```
`Console.ReadLine()`只接收字符串格式的数据，所以需要用`Convert.ToInt32`来转换.

## C#中的Lvalues和Rvalues
- lvalues : lvalues可以出现在赋值语句的左边或者右边
- rvalues: rvalues 可以出现在赋值语句的右边，不能出现在赋值语句的左边
