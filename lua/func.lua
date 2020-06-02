function max(n1, n2)
    if n1 > n2 then
        return n1
    else
        return n2
    end
end

print(max(1, 2))

-- 函数作为参数
myprint = function(param)
    print("myprint:", param)
end

function add(n1, n2, printFunc)
    ret = n1 + n2
    printFunc(ret)
    return ret
end

add(1, 2, myprint)

-- 多个返回值
function maximum(a)
    local mi = 1
    local m = a[mi]
    for i, val in ipairs(a) do
        if val > m then
            mi = i
            m = val
        end
    end
    return m, mi
end

print(maximum({1,2,3,4,5,6}))

-- 可变参数
function add(...)
    local ret = 0
    for i, v in ipairs{...} do --> {...} 表示一个所有变长参数构成的数组
        ret = ret + v
    end
    return ret
end

print(add(1,2,3,4,5))

function average(...)
    local ret = 0
    local arg = {...}
    for i, v in ipairs(arg) do
        ret = ret + v
    end
    print("average， 参数个数:" .. #arg)
    -- 可以通过select("#", ...)获取可变参数的数量
    print("average， 参数个数:" .. select("#", ...))

    return ret / #arg
end
print(average(1,2,3,4,5,6))

-- 固定参数与可变参数组合
function fwrite(fmt, ...)
    return io.write(string.format(fmt, ...))
end

fwrite("baidu\n")
fwrite("%d - %d\n", 1, 2)

do
    function foo(...)
        for i = 1, select('#', ...) do
            local arg = select(i, ...)
            print("arg", arg)
        end
    end

    foo(1,2,3,4)
end
