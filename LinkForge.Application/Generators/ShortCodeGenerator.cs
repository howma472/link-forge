using System.Security.Cryptography;
using System.Text;

namespace LinkForge.Application.Generators;
/// <summary>
/// Генератор коротких кодов (short codes) фиксированной длины на основе криптографически стойкого случайного генератора.
/// </summary>
public static class ShortCodeGenerator
{
    
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    public static string Generate(int length = 7)
    {
        var bytes = RandomNumberGenerator.GetBytes(length);
        var result = new StringBuilder(length);
        foreach (var b in bytes)
        {
            var index = b % Alphabet.Length;
            result.Append(Alphabet[index]);
        }
        return result.ToString();
    }
}