co = coroutine.create(
    function(i)
        print(i)
    end
)

coroutine.resume(co, 1)
print(coroutine.status(co))

co = coroutine.wrap(
    function(i)
        print(i)
    end
)
co(1)

co2 = coroutine.create(
    function ()
        for i = 1, 10 do
            print(i)
            if i == 3 then
                print(coroutine.status(co2))
                print(coroutine.running())
            end
            coroutine.yield()
        end
    end
)

coroutine.resume(co2)
coroutine.resume(co2)
coroutine.resume(co2)
coroutine.resume(co2)

print(coroutine.status(co2))
print(coroutine.running())

function foo(a)
    print("foo a = ", a)
    return coroutine.yield(2 * a)
end

co = coroutine.create(function(a, b)
    print("第一次", a, b)
    local r = foo(a + 1)

    print("第二次", r)
    local r, s = coroutine.yield(a + b, a - b)

    print("第三次", r, s)
    return b, "结束"
end)

print("main", coroutine.resume(co, 1, 10))
print("--------")
print("main", coroutine.resume(co, "r"))
print("--------")
print("main", coroutine.resume(co, "x", "y"))
print("--------")
print("main", coroutine.resume(co, "x", "y"))
