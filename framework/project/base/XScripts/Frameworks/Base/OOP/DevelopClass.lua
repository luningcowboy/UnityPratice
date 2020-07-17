--[[
    具有约束性的Class，在开发时使用
 ]]
local Class = {}

local setmetatable = setmetatable
local type = type
local assert = assert
local error = error

local _classes = {}
local _names = {}
local _metatable = {}
setmetatable(Class, _metatable)

_metatable.__call = function(t, className, super)
    assert(type(className) == "string" and #className > 0)
    assert(_names[className] == nil)

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
            __index = tableClassData,
            __newindex = function(t, k, v)
                --对只读key赋值时，抛出错误
                assert(
                    k ~= "className" and k ~= "super" and k ~= "category",
                    "Attempt to update a read-only key [" .. k .. "] in class [" .. t.className .. "]"
                )
                --Ctor和Dtor必须是function类型
                if k == "Ctor" or k == "Dtor" then
                    assert(type(v) == "function", "[" .. k .. "] in class [" .. t.className .. "] must be a function")
                end
                tableClassData[k] = v
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
                            assert(
                                k ~= "type" and k ~= "category",
                                "Attempt to update a read-only key [" ..
                                    k .. "] in instance of [" .. t.type.className .. "]"
                            )
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
    _names[className] = tableNewClass
    return tableNewClass
end

return Class
