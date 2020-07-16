
local Test = Class("TestNotification")

local Events = {
    MSG_1 = 'msg1',
    MSG_2 = 'msg2',
    MSG_3 = 'msg3',
    MSG_4 = 'msg4'
}

function Test:ctor()
    NotificationCenter.Listen(Events.MSG_1, self.MsgCallback1, self)
    NotificationCenter.Listen(Events.MSG_2, self.MsgCallback2, self)
    NotificationCenter.Listen(Events.MSG_3, self.MsgCallback3, self)
    NotificationCenter.Listen(Events.MSG_4, self.MsgCallback4, self)
end

function Test:dtor()
    print("Test:dtor")
    NotificationCenter.Dump()
    NotificationCenter.Ignore(Events.MSG_1, self.MsgCallback1, self)
    NotificationCenter.Dump()
    NotificationCenter.IgnoreScope(self)
    NotificationCenter.Dump()
    print("Test:dtor")
end

function Test:MsgCallback1(params)
    print("Test:MsgCallback1", params)
end
function Test:MsgCallback2(params)
    print("Test:MsgCallback2", params)
end
function Test:MsgCallback3(params)
    print("Test:MsgCallback3", params)
end
function Test:MsgCallback4(params)
    print("Test:MsgCallback4",params)
end

function Test:TestTrigger()
    NotificationCenter.Trigger(Events.MSG_1, "trigger msg_1")
    NotificationCenter.Trigger(Events.MSG_2, "trigger msg_2")
    NotificationCenter.Trigger(Events.MSG_3, "trigger msg_3")
    NotificationCenter.Trigger(Events.MSG_4, "trigger msg_4")
end

return Test
