local function IsSameRow(v1, v2)
    local ret = false
    ret = math.ceil(v1/6) == math.ceil(v2/6)
    return ret
end

local function ToInteger(num)
    return math.floor(tonumber(num) or error("Counld not cast " .. tostring(num) .. "to a number"))
end

local function GetAnimationIndexList(sel, to)
    if sel == to then return nil end
    local ret = {}
    local step = sel > to and -1 or 1
    local s = sel + step
    local e = sel > to and to or to - step
    for i = s, e, step do
        ret[#ret + 1] = i
    end
    return ret
end


print(IsSameRow(1, 5))
print(IsSameRow(1, 6))
print(IsSameRow(1, 7))
print(IsSameRow(1, 2))

local function TestGetAnimationIndex(sel, to)
    print("*********************************")
    print("FROM:" .. sel .. " ,TO:" .. to)
    print("*********************************")
    for i, v in ipairs(GetAnimationIndexList(sel, to)) do
        print(i, v)
    end
end

TestGetAnimationIndex(1, 5)
TestGetAnimationIndex(5, 1)
