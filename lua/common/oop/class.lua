local Class = {}
local setmetatable = setmetatable
local type = type
local assert = assert

local _names = {}
local _metatable = {}
setmetatable(Class, _metatable)

_metatable.__call = function(t, className, super)
    assert(type(className) == 'string' and #className > 0)
    assert(_names[className] == nil, "Class [" .. className .. "] already exist")

    local tableNewClass = {
        className = className,
        super = super,
        category = "Class",
        Ctor = false,
        Dtor = false
    }

    setmetatable(tableNewClass, tableNewClass)
    tableNewClass.__index = super

    tableNewClass.__call = function(t, ...)
        local tableNewObject = {
            type = tableNewClass,
            category = "Instance"
        }

        tableNewObject.__index = tableNewClass
        setmetatable(tableNewObject, tableNewObject)

        do
            local Create
            Create = function(class, ...)
                if type(class.super) == 'table' then
                    Class(class.super, ...)
                end
                if type(class.Ctor) == 'function' then
                    class.Ctor(tableNewObject, ...)
                end
            end
            Create(tableNewClass, ...)
        end

        tableNewObject.Dispose = function(self)
            local currentClass = self.type
            while currentClass ~= nil do
                if type(currentClass.Dtor) == 'function' then
                    currentClass.Dtor(self)
                end
                currentClass = currentClass.super
            end
        end
        return tableNewObject
    end

    _names[className] = tableNewClass
    return tableNewClass
end

return Class
