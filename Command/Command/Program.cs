
using Command.Application;

Console.WriteLine("=== Editor de Texto - Command Pattern + DDD ===\n");

var app = new EditorApplication();

Console.WriteLine("=== Operações ===");
app.TypeText("Hello");
app.TypeText(" World");
app.ShowContent();

app.DeleteCharacters(6);
app.ShowContent();

app.MakeBold(0, 5);

Console.WriteLine("\n=== Undo ===");
app.Undo(); // desfaz negrito
app.Undo(); // desfaz delete
app.ShowContent();

Console.WriteLine("\n=== Redo ===");
app.Redo(); // refaz delete
app.ShowContent();

Console.WriteLine("\n=== Undo sem histórico ===");
app.Undo();
app.Undo();
app.Undo();
app.Undo(); // avisa que não há mais nada

app.ShowHistory();