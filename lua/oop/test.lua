local test = {}
test.age = 10
test['sex'] = 'man'

test.__call = function() print('test call') end
test.__index = function() print('test index') end
function test:t1()
    print('t1xxx:', self)
    print('t1')
end
function test:t2()
    print('t2xxx:', self)
    print('t2')
end
test['func1'] = function()
    print('func1', self)
end
test.func2 = function()
    print('func2', self)
end
print("---------------")
for k, v in pairs(test) do
    print('output:')
    print(k, v)
    print("***************")
end
print("---------------")

test.t1()
test.t2()

test:t1()
test:t2()

test.func1()
test.func2()
