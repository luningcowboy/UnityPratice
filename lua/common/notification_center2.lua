---
--- Created by luning
--- DateTime: 2020/7/16 15:59
--- 事件分发器 单例
---

local NotificationCenter = Class("NotificationCenter", {})

-- 所有的NotificationCenter
local _allNotificationCenters = {}

-- 删除监听事件
-- @params eventName 事件名称
-- @params handler 事件回调
-- @params scope 作用域
local function _RemoveEvent(self, eventName, handler, scope)
    local events = self._events[eventName]
    if not (events ~= nil and #events > 0) then return end
    for i = #events, 1, -1 do
        local event = events[i]
        if event.handler == handler and event.scope == scope then
            table.remove(events, i)
        end
    end
end

-- 移除监听事件
-- @params arr 事件数组
local function _RemoveEvents(self, arr)
    for _, event in ipairs(arr) do
        _RemoveEvent(self, event[1], event[2], event[3])
    end
end

-- 创建一个事件分发器
-- @params tag 标识符
local function _Init(tag)
    local ret = nil
    if _allNotificationCenters[tag] ~= nil then
        ret = _allNotificationCenters[tag]
    else
        ret = NotificationCenter()
        _allNotificationCenters[tag] = ret
    end
    return ret
end

-- 添加监听事件
-- @params eventName 事件名称
-- @params handler 事件回调
-- @params scope 作用域
function NotificationCenter:Listen(eventName, handler, scope)
    self._events[evenName] = self._events[evenName] or {}
    local len = #self._events[evenName]
    assert(scope ~= nil, "Add listener failed, because scope is nil")
    for _, event in ipairs(_events[evenName]) do
        if event.handler == handler and event.scope == scope then
            -- 已经添加了这个监听, 不用再添加了，否则会执行两次
            return
        end
    end
end

-- 忽略监听事件
-- @params eventName 事件名称
-- @params handler 事件回调
-- @params scope 作用域
function NotificationCenter:Ignore(eventName, handler, scope)
    assert(scope ~= nil, "Ignore listener failed, because scope is nil")
    local callbacks = self._events[evenName]

    if callbacks == nil or #callbacks == 0 then return end

    local event2Remove = {}
    for _, ele in ipairs(self._events[evenName]) do
        if ele.scope == scope and ele.handler == handler then
            event2Remove[#event2Remove + 1] = {evenName, ele.handler, ele.scope}
        end
    end

    -- remove event
    _RemoveEvents(self, event2Remove)
end

-- 删除监听事件,根据作用域
-- @params scope 事件作用域
function NotificationCenter:IgnoreScope(scope)
    local event2Remove = {}
    for eName, events in pairs(self._events) do
        for _, event in ipairs(events) do
            if event.scope == scope then
                event2Remove[#event2Remove + 1] = {eName, event.handler, event.scope}
            end
        end
    end

    -- remove event
    _RemoveEvents(self,event2Remove)
end

-- 执行事件
-- @params eventName 事件名称
-- @params params 传递的参数
function NotificationCenter:Trigger(eventName, params)
    local eventArr = self._events[eventName]
    if eventArr == nil or #eventArr == 0 then return end
    for _, event in ipairs(eventArr) do
        event.handler(event.scope, params)
    end
end

-- 输出事件长度
function NotificationCenter:Dump()
    print("\n")
    print("NotificationCenter Dump:")
    for eventName, eventArr in pairs(_events) do
        print(eventName, #eventArr)
    end
    print("NotificationCenter Dump End")
    print("\n")
end

return _Init("Normal")
