file = io.open('tmp.lua', 'r')
-- 输出第一行
print(file:read())
file:close()

file = io.open('tmp.lua', 'a')
file:write("--test")
file:close()

for line in io.lines("tmp.lua") do
    print(line)
end

file = io.open("tmp.lua", 'r')
file:seek("end", -25)
print(file:read("*a"))
file:close()
