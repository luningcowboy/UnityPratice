
--[[
泛型for迭代器
for k, v in pairs(t) do
    print(k, v)
end
--]]
--

arr = {"Google", "Baidu"}
for k, v in ipairs(arr)
do
    print(k, v)
end

function square(iteratorMax, currentNum)
    if currentNum < iteratorMax
        then
        currentNum = currentNum + 1
        return currentNum, currentNum * currentNum
    end
end

for i, n in square, 3, 0
do
    print(i, n)
end

function iter(a, i)
    i = i + 1
    local v = a[i]
    if v then
        return i, v
    end
end

function ipairs(a)
    return iter, a, 0
end

-- 多状态迭代器
arr = {"Google", "Baidu"}

function elementIterator(collection)
    local index = 0
    local count = #collection

    return function()
        index = index + 1
        if index <= count then
            return collection[index]
        end
    end
end

for ele in elementIterator(arr)
do
    print(ele)
end
