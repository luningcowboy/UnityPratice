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

-- byte值修复，因为，java和c#byte值的取值范围不同
-- java -128~127, c#是0~255
local function checkByte(byte)
    if byte > 127 then
        byte = byte - 255
    end
    return byte
end

local function GetCrcCode(bytes)
    local hash = 0
    local x = 0
    for i = 1, string.len(bytes) do
        local v = string.sub(bytes, i, i)
        v = string.byte(v)
        v = checkByte(v)
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

print(GetCrcCode('33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C'))
