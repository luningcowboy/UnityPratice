local require = require

--- 基础模块,全局定义
Class = require "Frameworks.Base.OOP.MetatableClass"
ConstClass = require "Frameworks.Base.OOP.ConstClass"
JSON = require "Frameworks.Base.Libs.Json"

--- Frameworks模块
Frameworks = {}
Frameworks.Log = require "Frameworks.Log"
Frameworks.FSM = require "Frameworks.FSM"
Frameworks.NotificationCenter = require "Frameworks.NotificationCenter"
Frameworks.MVC = require "Frameworks.MVC.Boot"

-- 导入Unity相关组件
Frameworks.Unity = require "Frameworks.Unity.Boot"
