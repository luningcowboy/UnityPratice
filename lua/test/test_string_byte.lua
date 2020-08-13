--local str = "012abcd"
local str = "33DH6DDE62D2$4E03BE41-641D-5C99-B378-89556BDB4E6C"
--local bytes = string.byte(str, 1, string.len(str))
local bytes = str:byte(1, string.len(str))
print(bytes)
print(type(bytes))
--print(str:byte(1, string.len(str)))
local t = string.char(221)
print(t, t:byte())
