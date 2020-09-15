local function before(n, func)
    assert(type(func) == 'function', "func \
        is not a function")
    local ret = nil
    return function(...)
        n = n - 1
        if n > 0 then
            ret = pcall(func, ...)
        end
        if n <= 1 then
            func = nil
        end
        return ret
    end
end

--[[
local function test()
    local done = before(5, function() print("done") end)
    for i = 1, 5 do
        done()
    end
end
test()
]]
return before
