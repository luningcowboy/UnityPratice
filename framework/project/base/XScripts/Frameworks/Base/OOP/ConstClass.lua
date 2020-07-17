--[[
    常量类，一经创建，将会阻止一切之后的修改
 ]]
local ConstClass = {}

local setmetatable = setmetatable
local getmetatable = getmetatable
local type = type
local pairs = pairs
local assert = assert
local error = error

local _names = {}
local _metatable = {}
setmetatable(ConstClass, _metatable)

local function Clone(object)
    local temp = {}

    local function CloneProcess(innerObject)
        if type(innerObject) ~= "table" then
            return innerObject
        elseif temp[innerObject] ~= nil then
            return temp[innerObject]
        end

        local newObject = {}
        temp[innerObject] = newObject
        for k, v in pairs(innerObject) do
            newObject[CloneProcess(k)] = CloneProcess(v)
        end
        return setmetatable(newObject, getmetatable(innerObject))
    end

    return CloneProcess(object)
end

_metatable.__call = function(t, name, tableSource, super)
    assert(type(name) == "string" and #name > 0)
    assert(_names[name] == nil)
    assert(type(tableSource) == "table")
    assert(super == nil or type(super) == "table")

    local tableNewClass = super and Clone(super) or {}

    for k, v in pairs(tableSource) do
        tableNewClass[k] = v
    end

    tableNewClass.name = name
    tableNewClass.category = "ConstClass"

    tableNewClass.__index = tableNewClass

    tableNewClass.__newindex = function(t, k, v)
        error("\nConstClass : [" .. name .. "] cannot be modified", 2)
    end

    _names[name] = tableNewClass
    return setmetatable({}, tableNewClass)
end

return ConstClass
