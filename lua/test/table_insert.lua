local count = 100000000
local t1 = {}
local t = os.time()
print("zzzzz", t)
for i = 1, count do
    t1[#t1 + 1] = {i}
end
print(os.time() - t)
print("zzzz", os.time(), #t1)
local t2 = {}
t = os.time()
print("xxxxx", t)
for i = 1, count do
    table.insert(t2, {i})
end
print(os.time() - t)
print("xxxxx", os.time(), #t2)
