--- a test module
-- @module test

local test = {}

--- this is a function
-- @string param1 this is param1
-- @int param2 this is param2
-- @return a string value
function test.my_module_function_1(param1, param2)
	return param1 .. param2
end

return test
