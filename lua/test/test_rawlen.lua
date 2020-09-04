-- rawlen返回table或者string的长度，不会触发__len
local t = {1,2,3,4, nil, 6, 7, 8}
local t2 = {a = 1, b = 2, nil, c = 3, d = 4}
local s = "hello"
print(rawlen(t)) -- 8
print(rawlen(t2)) -- 0
print(rawlen(s)) -- 5
print(rawlen("")) -- 0
