local function arrayEachRight(arr, iteratee)
    local len = arr and #arr or 0
    while len > 0 do
        local stat, ret = pcall(iteratee, arr[len], len, arr)
        if not ret then
            break
        end
        len = len - 1
    end
end

return arrayEachRight
