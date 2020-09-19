local FSM = {}

--[[
{
    init = stat_name,
    stats = {
        stat1 = {
            target: target,
            changeStat: function,
            onEnter: function,
            onExit: function,
            to: stat-name
        },
        stat2 = {
            target: target,
            changeStat: function,
            onEnter: function,
            onExit: function,
            to: stat-name
        },
    }
}
--]]
function FSM:new(o, conf)
    o = o or {}
    setmetatable(o, self)
    self.__index = self
    self._conf = conf
    self:Init()
    return o
end

-- 初始化
function FSM:Init()
    local curStatName = self._conf.init
    self._curStat = self._conf.stats[curStatName]
    self._actived = false
    self._paused = false
    self._preStat = nil -- 上一个状态
end

-- 激活状态机
function FSM:Active()
    self._actived = true
end

-- 关闭状态机
function FSM:Inactive()
    self._actived = false
end

-- 状态更新
-- 需要外部调用
function FSM:Update()
    if self._actived and (not self._paused) then
        self:_DoCheck()
    end
end

-- 暂停状态机
function FSM:Pause()
    self._paused = false
end

-- 恢复状态机
function FSM:Resume()
    self._paused = false
end

-- 重置状态机
-- 恢复到默认状态
function FSM:Reset()
end

-- 输出状态日志
function FSM:Dump()
end

-- 是否已经暂停
function FSM:Paused()
    return self._paused
end

-- 是否已经激活
function FSM:Actived()
    return self._actived
end

-- 检测
-- target: target,
-- changeStat: function,
-- onEnter: function,
-- onExit: function
function FSM:_DoCheck()
    local stats = self._conf.stats
    local curStat = self._curStat
    local funcChangeStat = curStat.changeStat
    local funcExit = curStat
    local target = curStat.target
    local stat, ret = pcall(funcChangeStat, target)
    if ret then
        local toStat = self._conf[curStat.to]
        local toTarget = toStat.target
        local funcEnter = toStat.onEnter
        self._preStat = self._curStat
        self._curStat = toStat
        local s, r = pcall(funcExit, target)
        s, r = pcall(funcEnter, target)
    end
end

return FSM

