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
