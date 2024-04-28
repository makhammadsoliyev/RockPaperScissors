namespace RockPaperScissors;

public static class Startup
{
    public static (string hmacKey, string playerMove, string computerMove, bool isExit) StartGame(string[] moves)
    {
        var hmacKey = KeyedHashMessageAuthenticationCode.GenerateKey();
        var computerMove = KeyedHashMessageAuthenticationCode.GetRandomMove(moves);
        var hmac = KeyedHashMessageAuthenticationCode.GenerateHmac(computerMove, hmacKey);
        var isExit = false;

        Console.WriteLine("HMAC: " + hmac);
        Display.ShowMenu(moves);

        string playerMove;

        do
        {
            Console.Write("Enter your move: ");
            playerMove = Console.ReadLine();

            if (playerMove == "0")
                isExit = true;

            if (int.TryParse(playerMove, out int moveNumber))
                if (moveNumber >= 1 && moveNumber <= moves.Length)
                    playerMove = moves[moveNumber - 1];

        } while (!Validations.IsValidMove(playerMove, moves));

        Console.WriteLine("Your move: " + playerMove);
        Console.WriteLine("Computer move: " + computerMove);

        return (hmacKey, playerMove, computerMove, isExit);
    }

    public static void WinnerCheck(string hmacKey, string computerMove, string playerMove, string[] moves)
    {
        var result = Validations.DetermineWinner
            (moves.Length, 
            Array.IndexOf(moves, computerMove),
            Array.IndexOf(moves, playerMove));

        switch (result)
        {
            case "Draw":
                Console.WriteLine("It is a draw.");
                break;
            case "Lose":
                Console.WriteLine("Computer win.");
                break;
            default:
                Console.WriteLine("You win.");
                break;
        }

        Console.WriteLine("HMAC Key: " + hmacKey);
    }
}
