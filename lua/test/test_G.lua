-- 先输出一下函数是否存在
print("print_message = ", tostring(_G["print_message"]))

-- 先写一下全局函数
function print_message(str)
    print("Lua output : "..str)
end

-- 再输出一下函数是否存在
print("print_message = ", tostring(_G["print_message"]))

-- 调用函数
local func = _G["print_message"]
func("print_message function is exist!")

-- 定义局部函数
local function local_name()
    print("Lua output : this is local functon")
end

-- 检查一下局部函数是否存在
print("local_name = ", tostring(_G["local_name"]))

_G["local_name"] = local_name;

-- 调用就已经变成全局函数的局部函数

_G["local_name"]()

print("\n")
print("\n")
print("\n")
print("output _G:\n")
for k, v in pairs(_G) do
    print(k, "\t", v)
end
