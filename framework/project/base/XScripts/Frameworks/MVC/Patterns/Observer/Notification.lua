local Notification = Class("Notification", {})

function Notification:Ctor(name, body, type)
    self.name = name
    self.body = body
    self.type = type
end

function Notification:GetName()
    return self.name
end
function Notification:SetBody(body)
    self.body = body
end
function Notification:GetBody()
    return self.body
end
function Notification:SetType(type)
    self.type = type
end
function Notification:GetType()
    return self.type
end
function Notification:ToString()
    local msg = "Notification Name:" .. self:GetName()
    msg = msg .. "\nBody:" .. tostring(self:GetBody())
    msg = msg .. "\nType:" .. self:GetType()
    return msg
end

return Notification
