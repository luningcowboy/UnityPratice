local function foo()
    local a = 1
    local b = 1
    local c = 1
    local n, v = debug.getlocal(1,2)
    print(n, v)
    local d = debug.gethook()
    print(d)
end
foo()
