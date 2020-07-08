x = math.pi
print(x - x%0.01) -- 3.14
print(x - x%0.001) -- 3.141
print(x - x%0.0001) -- 3.1415

local tolerance = 10
function isturnback(angle)
    angle = angle % 360
    return (math.abs(angle - 180) < tolerance)
end
local tolerance2 = 0.17
function isturnback2(angle)
    angle = angle % (2 * math.pi)
    return (math.abs(angle - math.pi) < tolerance2)
end
print(isturnback(-180)) -- true
print(isturnback2(-math.pi/2)) -- false
