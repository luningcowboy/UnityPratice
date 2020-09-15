local function addMapEntry(map, pair)
    map[pair[1]] = map[pair[2]]
    return map
end
return addMapEntry
