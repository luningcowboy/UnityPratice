---
--- Created by luning
--- DateTime: 2020/7/16 15:59
--- 事件分发器
---

---事件分发器
---@class NotificationCenter
local NotificationCenter = Class("NotificationCenter", {})

---构造函数
---@param self NotificationCenter
local function Ctor(self) 
    ---@type table
    self._events = {};
end

---添加监听事件
---@param eventName string 事件名称
---@param handler function 事件回调
---@param scope table 作用域
---@return void
function NotificationCenter:Listen(eventName, handler, scope)
    self._events[eventName] = self._events[eventName] or {}
    local eventList = self._events[eventName];
    assert(scope ~= nil, "Add listener failed, because scope is nil")
    for _, event in ipairs(eventList) do
        if event.handler == handler and event.scope == scope then
            -- 已经添加了这个监听, 不用再添加了，否则会执行两次
            return
        end
    end
    
    --添加到列表中
    eventList[#eventList + 1] = {handler = handler, scope = scope};
end

---删除监听一个事件
---@param eventName string 事件名称
---@param handler function 事件回调
---@param scope table 作用域
function NotificationCenter:Ignore(eventName, handler, scope)
    assert(scope ~= nil, "Ignore listener failed, because scope is nil")
    local callbacks = self._events[eventName]

    if callbacks == nil or #callbacks == 0 then 
        return 
    end

    for i, ele in ipairs(callbacks) do
        if ele.scope == scope and ele.handler == handler then
            table.remove(callbacks, i)
            break
        end
    end
end

---删除监听事件,根据作用域
---@param scope table 事件作用域
function NotificationCenter:IgnoreScope(scope)
    for _, events in pairs(self._events) do
        for i = #events, 1, -1 do
            local event = events[i]
            if event.scope == scope then
                table.remove(events, i)
            end
        end
    end
end

---执行事件
---@param eventName string   事件名称
---@param ... any 传递的参数
---@return void
function NotificationCenter:Trigger(eventName, ...)
    local eventArr = self._events[eventName]
    if eventArr == nil or #eventArr == 0 then return end
    for _, event in ipairs(eventArr) do
        event.handler(event.scope, ...)
    end
end

---输出事件长度
function NotificationCenter:Dump()
    print("\nNotificationCenter Dump:")
    for eventName, eventArr in pairs(self._events) do
        print(eventName, #eventArr)
    end
    print("NotificationCenter Dump End\n")
end

NotificationCenter.Ctor = Ctor

return NotificationCenter()

