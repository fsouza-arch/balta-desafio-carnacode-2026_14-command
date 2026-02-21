using Command.Domain.Commands;
using Command.Domain.Interfaces.Commands;

namespace Command.Application;

public class EditorApplication
{
    private readonly Domain.Entities.TextEditor _editor;
    private readonly CommandHistory _history;

    public EditorApplication()
    {
        _editor = new Domain.Entities.TextEditor();
        _history = new CommandHistory();
    }

    private void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Record(command);
    }

    public void TypeText(string text) =>
        ExecuteCommand(new InsertTextCommand(_editor, text));

    public void DeleteCharacters(int count) =>
        ExecuteCommand(new DeleteTextCommand(_editor, count));

    public void MakeBold(int start, int length) =>
        ExecuteCommand(new SetBoldCommand(_editor, start, length));

    public void ExecuteMacro(params ICommand[] commands) =>
        ExecuteCommand(new MacroCommand(commands));

    public void Undo()
    {
        var success = _history.Undo();
        if (!success)
            Console.WriteLine("[App] Nada para desfazer.");
    }

    public void Redo()
    {
        var success = _history.Redo();
        if (!success)
            Console.WriteLine("[App] Nada para refazer.");
    }

    public void ShowContent()
    {
        Console.WriteLine($"\n=== Conteúdo do Editor ===");
        Console.WriteLine($"'{_editor.GetContent()}'");
        Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
    }

    public void ShowHistory() => _history.PrintHistory();
}
}
