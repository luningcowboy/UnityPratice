local Observer = Class("MVC.Observer", {})

function Observer:Ctor(notifyMethod, notifyContext)
    self:SetNotifyMethod(notifyMethod)
    self:SetNotifyContext(notifyContext)
end

function Observer:SetNotifyMethod(notifyMethod)
    self.notify = notifyMethod
end

function Observer:SetNotifyContext(notifyContext)
    self.context = notifyContext
end

function Observer:GetNotifyMethod()
    return self.notify
end
function Observer:GetNotifyContext()
    return self.context
end

return Observer