local assert = assert

----基础类，用闭包实现，不支持继承
local function BaseData(dataName)
    -- attribute
    local _data = {}
    local _binds = {}
    local _keys = {}
    local _dataName = dataName

    -- public
    local Init
    local Bind
    local InitKeys
    local GetDataByKeys
    local GetOriginData

    -- private
    local _load
    local _bindDefault

    -- 初始化
    function Init()
        _load(_dataName)
        InitKeys()
    end

    -- 绑定属性处理回调
    -- @param #string name 属性名称
    -- @param #function callback 属性处理回调
    function Bind(name, callback)
        _binds[name] = callback
    end

    -- 初始化
    function InitKeys()
        local keys = _data.key
        for k, v in pairs(keys) do
            _keys[#_keys + 1] = k
        end
    end

    -- 获取数据
    -- @param #number tempId 模版id
    -- @param #array selectKeys 需要导出的属性,不传导出所有属性
    function GetDataByKeys(tempId, selectKeys)
        selectKeys = selectKeys or _keys

        local ret = {}
        local tmpData = _data.config[tempId]
        local keys = _data.key
        local id = -1
        local v = nil
        local s = nil
        local func = nil

        assert(tmpData ~= nil, "GetDataByKeys failed templateId = " .. tempId)

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

    -- 获取原始数据
    -- @param #number 模版id
    function GetOriginData(tempId)
        local ret = _data.config[tempId]
        assert(ret, 'GetOriginData fialed tempId = ' .. tempId)
        return ret
    end

    -- 加载数据
    -- @param #string name 数据路径
    function _load(name)
        local ret = require tostring(name)
        local s, r = pcall(ret, name)
        assert(s, '_load ' .. name .. ' failed')

        _data = r
    end

    -- 默认处理方法
    -- @param #table v 任何数据类型
    function _bindDefault(v)
        return v
    end

    -- 导出
    local export = {}

    export.Init = Init
    export.Bind = Bind
    export.GetDataByKeys = GetDataByKeys
    export.GetOriginData = GetOriginData

    return export
end
----------------------------------
--数据实现，每个excel对应一个BaseData,
--BaseData只提供必要的接口，不支持扩展，扩展在Collect中做
local DataCollect = {}
local _datas = {}
local _dataKeys = {'data', 'data'}
local _bindName

local function Init()
    _datas = {}
    for _, v in pairs(_dataKeys) do
        _datas[v] = BaseData(v)
        _datas[v].Init()
    end
    DoBind()
end

local function GetDataByDataKey(tempId, selectKeys, key)
    if not key then
        key = _dataKeys[0]
    end
    local data = _datas[key]
    assert(data, 'GetDataByDataKey failed')
    return data.GetDataByKeys(tempId, selectKeys)
end

-- 自己做绑定
local function DoBind()
    _datas[1].Bind('name', _bindName)

end

function _bindName(v)
    return 'Name:' .. v
end

DataCollect.Init = Init
DataCollect.GetDataByDataKey = GetDataByDataKey
DataCollect.DoBind = DoBind
