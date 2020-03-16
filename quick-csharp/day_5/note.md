1. 关系运算符:
- `==`
- `!=`
- `>`
- `<`
- `>=`
- `<=`
```c#
        public static void Test1(){
            int a = 21;
            int b = 10;
            if (a == b){
                Console.WriteLine("a == b");
            }
            else{
                Console.WriteLine("a != b");
            }
            if(a < b){
                Console.WriteLine("a < b");
            }
            else{
                Console.WriteLine("a >= b");
            }
            if(a > b){
                Console.WriteLine("a > b");
            }
            else{
                Console.WriteLine("a <= b");
            }
        }
```
2. 逻辑运算符:
- `&&`
- `||`
- `!`
```c#
        public static void Test2(){
            bool a = true;
            bool b = true;
            if(a && b){
                Console.WriteLine("a && b = true");
            }
            else{
                Console.WriteLine("a && b = false");
            }
            if(a || b){
                Console.WriteLine("a || b = true");
            }
            else{
                Console.WriteLine("a || b = true");
            }
            if(!(a && b)){
                Console.WriteLine("!(a&&b) = true");
            }
            else{
                Console.WriteLine("!(a&&b) = false");
            }
        }
```
3. 其他运算符:
- `sizeof()` 返回数据类型的大小
- `typeof()` 返回class类型
- `&`返回变量地址
- `*` 变量指针
- `?:` 条件表达式
- `is` 判断对象是否为某一类型
- `as` 强制转换，即使转换失败也不会抛出异常
