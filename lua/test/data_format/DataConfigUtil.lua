local Base = require 'ConfigBase'
Base.__inidex = Base
local DataConfigUtil = {}
setmetatable(DataConfigUtil, Base)

local _bindName
local _bindDesc


function _bindName(v)
    return 'name:' .. v
end

function _bindDesc(v)
    return 'desc:' .. v
end

DataConfigUtil.Init(function()
    return require 'data'
end)

-- do binds
DataConfigUtil.Bind('name', _bindName)
DataConfigUtil.Bind('desc', _bindDesc)

local function Load()
end

-- export
return DataConfigUtil
