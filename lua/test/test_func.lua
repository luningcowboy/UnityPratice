local function func1()
end
func1.__call = function() print("new") end
print(func1)
