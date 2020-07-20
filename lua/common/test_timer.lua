local TestTimer = Class("TestTimer")

function TestTimer:Ctor()
    Timer:Add(self, TestTimer.Callback1, 1, 5)
    Timer:Add(self, TestTimer.Callback2, 1, -1)
    Timer:Add(self, TestTimer.Callback3, 1)
    self._c1 = 0
    self._c2 = 0
    self._c3 = 0
end

function TestTimer:Dtor()
    print("TestTimer:Dtor")
    --Timer:RemoveByScope(self)
    Timer:Remove(self, TestTimer.Callback2)
    Timer:Remove(self, TestTimer.Callback3)
end

function TestTimer:Callback1()
    self._c1 = self._c1 + 1
    print("TestTimer:Callback1", self._c1)
end
function TestTimer:Callback2()
    self._c2 = self._c2 + 1
    print("TestTimer:Callback2", self._c2)
end
function TestTimer:Callback3()
    self._c3 = self._c3 + 1
    print("TestTimer:Callback3", self._c3)
end

return TestTimer
