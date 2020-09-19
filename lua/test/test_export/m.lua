local function f1()
    print('f1')
end
local function f1()
    print('f11')
end

return {f1 = f1}
