local function Format(...)
    local ret = ""
    local arr = {...}
    print(arr)
    for _,info in ipairs(arr) do
        ret = ret .. " " .. info
    end
    return ret
end

print(Format("a","b"))
print(type("abc"))
print("abc")
