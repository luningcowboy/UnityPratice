## 交错数组
交错数据跟二维数组不一样，行可以是不等长的，这个是真正的数组的数组。
初始化
```c#
int [][] scores;
int [][] scores = new int[5][];
int [][] scores = new int[2][]{new int{11, 12, 13}, new int{11, 12, 13}};
```
## 字符串
在C#中使用字符数组来表示字符串，更常见的是使用string关键字来声明一个字符串变量.
`string`关键字`String.String`类的别名。

### 创建方法
- 给`String`变量指定一个字符串
- 通过使用`String`类构造函数
- 通过使用字符串串联运算符(+)
- 通过检索属性或调用一个返回字符串的方法
- 通过格式化方法来转换一个值或对象为它的字符串表示形式

### 属性
- Chars 获取Char对象的指定位置
- Length 在当前String对象中获取字符数

### 方法
- `public staitc int Compare(string a, string b);` 比较两个指定的string对象，
