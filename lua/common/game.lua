require 'modules'

local FPS = 60
local FrameTime = 17 / 1000

local function sleep(n)
    local t1 = os.clock()
    local t2 = os.clock()
    while t2 - t1 <= n do
        t2 = os.clock()
    end
end

local function update(dt)
    print("update", dt)
end
local function render()
    print("render")
end
local function eventDispatch()
    print("eventDispatch")
end

local function loop()
    local time = 0
    local dt = 0
    while true do
        time = os.time()
        update(dt / 1000)
        render()
        eventDispatch()
        dt = os.time() - time
        if dt < 17 then
            print("sleep", 0.017)
            sleep((17 - dt) / 1000)
            dt = 17
        end
    end
end

local function run()
    loop()
end

run()
