
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
