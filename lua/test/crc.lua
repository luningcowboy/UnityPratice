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

local testData = {}
print(GetCrcCode(testData))
