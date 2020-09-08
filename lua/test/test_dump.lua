local function IsArray(t)
    if type(t) ~= "table" then return false end

    local n = #t
    for i, v in pairs(t) do
        if type(i) ~= "number" then return false end
        if i > n then return false end
    end

    return true
end

local function FormatArray(t)
    local str = "{"
    local len = #t
    for i, v in ipairs(t) do
        if i < len then
            str = str .. v .. ","
        else
            str = str .. v .. "}"
        end
    end
    return str
end

local function dump(t)
    local s = "{"
    for k, v in pairs(t) do
        if type(v) == "table" then
            if IsArray(v) then
                s = s .. FormatArray(v)
            else
                s = s .. dump(v)
            end
        else
            local tmp = k .. ":" .. v .. ","
            s = s .. tmp
        end
    end
    s = s .. "}"
    return s
end

print(dump({a=1, b = 2, c = {1,2,3}, d = {d1=1, d2 = 2}}))
