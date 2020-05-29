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
