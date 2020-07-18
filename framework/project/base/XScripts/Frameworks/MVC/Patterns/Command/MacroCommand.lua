local MacroCommand = Class("MVC.Command.MacroCommand", MVC.Notifier)
function MacroCommand:Ctor()
    self.super:Ctor(self)
    self.subCommands = {}
    self:InitializeMacroCommand()
end

function MacroCommand:InitializeMacroCommand()
end

function MacroCommand:AddSubCommand(commandClassRef)
    table.insert(self.subCommands, commandClassRef)
end

function MacroCommand:Execute(note)
    while (#self.subCommands > 0) do
        local ref = table.remove(self.subCommands, 1)
        local cmd = ref.new()
        cmd:InitializeNotifier(self.multitonKey)
        cmd:Execute()
    end
end

return MacroCommand