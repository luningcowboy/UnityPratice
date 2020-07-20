---
--- FileName: TimerEvent.lua
--- Created by lu ning
--- DateTime: 2020/07/20 11:37
--- Desc:
---

--@class TimerEvent
local TimerEvent = Class("TimerEvent")

-------------------私有方法-------------------
---执行事件
---@param info timer信息
local function Trigger(self, info)
    if info ~= nil then
        info.callback(info.scope)
        info.curTimes = info.curTimes + 1
    end
    if info.repeatTimes ~= -1 and info.curTimes >= info.repeatTimes then
        self:Remove(info.scope, info.callback)
    end
end

-------------------公有方法-------------------
--构造函数
function TimerEvent:Ctor()
    self._timerEvent = {}
    -- 添加Update监听事件
end

---获取所有的Timer
function TimerEvent:GetTimerEvents()
    return self._timerEvent
end

function TimerEvent:IsAdd(info2Add)
    local ret = true
    for _, info in ipairs(self._timerEvent) do
        if info.scope == info2Add.scope and info.callback == info2Add.callback then
            ret = false
            break
        end
    end
    return ret
end

--- 添加新Timer
---@param scope 作用域
---@param callback 回调
---@param dt 每次调用的时间间隔
---@param repeatTimes -1 或者 >= 1的数
---@param triggerAtOnce 会在Add的时候执行一次
function TimerEvent:Add(scope, callback, dt, repeatTimes, triggerAtOnce)
    repeatTimes = repeatTimes or -1
    triggerAtOnce = triggerAtOnce or false

    local timerInfo = {
        scope = scope,
        callback = callback,
        dt = dt,
        repeatTimes = repeatTimes,
        curTimes = 0,
        curDt = 0
    }

    -- Check
    if not self:IsAdd(timerInfo) then
        return
    end

    -- Add
    self._timerEvent[#self._timerEvent + 1] = timerInfo
    if triggerAtOnce then
        Trigger(self, self._timerEvent[#self._timerEvent])
    end
end

-- 监听更新事件
---@param dt
function TimerEvent:Update(dt)
    for _, info in ipairs(self._timerEvent) do
        info.curDt = info.curDt + dt
        if info.curDt >= info.dt then
            Trigger(self, info)
        end
    end
end

---根据作用域移除Timer
---@param scope
function TimerEvent:RemoveByScope(scope)
    local len = #self._timerEvent
    local idx = len
    while idx >= 1 do
        local info = self._timerEvent[idx]
        if info.scope == scope then
            table.remove(self._timerEvent, idx)
        end
        idx = idx - 1
    end
end

---根据Handler和Scope移除Timer
---@param handler
---@param scope
function TimerEvent:Remove(scope, callback)
    local len = #self._timerEvent
    local idx = len
    while idx >= 1 do
        local info = self._timerEvent[idx]
        if info ~= nil and info.scope == scope and info.callback == callback then
            table.remove(self._timerEvent, idx)
            break
        end
        idx = idx - 1
    end
end

return TimerEvent()
