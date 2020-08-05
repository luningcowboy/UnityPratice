local function Split(arr, s, e)
    local ret = {}
    for i, v in ipairs(arr) do
        if i >= start and i <= e then
            ret[#ret + 1] = v
        end
    end
    return ret
end
return Split
