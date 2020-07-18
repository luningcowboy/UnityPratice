require "Frameworks.Boot"
require "Games.Boot"
Frameworks.Log.D("Main", "Enter Main")
Main = {}

setmetatable(
    _G,
    {
        __newindex = function(t, k, v)
            print("Error, not permit to add global variable。")
        end
    }
)

local function Entry() 
    Frameworks.Log.D("Main", "Entry")
end
local function OnApplicationQuit()
    Frameworks.Log.D("Main", "OnApplicationQuit")
end
local function OnApplicationPause()
    Frameworks.Log.D("Main", "OnApplicationPause")
end
local function OnApplicationResume()
    Frameworks.Log.D("Main", "OnApplicationResume")
end

Main.Entry = Entry
Main.OnApplicationResume = OnApplicationResume
Main.OnApplicationPause = OnApplicationPause
Main.OnApplicationQuit = OnApplicationQuit

return Main
