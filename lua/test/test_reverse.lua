local function reverse(arr)
    local len = #arr + 1
    local mid = math.floor(len / 2)
    if len < 2 then return arr end
    for i = 1, mid do
        local l = i
        local r = len - i
        if l ~= r then
            local lv = arr[l]
            local rv = arr[r]
            print(l, r)
            arr[l] = rv
            arr[r] = lv
        end
    end
    return arr
end

local arr = {}
for i = 1, 2 do
    arr[i] = i * 10
end
for i, v in ipairs(arr) do
    print("XXXXX:",i, v)
end
local a2 = reverse(arr)
for i, v in ipairs(a2) do
    print("YYYYY:",i, v)
end
