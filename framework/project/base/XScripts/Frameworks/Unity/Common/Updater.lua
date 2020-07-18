---
--- FileName: Updater.lua
--- Created by lu ning
--- DateTime: 2020/07/18 16:18
--- Desc:
---

local Updater = {}
function Updater.Update(deltaTime, unscaleDeltaTime) 
    Frameworks.Log.D("Update")
end
function Updater.FixedUpdate(fixedDeltaTime)
    Frameworks.Log.D("FixedUpdate")
end
function Updater.LateUpdate()
    Frameworks.Log.D("LateUpdate")
end
function Updater.SlowUpdate()
    Frameworks.Log.D("SlowUpdate")
end
function Updater.CoroutineUpdate()
    Frameworks.Log.D("CoroutineUpdate")
end
return Updater