namespace RockPaperScissors;

public class Program
{
    private static void Main(string[] args)
    {
        //args = new[] { "Rock", "Paper", "Scissors", "Lizard", "Spock", "sd", "sds" };
        Console.Clear();

        if (args.Length < 3 || args.Length % 2 == 0 || Validations.HasDuplicates(args))
        {
            Console.WriteLine("\nInvalid input. Please enter an odd number of unique moves." +
                "Example: Rock Paper Scissors Lizard Spock\n");

            return;
        }

        var (hmacKey, playerMove, computerMove, isExit) = Startup.StartGame(args);

        if (isExit)
            return;

        Startup.WinnerCheck(hmacKey, computerMove, playerMove, args);
    }
}