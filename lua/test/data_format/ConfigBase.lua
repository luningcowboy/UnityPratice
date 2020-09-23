local Base = {}

-- public
local Init
local DoBind
local Bind
local GetDataByKeys
local GetOriginalDataByTempId

-- private
local _bindDefault
local _initKeys
-- attribute
local _data
local _keys = {}
local _binds = {}

-- public implement

-- 初始化
-- @param #function reqFunc require放到一个Function中,通过pcall调用
function Init(reqFunc, ...)
    local s, r = pcall(reqFunc, ...)
    assert(s, "require data failed")
    assert(r, 'get data failed')
    _data = r
    _initKeys()
end

function Bind(key, func)
    _binds[key] = func
end

function GetDataByKeys(tempId, selectKeys)
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

-- 获取原始数据接口
-- @param #number tempId
-- @return #table
function GetOriginalDataByTempId(tempId)
    local ret = nil
    assert(ret, "GetOriginalDataByTempId id=" .. tempId)
    return ret
end

-- private implement

-- 默认绑定方法
-- @param #table v 穿出的数值
-- @return #table 返回的数值
function _bindDefault(v)
    return v
end

function _initKeys()
    local keys = _data.key
    for k, v in pairs(keys) do
        _keys[#_keys + 1] = k
    end
end

-- export
Base.Init = Init
Base.DoBind = DoBind
Base.Bind = Bind
Base.GetDataByKeys = GetDataByKeys
Base.GetOriginalDataByTempId = GetOriginalDataByTempId


return Base
