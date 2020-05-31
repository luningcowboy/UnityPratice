print(type(3)) --> number
print(type(3.5)) --> number
print(type(3.0)) --> number
print(1 == 1.0) --> true
print(-3 == -3.0) --> true
print(0.2e3 == 200) --> true

print(math.type(3)) --> integer
print(math.type(3.0)) --> float

print(0xff) --> 255
print(0x1A3) --> 419
print(0x0.2) --> 0.125
print(0xa.bp2) --> 42.75

print(string.format("%a", 419))
print(string.format("%a", 0.1))

print(1 + 1) --> 2
print(10 + 10.0) --> 20.0
print(- (3 * 2.0)) --> -6.0

print(3//2) --> 1
print(3//2.0) --> 1.0
print(-9//2) --> -5
print(math.pi)

x = math.pi
print(x - x % 0.01) --> 3.14
print(x - x % 0.001) --> 3.141

local tolerance = 10
function isturnback(angle)
    angle = angle % 360
    return (math.abs(angle - 180) < tolerance)
end

print(isturnback(-180)) --> true

-- 幂运算
print(2^3) --> 8.0
print(2^(1/3)) --> 1.2599210498949

-- 关系运算符
--[[
<
>
<=
>=
==
~=
--]]
print(1 == 1.0) --> true

-- math.random
print(math.random()) --> [0,1)
print(math.random(5)) --> [1,n] 整数
print(math.random(2,5)) --> [x,y] 整数
math.randomseed(os.time()) --> 设置随机数种子

-- 取整
print(math.floor(3.5)) --> 3
print(math.ceil(3.5)) --> 4
print(math.ceil(3.1)) -->4
print(math.modf(3.5)) --> 3 0.5

--[[
--四舍五入
--]]
function round(x)
    local f = math.floor(x)
    if( x == f) or (x % 2.0 == 0.5) then
        return f
    else
        return math.floor(x + 0.5)
    end
end

function round2(x)
    local f1, f2 = math.modf(x)
    if f2 >= 0.5 then
        return f1 + 1
    else
        return f1
    end
end

print(round(2.5)) --> 2
print(round(3.5)) --> 4
print(round2(2.5)) --> 3
print(round2(3.5)) --> 4

-- 数值类型转换
-- integer ==> float
print(3 + 0.0) --> 3.0

print(math.tointeger(3.0)) --> 3
print(math.tointeger(-3.15)) --> nil
print(math.tointeger(-3.0)) --> -3
print(math.tointeger(3.15)) --> nil
print(math.tointeger(1.5)) --> nil

function cond2int(x)
    return math.tointeger(x) or x
end

print(cond2int(3.15)) --> 3.15
print(cond2int(-3.15)) --> -3.15
