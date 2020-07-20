require 'modules'

local FPS = 60
local FrameTime = 17 / 1000

local testTimer = TestTimer()
local index = 0

local function sleep(n)
    local t1 = os.clock()
    local t2 = os.clock()
    while t2 - t1 <= n do
        t2 = os.clock()
    end
end

local function update(dt)
    Timer:Update(dt)
end
local function render()
end
local function eventDispatch()
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
            sleep((17 - dt) / 1000)
            dt = 17
        end

        index = index + 1
        if index == 100 then
            testTimer:Dtor()
            testTimer = nil
        end

    end
end

local function run()
    loop()
end

run()
