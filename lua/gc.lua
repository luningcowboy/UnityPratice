--[[
collectgarbage("collect") 做一次完整的垃圾收集循环
collectgarbage("count") 以K为单位返回Lua使用的内存数量
collectgarbage("restart")  重启垃圾回收器并自动运行
collectgarbage("setpause") 将arg设置为收集器的间歇率，返回间歇率的前一个值
collectgarbage("setstepmul") 返回步进倍率的前一个值
collectgarbage("step") 单步运行垃圾收集器， 步长大小由arg控制,传入0时，收集器步进一步
collectgarbage("stop") 停止垃圾收集器的工作,在重启前，收集器只会因显示的调用运行
--]]
mytable = {'apple', 'orange', 'banana'}
print(collectgarbage("count"))

mytable = nil
print(collectgarbage("count"))
print(collectgarbage("collect"))
print(collectgarbage("count"))

