using System;
class Test{
    static void Main(){
        // null 合并运算符
        // 如果 ? ? 表达式的左侧不是 null , 那么，右侧的表达式不回执行
        string s1 = null;
        string s2 = s1 ?? "nothing";
        Console.WriteLine(s2);
        // null 条件运算符
        // "? ." 称为null条件运算符或者Elvis运算符,这个运算符可以像"."预算符那样
        // 访问成员以及调用方法，当运算符左侧为null，这个表达式的结果也是null而且
        // 不回抛出NullReferenceException异常
        System.Text.StringBuilder sb = null;
        string s = sb? .ToString();
        Console.WriteLine(s);
        string s3 = (sb == null ? null : sb.ToString());

    }
}
