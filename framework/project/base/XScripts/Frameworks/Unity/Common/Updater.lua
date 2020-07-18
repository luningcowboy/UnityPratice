---
--- FileName: Updater.lua
--- Created by lu ning
--- DateTime: 2020/07/18 16:18
--- Desc:
---

local Updater = {}
local Tag = "Updater"
function Updater.Update(deltaTime, unscaleDeltaTime) 
    Frameworks.Log.D(Tag, "Update")
end
function Updater.FixedUpdate(fixedDeltaTime)
    Frameworks.Log.D(Tag, "FixedUpdate")
end
function Updater.LateUpdate()
    Frameworks.Log.D(Tag, "LateUpdate")
end
function Updater.SlowUpdate()
    Frameworks.Log.D(Tag, "SlowUpdate")
end
function Updater.CoroutineUpdate()
    Frameworks.Log.D(Tag, "CoroutineUpdate")
end
return Updater