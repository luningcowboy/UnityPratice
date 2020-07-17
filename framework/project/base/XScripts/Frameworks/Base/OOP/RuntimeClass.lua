--[[
    不含约束性的Class，在发布时使用
 ]]
local Class = {}

local setmetatable = setmetatable
local type = type

local _classes = {}
local _metatable = {}
setmetatable(Class, _metatable)

_metatable.__call = function(t, className, super)
    local tableNewClass = {}
    local tableClassData = {
        className = className, --类名
        super = super, --父类
        category = "Class", --类型
        Ctor = false,
        Dtor = false
    }
    _classes[tableNewClass] = tableClassData

    setmetatable(
        tableNewClass,
        {
            __newindex = function(t, k, v)
                tableClassData[k] = v
            end,
            __index = function(t, k)
                return tableClassData[k]
            end,
            __call = function(t, ...)
                local tableNewObject = {}
                local tableObjectData = {
                    type = tableNewClass, --类类型
                    category = "Instance" --类型
                }
                setmetatable(tableObjectData, _classes[tableNewClass])
                setmetatable(
                    tableNewObject,
                    {
                        __newindex = function(t, k, v)
                            tableObjectData[k] = v
                        end,
                        __index = function(t, k)
                            if tableObjectData[k] ~= nil then
                                return tableObjectData[k]
                            else
                                local result = _classes[tableNewClass][k]
                                tableObjectData[k] = result
                                return result
                            end
                        end
                    }
                )

                do
                    local Create
                    Create = function(class, ...)
                        if type(class.super) == "table" then
                            Create(class.super, ...)
                        end
                        if type(class.Ctor) == "function" then
                            class.Ctor(tableNewObject, ...)
                        end
                    end
                    Create(tableNewClass, ...)
                end

                tableNewObject.Dispose = function(self)
                    local currentClass = self.type
                    while currentClass ~= nil do
                        if currentClass.Dtor then
                            currentClass.Dtor(self)
                        end
                        currentClass = currentClass.super
                    end
                end
                return tableNewObject
            end
        }
    )

    if super and type(super) == "table" then
        setmetatable(
            tableClassData,
            {
                __index = function(t, k)
                    local result = _classes[super][k]
                    tableClassData[k] = result
                    return result
                end
            }
        )
    end

    return tableNewClass
end

return Class
