---
--- FileName: TimerEvent.lua
--- Created by lu ning
--- DateTime: 2020/07/20 11:37
--- Desc:
---

--@class TimerEvent
local TimerEvent = Class("TimerEvent")

function TimerEvent:Ctor()
    self._timerEvent = {}
    -- 添加Update监听事件
end

--- 添加新Timer
---@param scope
---@param handler
function TimerEvent:Add(scope, callback, dt, repeatTimes, triggerAtOnce)
    triggerAtOnce = triggerAtOnce or false
    repeatTimes = repeatTimes or -1
    local timerInfo = {
        scope = scope,
        callback = callback,
        dt = dt,
        repeatTimes = repeatTimes,
        curTimes = 0,
        curDt = 0
    }
    self._timerEvent[#self._timerEvent + 1] = timerInfo
    if triggerAtOnce then
        self:Trigger(self._timerEvent[#self._timerEvent])
    end
end

-- 监听更新事件
---@param dt
function TimerEvent:Update(dt)
    for _, info in ipairs(self._timerEvent) do
        info.curDt = info.curDt + dt
        if info.curDt >= info.dt then
            self:Trigger(info)
        end
    end
end

---根据作用域移除Timer
---@param scope
function TimerEvent:RemoveByScope(scope)
    print("TimerEvent:RemoveByScope", #self._timerEvent)
    local len = #self._timerEvent
    local idx = len
    while idx >= 1 do
        local info = self._timerEvent[idx]
        if info.scope == scope then
            table.remove(self._timerEvent, idx)
        end
        idx = idx - 1
    end
    print("TimerEvent:RemoveByScope", #self._timerEvent)
end

---根据Handler和Scope移除Timer
---@param handler
---@param scope
function TimerEvent:Remove(scope, callback)
    print("TimerEvent:Remove", #self._timerEvent)
    local len = #self._timerEvent
    local idx = len
    while idx >= 1 do
        local info = self._timerEvent[idx]
        print("TimerEvent:Remove", idx, info, info.callback == callback, info.scope == scope)
        if info ~= nil and info.scope == scope and info.callback == callback then
            table.remove(self._timerEvent, idx)
            break
        end
        idx = idx - 1
    end
    print("TimerEvent:Remove", #self._timerEvent)
end

---执行事件
---@param info timer信息
function TimerEvent:Trigger(info)
    if info ~= nil then
        info.callback(info.scope)
        info.curTimes = info.curTimes + 1
    end
    if info.repeatTimes ~= -1 and info.curTimes >= info.repeatTimes then
        self:Remove(info.scope, info.callback)
    end
end

return TimerEvent()
