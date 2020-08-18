-- 排序规则
-- 1. 当前卡牌能装备的在前，不能装备的在后
-- 2-1. 装备强化水平大于等于当前装备的在后面，其他的在前面
-- 2-2. 装备铭文水平大于等于当前装备的在后面，其他的在前面
-- 3-1. 未被强化的装备在前，已经强化过的装备在后
-- 3-2. 未被铭文的装备在前，已经铭刻过的装备在后
-- 4. 评分高的装备在前，低的在后
-- 执行算法
-- a. 按装备评分排序
-- b. 按强化水平排序 和 铭文水平排序(强化和铭文组合出一个分数，用这个分数排序)
-- c. 按是否能装备分割(在a,b的基础上，区分能装备和不能装备，能装备在前，不能装备在后)

local function GetEquipConfig(score, level, strengthen, rune, id)
    local ret = {
        id = id,
        score = score,
        level = level,
        strengthen = strengthen,
        rune = rune
    }
    return ret
end

local function checkScroe(a, b)
    if not a or not b then return false end
    local sa = a['score']
    local sb = b['score']
    --print(a.id, b.id, sa, sb)
    if sa == sb then return false end
    return sa < sb
end

local function SortByScore(arr)
    table.sort(arr, function(a, b)
        if not a or not b then return false end
        local sa = a['score']
        local sb = b['score']
        if sa == sb then return false end
        return sa > sb
    end)
    return arr
end
local function SortByStrengthenAndRunne(arr)
    --[[
    table.sort(arr, function(a, b)
        if not a or not b then return false end
        local a1 = a.strengthen
        local a2 = a.rune
        local b1 = b.strengthen
        local b2 = b.rune
        local aa = a1 + a2
        local bb = b1 + b2
        if aa == bb then return false end
        return aa < bb
    end)
    return arr
    ]]
    local ret = {}
    local l = {}
    local r = {}
    for _, v in ipairs(arr) do
        local s = v.strengthen
        local ru = v.rune
        if s == 0 and ru == 0 then
            l[#l + 1] = v
        else
            r[#r + 1] = v
        end
    end
    ret = l
    for _, v in ipairs(r) do
        ret[#ret + 1] = v
    end
    return ret
end
local function IsAdd2Left(v, level)
    local ret = false
    ret = v.level - level < 10
    return ret
end
local function SplitEquipEnable(level, arr)
    local ret = {}
    local l = {}
    local r = {}
    for _, v in ipairs(arr) do
        if IsAdd2Left(v, level) then
            l[#l + 1] = v
        else
            r[#r + 1] = v
        end
    end
    --return l, r

    ret = l
    for _, v in ipairs(r) do
        ret[#ret + 1] = v
    end
    return ret
end
local function SortByEquipEnable(level, arr)
    local left = {}
    local right = {}
    for _, v in ipairs(arr) do
        if v['level'] - level >= 10 then
            right[#right + 1] = v
        else
            left[#left + 1] = v
        end
    end
    local ret = left
    for _, v in ipairs(right) do
        ret[#ret + 1] = v
    end
    return ret
end

local function dump(v)
    local ret = ""
    local id = "id:" .. v['id']
    local score = "score:" .. v.score
    local strengthen = "strengthen:" .. v.strengthen
    local rune = "rune:" .. v['rune']
    local level = "level:" .. v.level
    ret = ret .. " " ..id
    ret = ret .. " " ..score
    ret = ret .. " " ..strengthen
    ret = ret .. " " ..rune
    ret = ret .. " " ..level
    return ret
end
local function Sort(equips)
    local ret = SortByScore(equips)
    --[[
    for k, v in ipairs(ret) do
        print('装备评分排序:',k, dump(v))
    end
    print('***********************')
    ]]
    ret = SortByStrengthenAndRunne(ret)
    --[[
    for k, v in ipairs(ret) do
        print('铭文，强化:',k, dump(v))
    end
    print('***********************')
    ]]
    ret = SplitEquipEnable(5, ret)
    --[[
    for k, v in ipairs(ret) do
        print('能否装备:',k, dump(v))
    end
    print('***********************')
    ]]
    return ret
end


-- 测试数据
local equips = {}
equips[#equips + 1] = GetEquipConfig(100, 10, 0, 10, 1) -- 强化水平相等
equips[#equips + 1] = GetEquipConfig(200, 10, 10, 0, 2) -- 强化水平相等
equips[#equips + 1] = GetEquipConfig(300, 20, 10, 10, 3) -- 强化水平大于
equips[#equips + 1] = GetEquipConfig(200, 10, 2, 2, 4) -- 强化水平小于
equips[#equips + 1] = GetEquipConfig(400, 10, 2, 2, 5) -- 强化水平小于
equips[#equips + 1] = GetEquipConfig(700, 20, 0, 0, 6) -- 未被强化装备
equips[#equips + 1] = GetEquipConfig(500, 0, 0, 0, 7) -- 未被强化装备
equips[#equips + 1] = GetEquipConfig(200, 0, 0, 0, 8) -- 未被强化装备
equips[#equips + 1] = GetEquipConfig(800, 100, 0, 0, 9) -- 未被强化装备

for k, v in ipairs(equips) do
    print('Before', k, dump(v))
end
print("***************************")
local xx = Sort(equips)
