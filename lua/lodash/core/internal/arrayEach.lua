local function addAdd(v)
    return v + 1
end
local function arrayEach(arr, iteratee)
    local idx = 0
    local len = #arr
    idx = idx + 1
    while idx <= len do
        local stat, ret = pcall(iteratee, arr[idx], idx, arr)
        if not stat then
            error("arrayEach iteratee failed")
        end
        if not ret then
            break
        end
        idx = idx + 1
    end
    return arr
end
--[[
local function test()
    local arr = {1,2,3,4,5}
    arrayEach(arr, function(v, i, arr) 
        print(i, v)
        return true
    end)
end
test()
]]
return arrayEach
