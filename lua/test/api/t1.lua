-- _G
-- 所有的全局变量都会保存到_G中,为了避免全局变量污染，一般在程序的入口都禁用全局
-- 变量的定义
print(_G) -- 全局变量
-- 禁用全局变量
function LimitGlobalVariable()
    setmetatable(
        _G,
        {
            __indexnew = function(t, k, v)
                print("Error, not permit to add global variable。")
            end
        })
end

-- _VERSION 保存当前Lua版本号
print(_VERSION) -- 输出版本号

-- assert 断言
-- 第一个参数为false时，中断程序，报错
-- 第二个参数为报错信息
-- assert(true, "true message")
-- assert(false, "false message")

-- collectgarbage
-- 一个通用的垃圾回收接口
-- collectgarbage([opt[, arg]])
-- opt有多种操作:
-- collect: 默认参数，执行一个全部的垃圾回收循环
-- stop: 停止自动垃圾回收器
-- restart: 重启自动垃圾回收器
-- count: 获取Lua使用的总内存，单位KB
-- setp: 执行一步垃圾回收
-- setppause: 将arg设置为垃圾回收器暂停的新值,并返回当前暂停的值
-- setstepmul: 将arg设置为
-- isrunning: 返回垃圾回收器是否在运行

-- coroutine.create(f)
-- 创建一个新的协程, 类型为thread
local function testCoroutine() 
    print('testCoroutine')
end
local testcor = coroutine.create(testCoroutine)
print(type(testcor))
