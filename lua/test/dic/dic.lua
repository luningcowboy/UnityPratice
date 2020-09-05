local Dic = {}
local _M = {
    __call = function()
        local dic = {}
        local len = 0
        local m = {
            __len = function(t) 
                return len
            end,
            __newindex = function(t,k,v)
                len = len + 1
                rawset(t,k,v)
            end
        }
        setmetatable(dic, m)
        return dic
    end
}
setmetatable(Dic, _M)
--Test
local a = Dic()
local b = Dic()
print("a:" .. #a)
a.a = 1
a.b = nil
a.c = ""
print("a:" .. #a)
for i = 1, 10 do
    b[#b+1] = i
end
b[#b+1] = nil
b.a = nil
print("b:" .. #b)

return Dic
