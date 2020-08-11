local function deepCopy(orig)
    local copy
    if type(orig) == "table" then
        copy = {}
        for k, v in next, orig, nil do
            copy[deepCopy(k)] = deepCopy(v)
        end
        setmetatable(copy, deepCopy(getmetatable(orig)))
    else
        copy = orig
    end
    return copy
end

local function shallowCopy(orig)
    local copy
    if type(copy) == 'table' then
        copy = {}
        for k, v in pairs(orig) do
            copy[k] = v
        end
    else
        copy = orig
    end
    return copy
end
