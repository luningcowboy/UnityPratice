-- while
a = 10
while (a < 20)
do
    print("a = ", a)
    a = a + 1
end

-- 数值for
-- for var = exp1, exp2, exp3 do
-- end
-- exp1:开始, exp2:结束
-- exp3:步长
for i = 10, 1, -1 do
    print("for i = ", i)
end

function f(x)
    return x * 2
end
for i = 1, f(5) do
    print(i)
end

-- 泛型for
a = {"one", "two", "three"}
for i, v in ipairs(a) do
    print(i, v)
end

days = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturadya"}
for i, v in ipairs(days) do
    print(v)
end


-- repeat...until
a = 10
repeat
    print(a)
    a = a + 1
until(a > 15)

-- break
a = 10
while(a < 20)
do
    print("a = ", a)
    a = a + 1
    if(a > 15) then
        break
    end
end
-- goto
local a = 1
::label::print("---goto--label")

a = a + 1
if a < 3 then
    goto label
end

for i = 1, 3 do
    if i <= 2 then
        print(i, "continue")
    end
    print(i, "no continue")
    ::continue::
    print("end")
end
