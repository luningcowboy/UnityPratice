1. 封装
- `public`: 所有对象都可以访问
- `private`: 对象本身在对象内部可以访问
- `protected`: 只有该类和其子类可以访问
- `internal`: 同一个程序集都对象可以访问
- `protected internal`: 访问限制与同一个程序集或派生自包含类的类型
**注意:**
- 如果没有指定访问修饰符，则使用类成员的默认访问修饰符，即为 private。
- Protected Internal 访问修饰符允许在本类,派生类或者包含该类的程序集中访问。这也被用于实现继承。
2. 方法:
```c#
<Access Specifier> <Return Type> <Method Name> (Parameter List){
    Method Body
}
```
- `Access Specifier` 访问修饰符
- `Return Type` 返回类型
- `Method Name` 方法名称
- `Parameter List` 参数列表
- `Method Body` 方法主体

** 注意: **
- 提供给输出参数的变量不需要赋值。当需要从一个参数没有指定初始值的方法中返回值时，输出参数特别有用
