local function split(str, pattern)
    if not pattern then
        pattern = ','
    end
    local ret = {}
    local len = string.len(str)
    local sub_str = ''
    for i = 1, len do
        local tmp_str = string.sub(str, i, i)
        print(i, tmp_str)
        if tmp_str ~= pattern then
            sub_str = sub_str .. tmp_str
        else
            ret[#ret+1] = sub_str
            sub_str = ""
        end
    end
    if sub_str ~= nil then
        ret[#ret + 1] = sub_str
    end

    return ret
end
local function split2(str, pattern)
    if not pattern then
        pattern = ','
    end
    local ret = {}
    local start = 1
    local find = 1
    while true do
        local last = string.find(str, pattern, start)
        if not last then
            ret[find] = string.sub(str, start, string.len(str))
            break
        end

        ret[find] = string.sub(str, start, last - 1)
        start = last + string.len(pattern)
        find = find + 1

    end
    return ret
end
--local xx = split('a,b,c', ',')
--local xx = split2('a', ',')
local xx = split('a', ',')
for _, x in pairs(xx) do
    print(x)
end
