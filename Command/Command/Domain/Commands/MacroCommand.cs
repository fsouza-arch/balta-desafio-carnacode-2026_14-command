using Command.Domain.Interfaces.Commands;

namespace Command.Domain.Commands;

public class MacroCommand : ICommand
{
    private readonly IReadOnlyList<ICommand> _commands;

    public string Description => $"Macro ({_commands.Count} comandos)";

    public MacroCommand(IEnumerable<ICommand> commands) =>
        _commands = commands.ToList();

    public void Execute()
    {
        foreach (var cmd in _commands)
            cmd.Execute();
    }

    public void Undo()
    {
        foreach (var cmd in _commands.Reverse())
            cmd.Undo();
    }
}
