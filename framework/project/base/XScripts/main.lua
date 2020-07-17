require "Frameworks.Boot"
require "Games.Boot"

Main = {}

setmetatable(
    _G,
    {
        __newindex = function(t, k, v)
            print("Error, not permit to add global variable。")
        end
    }
)

local function Entry() end
local function OnApplicationQuit() end
local function OnApplicationPause() end
local function OnApplicationResume() end

Main.Entry = Entry
Main.OnApplicationResume = OnApplicationResume
Main.OnApplicationPause = OnApplicationPause
Main.OnApplicationQuit = OnApplicationQuit

return Main
