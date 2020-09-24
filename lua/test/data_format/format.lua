local assert = assert
local format = {}
local _data = nil
local _binds = {}
local _keys = {}

-- 函数声明
local Init
local Bind
local InitKeys
local _bindDefault
local _bindName
local _bindDesc
local GetDataByKeys


-- 方法实现
function Init()
    _data = require 'data'
    Bind()
    InitKeys()
end

function InitKeys()
    local keys = _data.key
    for k, v in pairs(keys) do
        _keys[#_keys + 1] = k
    end
end

-- 绑定处理
function Bind()
    _binds.name = _bindName
    _binds.desc = _bindDesc
end

-- 默认处理方法
function _bindDefault(v)
    return v
end

-- 处理name
function _bindName(v)
    return v
end

-- 处理desc
function _bindDesc(v)
    return v
end

-- 根据tempId和selectKeys获取值
function GetDataByKeys(tempId, selectKeys)
    -- selectKeys == nil, 取全部的值
    selectKeys = selectKeys or _keys

    local ret = {}
    local tmpData = _data.config[tempId]
    local keys = _data.key
    assert(tmpData ~= nil, "GetDataByKeys failed templateId = " .. tempId)
    local id = -1
    local v = nil
    local s = nil
    local func = nil
    for _, k in pairs(selectKeys) do
        id = keys[k]
        v = tmpData[id]
        func = _binds[k] and _binds[k] or _bindDefault
        s, v = pcall(func, v)
        if not s then
            error("GetDataByKeys failed key = " .. k)
        end
        ret[k] = v
    end
    return ret
end

-- 函数导出
local Format = {}
Format.Init = Init
Format.GetDataByKeys = GetDataByKeys

return Format
