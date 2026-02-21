using Command.Domain.Entities;
using Command.Domain.Interfaces.Commands;

namespace Command.Domain.Commands;

public class InsertTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;
    private readonly int _positionSnapshot;

    public string Description => $"Inserir '{_text}'";

    public InsertTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
        _positionSnapshot = editor.GetCursorPosition();
    }

    public void Execute() => _editor.InsertText(_text);

    public void Undo()
    {
        _editor.SetCursorPosition(_positionSnapshot + _text.Length);
        _editor.DeleteText(_text.Length);
    }
}