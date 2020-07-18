local Proxy = Class("MVC.Proxy", MVC.Notifier)
Proxy.NAME = "Proxy"
function Proxy:Ctor(proxyName, data)
    self.proxyName = proxyName or Proxy.NAME
    if data ~= nil then
        self:SetData(data)
    end
end
function Proxy:GetProxyName()
    return self.proxyName
end
function Proxy:SetData(data)
    self.data = data
end
function Proxy:GetData()
    return self.data
end
function Proxy:OnRegister()
end
function Proxy:OnRemove()
end

return Proxy