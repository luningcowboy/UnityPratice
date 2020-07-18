---
--- FileName: Log.lua
--- Created by lu ning
--- DateTime: 2020/07/18 15:25
--- Desc:
---

local Log = {}

local function GetTimeStamp()
    return os.date("%Y/%m/%d %H-%M-%S", os.time())
end

local function FormatLogs(...)
    local arr = { ... }
    if not arr or #arr <= 0 then
        return ""
    end
    local info = ""
    for _,v in ipairs(arr) do
        info = info .. " " .. v
    end
    return info
end

function Log.D(tag, ...)
    local info = "[DEBUG] [" .. GetTimeStamp() .. "] " .. " [" .. tag .. "] " .. FormatLogs(...)
    print(info)
end
function Log.E(tag, ...)
    local info = "[ERROR] [" .. GetTimeStamp() .. "] " .. " [" .. tag .. "] " .. FormatLogs(...)
    print(info)
end
function Log.W(tag, ...)
    local info = "[WARNING] [" .. GetTimeStamp() .. "] " .. " [" .. tag .. "] " .. FormatLogs(...)
    print(info)
end

return Log