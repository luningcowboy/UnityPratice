string1 = "lua"
print(string1) --> lua

string2 = 'www.baidu.com'
print(string2) --> www.baidu.com

string3 = [["xxx"]]
print(string3) --> xxx

print(string.upper("abc")) --> ABC

print(string.lower("ABCd")) --> abcd

print(string.gsub("aaaa", "a", "z", "2")) --> zzaa 2

-- 在字符串中查找指定字符串，返回具体位置，不存在返回nil
print(string.find("Hello Lua user", "Lua", 1)) --> 7 9

print(string.reverse("Lua")) --> auL

print(string.format("the value is:%d", 4)) --> the value is:4

print(string.char(97, 98, 99, 100)) --> abcd

-- 转换字符为整数(可以指定某个字符，默认第一个字符)
print(string.byte("ABCD", 4)) --> 68
print(string.byte("D")) --> 68

print(string.len("abc")) --> 3

-- 返回字符串的n个拷贝
print(string.rep("abcd", 2)) --> abcdabcd

print("a".."b") --> ab

--[[
string.gmatch(str, pattern)
返回一个迭代器函数，每一次调用这个函数，返回一个字符串str找到
下一个符合pattern描述的子串，如果pattern描述的子串没找到则返回
nil
--]]
for word in string.gmatch("Hello Lua user", "%a+") do print(word) end
--[[
Hello
Lua
user
--]]

print(string.match("I have 2 questions for you", "%d+ %a+")) --> 2 questions

print(string.format("%d, %q", string.match("I have 2 questions for you", "(%d+) (%a+)"))) --> 2, "questions"
