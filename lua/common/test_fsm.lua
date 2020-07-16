function sleep(n)
    local t0 = os.clock()
    while os.clock() - t0 <= n do end
end

local index = 0
local fsm = FSM()
fsm:init({
        default = 'st1',
        stats = {
            st1 = {
                tag = 'st1',
                onEnter = function() print('onEnter') end,
                onExit = function() print('onExit') end,
                exec = function() print('exec') end
            },
            st2 = {
                tag = 'st2',
                onEnter = function() print('onEnter') end,
                onExit = function() print('onExit') end,
                exec = function() print('exec') end
            },
            st3 = {
                tag = 'st3',
                onEnter = function() print('onEnter') end,
                onExit = function() print('onExit') end,
                exec = function() print('exec') end
            }
        },
        rules = {
            {
                from = 'st1',
                to = 'st2',
                rule = function() return index >= 5 end
            },
            {
                from = 'st2',
                to = 'st3',
                rule = function() return index >= 10 end
            },
            {
                from = 'st3',
                to = 'st1',
                rule = function() return index >= 15 end
            }
    }})



fsm:active()
while (true)
do
    sleep(1)
    print('loop', index)
    index = index + 1
    fsm:update()
    fsm:printCurrentStat()
end
