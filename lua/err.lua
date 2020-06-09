local function add(a, b)
    assert(type(a) == 'number', 'a 不是一个数字')
    assert(type(b) == 'number', 'b 不是一个数字')
    return a + b
end

add(10, 11)

pcall(function(i) print(i) end, 22)
pcall(function(i) print(i) error('error...') end, 33)
--error('test error')
--xpcall 类似try..catch
xpcall(
    function(i)
        print(i)
        error('error')
    end,
    function()
        print(debug.traceback())
    end, 13)

function myfunc()
    n = n / nil
end

function myerrorhandler(err)
    print("Error:", err)
end
status = xpcall(myfunc, myerrorhandler)
print(status)
