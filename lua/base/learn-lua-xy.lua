-- 单行注释
--[[
多行
注释
--]]

num = 42
s = 'water'
t = "water"
u = [[
多行文本
哈哈
]]

t = nil
while num < 50 do
    num = num + 1
end

if num > 40 then
    print('over 40')
elseif s ~= 'water' then
    io.write('not over 40\n')
else
    thisIsGlobal = 5
    local line = io.read()

    print('windter is comming' .. line)
end

foo = anUnknowVar

aBoolVar = false

if not aBoolVar then
    print("false")
end

ans = aBoolVar and 'yes' or 'no'
print(ans)

karlSum = 0
for i = 1, 100 do
    karlSum = karlSum + i
end

fredSum = 0
for j = 100, 1, -1 do fredSum = fredSum + j end

repeat 
    print('the way of the future')
    num = num - 1
until num == 0

function fib(n)
    if n < 2 then
        return n
    end
    return fib(n - 2) + fib(n - 1)
end

function adder(x)
    return function(y) return x + y end
end

a1 = adder(9)
a2 = adder(36)
print(a1(16))
print(a2(64))

x, y, z = 1, 2, 3, 4
function bar(a, b, c)
    print(a, b, c)
    return 1,2,3,4,5
end
print(bar(x,y,z))
b1, b2, b3 = bar(x, y, z)
print(b1, b2, b3)
print(bar('abcdef'))

function f(x) return x * x end
f = function(x) return x * x end

local function g(x) return math.sin(x) end
local g;
g = function(x)
    return math.sin(x)
end
