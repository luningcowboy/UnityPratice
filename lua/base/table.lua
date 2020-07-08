mytable = {}
mytable[1] = "lua"
mytable = nil

mytable = {}
print("type:", type(mytable))

mytable[1] = "Lua"
mytable["wow"] = "修改前"
print("mytable 1", mytable[1])
print("mytable wow", mytable["wow"])

alternatetable = mytable

print("alternatetable", alternatetable[1])
print("alternatetable", alternatetable["wow"])

alternatetable["wow"] = "修改后"
print("alternatetable wow ", alternatetable["wow"])

alternatetable = nil
print("alternatetable", alternatetable)
print("mytable 1", mytable[1])

mytable = nil
print("mytable = ", mytable)

-- table 操作
-- 连接
fruits = {"banana", "orange", "apple"}
print("concat=>", table.concat(fruits))
print("concat=>", table.concat(fruits, ", "))
print("concat=>", table.concat(fruits, ", ", 2, 3))
-- 插入和移除
table.insert(fruits, "mango")
print(fruits[4])
table.insert(fruits, 2, "grapes")
print(fruits[2])
print(fruits[5])
table.remove(fruits)
print(fruits[5]) --> nil
-- 排序
fruits = {"banana", "orange", "apple", "grapes"}
for k, v in ipairs(fruits) do
    print(k, v)
end

table.sort(fruits)
for k, v in ipairs(fruits) do
    print(k, v)
end

function table_maxn(t)
    local mn = nil
    for k, v in pairs(t) do
        if mn == nil then
            mn = v
        end
        if mn < v then
            mn = v
        end
    end
    return mn
end
function table_len(t)
    local len = 0
    for k, v in pairs(t) do
        len = len + 1
    end
    return len
end
tbl = {[1] = 2, [2] = 6, [3] = 34, [26] = 5}
print(table_maxn(tbl)) --> 34
print(#tbl) --> 3
print(table_len(tbl)) --> 4
