--元表:允许我们修改table的行为,每个行为关联对应的元方法

mytable = {}
mymetatable = {}
setmetatable(mytable, mymetatable)
print(getmetatable(mytable))

-- __index 元方法

other = {foo = 3}
t = setmetatable({}, {__index = other})
print(t.foo) --> 3
print(t.bar) --> nil
