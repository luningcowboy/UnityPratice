local Mediator = Class("MVC.Mediator", MVC.Notifier)
Mediator.NAME = "Mediator"
function Mediator:Ctor(mediatorName, viewComponent)
    self.mediatorName = mediatorName
    self.viewComponent = viewComponent
end

function Mediator:GetMediatorName()
    return self.mediatorName
end

function Mediator:SetViewComponent(viewComponent)
    self.viewComponent = viewComponent
end

function Mediator:GetViewComponent()
    return self.viewComponent
end

function Mediator:ListNotificationInterests()
    return {}
end

function Mediator:handleNotification(notification)

end

function Mediator:OnRegister()
end

function Mediator:OnRemove()
end

return Mediator