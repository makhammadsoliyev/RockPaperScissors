using ConsoleTables;

namespace RockPaperScissors;

public static class Display
{
    public static void ShowHelpTable(string[] moves)
    {
        var movesCount = moves.Length;
        var headerItems = moves.Prepend("PC \\ User");
        var helpTable = new ConsoleTable(headerItems.ToArray());

        for (int i = 0; i < movesCount; i++)
        {
            var currentRow = new string[movesCount + 1];
            currentRow[0] = moves[i];

            for (int j = 0; j < movesCount; j++)
                currentRow[j + 1] = Validations.DetermineWinner(movesCount, i, j);

            helpTable.AddRow(currentRow);
        }

        helpTable.Write(Format.Alternative);
    }

    public static void ShowMenu(string[] moves)
    {
        Console.WriteLine("Available moves:");

        for (int i = 0; i < moves.Length; i++)
            Console.WriteLine(i + 1 + " - " + moves[i]);

        Console.WriteLine("\n0 - Exit");
        Console.WriteLine("? - Help");
    }
}
