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
