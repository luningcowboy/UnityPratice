1. `using System;` 引入一个名称空间，类似js中`require`和python中`import`来引入模块.
2. `NameSpace` 名称空间，主要是为了区分模块，避免出现重名的情况.
3. 程序入口:`static void Main(string[] args){}`方法，作为一个可执行程序，必须有一个程序入口，类似c/cpp中的`main`函数
4. Mac下编译代码 `csc <script-name>` 或者 `csc <script-name> /unsafe` 来编译代码.
5. Mac下运行代码 `mono <script-name>.exe` 运行编译玩的代码
6. 信息输出`Console.WriteLine()` 打印日志，类似python中的`print`, js中的`console.log`
```c#
Console.log("这是日志");
Console.log("a = {0}, b = {1}, c = {2}", a, b, c);
Console.log("a = {0}, b = {0}, c = {0}", a, b, c);// 这种情况也是正确输出a,b,c
Console.log("A = {}, b = {}, c = {},", a, b, c); // Error
```
7. 声明一个类`class <class-name>`
8. 单行注释`// 这是一个注释`
9. 多行注释`/* */`
10. 静态函数`static void TestValueTypes(){}`
```c#
namespace Test{
    class A{
        public static void M1(){
            Console.WriteLine("Test::A::M1");
        }
    }
    class B{
        static void Main(string[] args){
            A.M1();
        }
    }
}
```
11. 值类型:从`System.ValueTypes`派生，值类型直接包含数据，比如:`int, char, float`,他们分别存储数字，字符，浮点数，系统分配内存来存储值。
12. 获取类型或变量在特定平台上从尺寸`sizeof()`: 例如:`sizeof(int)`
13. 引用类型:变量中不包含实际数据，只包含对变量对引用,他们指的是一个内存位置。内置的引用类型:`object, dynamic, string`
- `Object`是`System.Object`的别名，是C#通用类型系统(Common Type System - CTS)中所有数据类型的基类.
    - 装箱: 当一个值类型转换为对象类型时，被称为装箱
    - 拆箱: 当一个对象类型被转换为值类型时，被称为拆箱
    ```
    object obj;
    obj = 100; // 这是装箱
    ```
- `dynamic`动态类型,你可以存储任何类型当值在动态类型变量中，这些变量的类型检查发生在运行时.
    - 语法规则:`dynamic <variable_name> = value;` eg: `dynamic d = 20;`
    - **动态类型与对象类型类似，但是，动态类型的类型检查发生在运行时，对象类型的类型检查发生在编译时。**
- `String`字符串类型, 运行给变量分配任何字符串值，字符串(String)是`System.Stirng`类的别名。从Object类派生。
    - 字符串可以通过两种形式进行分配:引号和`@`.eg: `String str = "hello c#";`或者`String str = @"Hello World";`
    - `@`分配的字符串称为**逐字字符串**,将转义字符(\)当作普通字符对待，类似python中r修饰的字符串 `string str = @"C:\Windows";`等价于`string str = "C:\\Windows";`
- 用户自定义类型有`class, interface, delegate`即:类， 接口和代理
14. 指针类型: 存储另一种类型的内存地址，C#中指针的作用跟c/cpp中指针的作用一样。
    - 语法: `type * identifier;` eg: `char* cptr;` 或者`int* iptr;`
15. 类型转换:
    - 隐式类型转换:C#默认的以安全的方式进行转换，不会导致数据丢失。
    - 显式类型转换:即强类型转换，主要强制转换符，会造成数据丢失。
