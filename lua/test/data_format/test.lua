local Format = require 'format'
Format.Init()


local d = Format.GetDataByKeys(1)
print(d.id, d.name, d.desc)

local d1 = Format.GetDataByKeys(1, {'name', 'desc'})
print(d1.name, d1.desc)

local DT = require 'DataConfigUtil'

local d2 = DT.GetDataByKeys(1)
--print(d2.id, d.name, d.desc)
--[[
local t = {}
local t2 = {}
t2.__index = t2
function t2.Init()
    print('Init')
end

print(t, t2)
setmetatable(t, t2)

t.Init()
]]
