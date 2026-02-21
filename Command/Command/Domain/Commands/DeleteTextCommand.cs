using Command.Domain.Entities;
using Command.Domain.Interfaces.Commands;

namespace Command.Domain.Commands;

public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _length;
    private readonly int _positionSnapshot;
    private string _deletedText = "";

    public string Description => $"Deletar {_length} caractere(s)";

    public DeleteTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _length = length;
        _positionSnapshot = editor.GetCursorPosition();
    }

    public void Execute()
    {
        var content = _editor.GetContent();
        var cursor = _editor.GetCursorPosition();

        if (cursor >= _length)
            _deletedText = content.Substring(cursor - _length, _length);

        _editor.DeleteText(_length);
    }

    public void Undo()
    {
        _editor.SetCursorPosition(_positionSnapshot - _length);
        _editor.InsertText(_deletedText);
    }
}