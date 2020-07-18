local Notifier = Class("MVC.Notifier",{})

function Notifier:Ctor() end

function Notifier:SendNotification(notificationName, body, type) 
    local facade = self:GetFacade()
    if facade ~= nil then
        facade.SendNotification(notificationName, body, type)
    end
end
function Notifier:InitializeNotifier(key) 
    self.multitonKey = key
    self.facade = self:GetFacade()
end

function Notifier:GetFacade()
    if self.multitonKey == nil then
        error(Notifier.MULTITON_MSG)
    end
    return MVC.Facade.GetInstance(self.multitonKey)
end

Notifier.MULTITON_MSG = "multitonKey for this Notifier not yet initialized!"
return Notifier