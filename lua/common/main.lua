require 'modules'

local function Test1()
    local TestNotification = require("test_notification")
    print(TestNotification)

    local test = TestNotification()
    test:ctor()
    test:TestTrigger()
    test:dtor()
end

local function Test2()
end

