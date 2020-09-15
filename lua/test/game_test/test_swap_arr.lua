local function SwapArr(arr, from, to)
    local fArr = {}
    for i, v in ipairs(from) do
        fArr[v] = arr[v]
    end
    for i, v in ipairs(to) do
        local f = from[i]
        local t = v
        arr[t] = fArr[f] 
    end
    return arr
end

local function DumpArr(arr)
    for i, v in ipairs(arr) do
        print(i, v)
    end
end

local arr = {1,2,3,4,5,6,7,8, 9, 10, 11, 12}
arr = SwapArr(arr, {1,2,3}, {3,1,2})
DumpArr(arr)
print("***********")
arr = SwapArr(arr, {2,3,4}, {4, 2, 3})
DumpArr(arr)
