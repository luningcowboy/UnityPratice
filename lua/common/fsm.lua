---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by lu ning
--- DateTime: 2020/7/10 11:36
--- 简单的有限状态机,通过配置初始化
---

local FSM = Class('FSM')

-- 初始化FSM
-- @param conf 状态机配置文件
function FSM:init(conf)
    self._conf = conf
    self:_prepareStat()
end

--- 激活FSM
--- @return
function FSM:active()
    self._actived = true
end

--- 关闭FSM
--- @return
function FSM:deactive()
    self._actived = false
    self:reset(false)
end

--- 暂停状态机刷新，暂停后update方法不再执行
--- 可以通过resume恢复
--- @return
function FSM:pause()
    self._paused = true
end

--- 恢复状态机的运行
--- @return
function FSM:resume()
    self._paused = false
end

--- 重置状态机
--- @isActive 是否激活
function FSM:reset(isActive)
    self:_prepareStat()
    if isActive then
        self:active()
    end
end

--- 状态机更新
--- @return
function FSM:update()
    if not self:_isUpdate() then return end
    self:_doCheck()
end

--- 打印当前状态
function FSM:printCurrentStat()
    print('CurrentStat:', self._currentStat.tag)
end

--- 是否执行状态机更新
function FSM:_isUpdate()
    return not self._paused and self._actived
end

--- 检测是否切换状态
function FSM:_doCheck()
    local rules = self._conf.rules
    for _, rule in pairs(rules) do
        if rule.from == self._currentStat.tag then
            if rule.rule() then
                self:_switchStat(rule.to)
            end
        end
    end
end

-- 切换到指定状态
function FSM:_switchStat(to)
    local toStat = self._conf.stats[to]
    --assert(toStat == nil, 'Switch stat failed!!')
    self._currentStat.onExit()
    self._currentStat = toStat
    toStat.onEnter()
    toStat.exec()
end

--- 初始化
function FSM:_prepareStat()
    self._currentStat = self._conf.stats[self._conf.default]
    self._actived = false
    self._paused = false
end

return FSM