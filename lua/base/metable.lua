--元表:允许我们修改table的行为,每个行为关联对应的元方法

mytable = {}
mymetatable = {}
setmetatable(mytable, mymetatable)
print(getmetatable(mytable))

-- __index 元方法
-- 表示对表访问
other = {foo = 3}
t = setmetatable({}, {__index = other})
print(t.foo) --> 3
print(t.bar) --> nil

mytable = setmetatable({key1 = "value1"},{
        __index = function(mytable, key)
            if key == 'key2' then
                return 'metatablevlaue'
            else
                return nil
            end
        end
    })
print(mytable.key1, mytable.key2)

-- __newindex 元方法
-- 用来对表更新
mymetatable = {}
mytable = setmetatable({key1 = "value1"}, {__newindex = mymetatable})
print(mytable.key1)

mytable.newkey = "新增2"
print(mytable.newkey, mymetatable.newkey)

mytable.key1 = "新增1"
print(mytable.key1, mymetatable.key1)

mytable = setmetatable({key1 = "value1"},{
        __newindex = function(mytable, key, value)
            rawset(mytable, key, "\""..value.."\"")
        end
    })
mytable.key1 = "new value"
mytable.key2 = 4
print(mytable.key1, mytable.key2)

-- 为表添加操作符
function table_maxn(t)
    local mn = 0
    for k, v in pairs(t) do
        if mn < k then
            mn = k
        end
    end
    return mn
end

mytable = setmetatable({1, 2, 3}, {
        __add = function(mytable, newtable)
            for i = 1, table_maxn(newtable) do
                table.insert(mytable, table_maxn(mytable) + 1, newtable[i])
            end
            return mytable
        end
})

secondtable = {4, 5, 6}

mytable = mytable + secondtable
for k, v in ipairs(mytable) do
    print(k, v)
end

--[[
__add +
__sub -
__mul *
__div /
__mod %
__unm -
__concat ..
_eq ==
__lt <
__le <=
--]]

-- __call元方法

mytable = setmetatable({10}, {
        __call = function(mytable, newtable)
            sum = 0
            for i = 1, table_maxn(mytable) do
                sum = sum + mytable[i]
            end
            for i = 1, table_maxn(newtable) do
                sum = sum + newtable[i]
            end
            return sum
        end
    })
newtable = {10, 20, 30}
print(mytable(newtable))

-- __tostring 元方法
mytable = setmetatable({10, 20, 30}, {
        __tostring = function(mytable)
            sum = 0
            for k, v in pairs(mytable) do
                sum = sum + v
            end
            return "sum = " .. sum
        end
    })
print(mytable)
