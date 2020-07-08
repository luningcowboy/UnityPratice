arr = {"lua", "tutorial"}

for i = 0, 2 do
    print(arr[i])
end

arr = {}
for i = -2, 2 do
    arr[i] = i * 2
end

print(arr)
for i = -2, 2 do
    print(i, arr[i])
end

-- 多维数组
arr = {}
for i = 1, 3 do
    arr[i] = {}
    for j = 1, 3 do
        arr[i][j] = i * j
    end
end

for i = 1, 3 do
    for j = 1, 3 do
        print(i, j, arr[i][j])
    end
end

arr = {}
maxRows = 3
maxCols = 3
for row = 1, maxRows do
    for col = 1, maxCols do
        arr[row * maxRows + col] = row * col
    end
end

for row = 1, maxRows do
    for col = 1, maxCols do
        index = row * maxRows + col
        print(row, col, index, arr[index])
    end
end

print(#arr)

arr = {1,2,3,4}
for i = 1, #arr do
    print(i, arr[i])
end
