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

local Tag = "Main"
local function Entry() 
    Frameworks.Log.D(Tag, "Entry")
end
local function OnApplicationQuit()
    Frameworks.Log.D(Tag, "OnApplicationQuit")
end
local function OnApplicationPause()
    Frameworks.Log.D(Tag, "OnApplicationPause")
end
local function OnApplicationResume()
    Frameworks.Log.D(Tag, "OnApplicationResume")
end

Main.Entry = Entry
Main.OnApplicationResume = OnApplicationResume
Main.OnApplicationPause = OnApplicationPause
Main.OnApplicationQuit = OnApplicationQuit

return Main
