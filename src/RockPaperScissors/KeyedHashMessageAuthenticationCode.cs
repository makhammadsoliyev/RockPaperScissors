using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors;

public static class KeyedHashMessageAuthenticationCode
{
    public static string GetRandomMove(string[] moves)
    {
        var random = new Random();
        var index = random.Next(0, moves.Length - 1);
        return moves[index];
    }

    public static string GenerateKey()
    {
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        var hashBytes = new byte[32];
        rng.GetBytes(hashBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "");
    }

    public static string GenerateHmac(string move, string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var moveBytes = Encoding.UTF8.GetBytes(move);

        using var hmac = new HMACSHA256(keyBytes);
        var hashBytes = hmac.ComputeHash(moveBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "");
    }
}
