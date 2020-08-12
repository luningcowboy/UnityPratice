-- 这个算法只能分割pattern=单字符
local function split2(str, pattern)
    if not pattern then
        pattern = ','
    end
    local ret = {}
    local len = string.len(str)
    local sub_str = ''
    for i = 1, len do
        local tmp_str = string.sub(str, i, i)
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
local function split(str, pattern)
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
local function format(list)
    local ret = ""
    for _, str in ipairs(list) do
        ret = ret .. str
    end
    return ret
end
local function join(list, pattern)
    local ret = ""
    local len = #list
    local str = ""
    for i = 1, len  do
        str = list[i]
        if i < len then
            ret = ret .. str .. pattern
        else
            ret = ret .. str
        end
    end
    return ret
end

local function testFormate()
    print(format({"a",1,2,3,"b"}))
end
local function testJoin()
    print(join({"a",1,2,3,"b"}, "xx"))
    print(join({"a"}, "xx"))
end
