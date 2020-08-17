local function test()
    local str = "a,b,c"
    print(string.find(str, ','))
    print(string.find(str, ',', 3))
    print(string.find(str, ',', 5))
    local idx = 1
    local ret = {}
    while string.find(str, ',', idx) ~= nil do
        local t = string.find(str, ',', idx)
        ret[#ret] = string.sub(str,1, idx)
        idx = t + 1
    end
    for _, v in pairs(ret) do
        print(v)
    end
    print(ret)

end
test()

local function test1(...)
    print()
end
