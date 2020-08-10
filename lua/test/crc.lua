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

local function GetCrcCode2(bytes)
    local hash = 0
    local x = 0
    for i = 1, string.len(bytes) do
        local v = string.sub(bytes, i, i)
        v = string.byte(v)
        print("XXXX", math.tointeger(hash << 4) )
        hash = (hash << 4) + v
        print("YYYY", hash)
        x = math.tointeger(hash & 0xF0000000)
        print(i, v, hash, x)
        if x ~= 0 then
            hash = hash ~ (x >> 24)
            print('hash:', hash)
            hash = hash & (~x)
            print('hash:', hash)
        end
    end
    return hash & 0x7FFFFFFF
end

print(GetCrcCode2('33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C'))
