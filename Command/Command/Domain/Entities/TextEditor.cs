namespace Command.Domain.Entities;

public class TextEditor
{
    private string _content;
    private string _selectedText;
    private int _cursorPosition;

    public TextEditor()
    {
        _content = "";
        _cursorPosition = 0;
    }

    public void InsertText(string text)
    {
        _content = _content.Insert(_cursorPosition, text);
        _cursorPosition += text.Length;
        Console.WriteLine($"[Editor] Texto inserido: '{text}'");
        Console.WriteLine($"[Editor] Conteúdo atual: '{_content}'");
    }

    public void DeleteText(int length)
    {
        if (_cursorPosition >= length)
        {
            _content = _content.Remove(_cursorPosition - length, length);
            _cursorPosition -= length;
            Console.WriteLine($"[Editor] {length} caracteres deletados");
            Console.WriteLine($"[Editor] Conteúdo atual: '{_content}'");
        }
    }

    public void SetBold(int start, int length)
    {
        Console.WriteLine($"[Editor] Aplicando negrito de {start} a {start + length}");
    }

    public void RemoveBold(int start, int length)
    {
        Console.WriteLine($"[Editor] Removendo negrito de {start} a {start + length}");
    }

    public void SetCursorPosition(int position)
    {
        _cursorPosition = position;
    }

    public string GetContent()
    {
        return _content;
    }

    public int GetCursorPosition()
    {
        return _cursorPosition;
    }
}
