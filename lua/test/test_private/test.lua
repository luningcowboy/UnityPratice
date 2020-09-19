local func1
local func2
local func3
bgm = 100

function func1()
    print("func1")
end

function func2()
    print("func2")
end

function func3()
    print("func3")
end

func1()
func2()
func3()

print(_G.func1)
print(_G.bgm)
