namespace RockPaperScissors;

public static class Validations
{
    public static string DetermineWinner(int movesCount, int computerMove, int playerMove)
    {
        int p = movesCount / 2;

        int result = Math.Sign((computerMove - playerMove + p + movesCount) % movesCount - p);

        if (result == 0)
            return "Draw";
        else if (result == 1)
            return "Lose";
        else return "Win";
    }

    public static bool IsValidMove(string move, string[] moves)
    {
        if (move == "?")
        {
            Display.ShowHelpTable(moves);
            return false;
        }

        if (Array.IndexOf(moves, move) != -1)
        {
            return true;
        }

        Console.WriteLine("Invalid move. Please choose a valid move from the menu.");
        return false;
    }

    public static bool HasDuplicates(string[] moves)
    {
        var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var move in moves)
            if (!set.Add(move))
                return true;

        return false;
    }
}
