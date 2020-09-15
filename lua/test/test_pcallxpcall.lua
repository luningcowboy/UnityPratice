local function func1()
    error("func1")
end

local function func2()
    print("func2")
end

if pcall(func2) then
    print("xxxx")
end

if not pcall(func1) then
    print("func2 failed")
end

--local ret, err = xpcall(func2)
--print(ret, err)
local function err_handler(err)
    print("err_handler")
    print(err)
end

local stat, ret = xpcall(func1, err_handler)
print(stat, ret)

stat, ret = xpcall(func2, err_handler)
print(stat, ret)
