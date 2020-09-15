local function after(n, func)
    assert(type(func) == "function", 'func is\
        not a function')
    n = n or 0
    return function(...)
        n = n - 1
        if n < 0 then
            return pcall(func, ...)
        end
    end
end

--[[
local function test()
    local arr = {1,2,3,4}
    local done = after(#arr, function() print("done") end)
    while not done() do
        print("not done")
    end
end
test()
]]
return after

