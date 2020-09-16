local function addAdd(v)
    return v + 1
end
local function arrayEach(arr, iteratee)
    local idx = -1
    local len = #arr
    while addAdd(idx)< length do
        local stat, ret = xpcall(iteratee,function(err) print(err)end, arr[idx], idx, arr)
        if not ret then
            break
        end
    end
    return arr
end
return arrayEach
