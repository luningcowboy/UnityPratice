file = io.open("tmp.lua", "r")
io.input(file)
print(io.read())
io.close(file)

file = io.open("tmp.lua", "a")
io.output(file)
io.write("-- tmp.lua end")
io.close(file)
