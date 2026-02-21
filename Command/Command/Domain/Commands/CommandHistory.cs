using Command.Domain.Interfaces.Commands;

namespace Command.Domain.Commands;

public class CommandHistory
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();

    public void Record(ICommand command)
    {
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public bool Undo()
    {
        if (_undoStack.Count == 0) return false;
        var cmd = _undoStack.Pop();
        cmd.Undo();
        _redoStack.Push(cmd);
        return true;
    }

    public bool Redo()
    {
        if (_redoStack.Count == 0) return false;
        var cmd = _redoStack.Pop();
        cmd.Execute();
        _undoStack.Push(cmd);
        return true;
    }

    public void PrintHistory()
    {
        Console.WriteLine("\n=== Histórico de Comandos ===");
        var cmds = _undoStack.ToArray();
        for (int i = 0; i < cmds.Length; i++)
            Console.WriteLine($"  {cmds.Length - i}. {cmds[i].Description}");
        Console.WriteLine();
    }
}
