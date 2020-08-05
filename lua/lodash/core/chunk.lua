local function Chunk(arr, size)
    if nil == size then
        size = 1
    end
    local ret = {}
    local maxArr = math.ceil(#arr / size)
    local idx = 1
    while (idx <= maxArr)
    do
        local startIdx = size * idx
        local endIdx = startId + size
        if endIdx > maxArr then
            endIdx = maxArr
        end
        ret[#ret + 1] = lodash.split(arr, startIdx, endIdx)
        idx = idx + 1
    end
    return ret
end
return Chunk
