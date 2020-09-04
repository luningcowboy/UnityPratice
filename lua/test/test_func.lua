local function func1()
end
--[[
func1.__call = function() print("new") end
print(func1)
]]

local function func2()
    return 1, 2
end

local a, b = func2()
print(a, b)

