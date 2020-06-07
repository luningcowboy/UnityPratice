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
            mn = l
        end
    end
    return mn
end
