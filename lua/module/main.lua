function loadTest1()
    require("module")
    print(module.constant)
    module.func3()
end

function loadTest2()
    local m = require("module")
    print(m.constant)
    m.func3()
end


loadTest1()
loadTest2()

