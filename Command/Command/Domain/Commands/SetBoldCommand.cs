using Command.Domain.Interfaces.Commands;

namespace Command.Domain.Commands;

public class SetBoldCommand : ICommand
{
    private readonly Entities.TextEditor _editor;
    private readonly int _start;
    private readonly int _length;

    public string Description => $"Negrito [{_start}, {_start + _length}]";

    public SetBoldCommand(Entities.TextEditor editor, int start, int length)
    {
        _editor = editor;
        _start = start;
        _length = length;
    }

    public void Execute() => _editor.SetBold(_start, _length);
    public void Undo() => _editor.RemoveBold(_start, _length);
}