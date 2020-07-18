local SimpleCommand = Class("MVC.SimpleCommand", MVC.Notifier)
function SimpleCommand:Ctor()
    self.super:Ctor(self)
end
function SimpleCommand:Execute(notification) end
return SimpleCommand