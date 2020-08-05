local equipList = {
    [22750669127549953] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 3,
        ["equip_id"] = 22750669127549953,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669169492993] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 12,
        ["equip_id"] = 22750669169492993,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669161104385] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 11,
        ["equip_id"] = 22750669161104385,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669156910081] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 10,
        ["equip_id"] = 22750669156910081,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669152715777] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 9,
        ["equip_id"] = 22750669152715777,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669148521473] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 8,
        ["equip_id"] = 22750669148521473,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669119161345] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 2,
        ["equip_id"] = 22750669119161345,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669144327169] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 7,
        ["equip_id"] = 22750669144327169,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669140132865] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 6,
        ["equip_id"] = 22750669140132865,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669135938561] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 5,
        ["equip_id"] = 22750669135938561,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669131744257] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 4,
        ["equip_id"] = 22750669131744257,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
    [22750669114967041] =
    {
        ["rune_level"] = 0,
        ["template_id"] = 1,
        ["equip_id"] = 22750669114967041,
        ["hero_id"] = 0,
        ["enhance_level"] = 0,
    },
}
print("HelloWorld")
local function dump1(t)
    for k, v in pairs(t) do
        print('dump1', k, v['equip_id'])
    end
end
local function dump2(t)
    for i, v in ipairs(t) do
        print('dump2', i, v['equip_id'])
    end
end
local function toArray(dic)
    local ret = {}
    for _, v in pairs(dic) do
        ret[#ret + 1] = v
    end
    return ret
end
local function checkSort(a, b)
    if not a or not b then return false end
    local idA = a['equip_id']
    local idB = b['equip_id']
    if idA == idB then return false end
    return idA < idB
end

dump1(equipList)
local list = toArray(equipList)
dump1(list)
table.sort(list, checkSort)
print(#list)
dump2(list)

