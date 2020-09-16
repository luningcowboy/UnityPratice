local function addAdd(v)
    return v + 1
end
local function arrayEach(arr, iteratee)
    local idx = -1
    local len = #arr
    idx = idx + 1
    while idx < length do
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
return arrayEach
