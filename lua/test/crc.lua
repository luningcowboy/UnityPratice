function XOr(n1, n2)
    local t1 = n1
    local t2 = n2
    local str = ""
    repeat
        local s1 = t1 % 2
        local s2 = t2 % 2
        if s1 == s2 then
            str = "0" .. str
        else
            str = "1" .. str
        end
        t1 = math.modf(t1/2)
        t2 = math.modf(t2/2)
    until(t1 == 0 and t2 == 0)
    return tonumber(str, 2)
end
function And(n1, n2)
    local t1 = n1
    local t2 = n2
    local str = ""
    repeat
        local s1 = t1 % 2
        local s2 = t2 % 2
        if s1 == s2 then
            if s1 == 1 then
                str = "1" .. str
            else
                str = "0" .. str
            end
        else
            str = "0" .. str
        end
        t1 = math.modf(t1/2)
        t2 = math.modf(t2/2)
    until(t1 == 0 and t2 == 0)
    return tonumber(str, 2)
end
function Or(n1, n2) 
    local t1 = n1
    local t2 = n2
    local str = ""
    repeat
        local s1 = t1 % 2
        local s2 = t2 % 2
        if s1 == s2 then
            if s1 == 0 then
                str = "0" .. str
            else
                str = "1" .. str
            end
        else
            str = "1" .. str
        end
        t1 = math.modf(t1/2)
        t2 = math.modf(t2/2)
    until(t1 == 0 and t2 == 0)
    return tonumber(str, 2)
end
local function GetCrcCode(bytes)
    local hash = 0
    local x = 0
    for _, v in ipairs(bytes) do
        hash = (hash << 4) + v
        x = hash & 0xF0000000
        if x ~= 0 then
            hash = hash ^ (x >> 24)
            hash = hash & (~x)
        end
    end
    return hash & 0x7FFFFFFF
end

local function cond2int(x)
    return math.tointeger(x) or x
end
local function checkNum(n)
    assert(n ~= nil, "checkNum n is nil")
    local max = 2147483648
    local min = -2147483648
    local ret = n
    if n >= max then
        ret = min + (n - max)
    end
    if n < min then
        ret = max + (n - min)
    end
    return ret
end

local function GetCrcCode2(bytes)
    local hash = 0
    local x = 0
    for i = 1, string.len(bytes) do
        local v = string.sub(bytes, i, i)
        v = string.byte(v)
        hash = (hash << 4) + v
        x = math.tointeger(hash & 0xF0000000)
        print(i, v, hash, x)
        if x ~= 0 then
            hash = hash ~ (x >> 24)
            hash = hash & (~x)
        end
    end
    return hash & 0x7FFFFFFF
end

local function GetCrcCode3(bytes)
    local hash = 0
    local x = 0
    for i = 1, string.len(bytes) do
        local v = string.sub(bytes, i, i)
        v = string.byte(v)
        hash = (hash << 4) + v
        hash = checkNum(hash)
        x = hash & 0xF0000000
        x = checkNum(x)
        print(i, v, hash, x)
        if x ~= 0 then
            hash = hash ~ (x >> 24)
            hash = checkNum(hash)
            hash = hash & (~x)
            hash = checkNum(hash)
        end
    end
    return hash & 0x7FFFFFFF
end

--print(GetCrcCode2('33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C'))
print(GetCrcCode3('33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C'))
