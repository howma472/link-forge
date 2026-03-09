namespace LinkForge.Application.Generators;

/// <summary>
/// Генератор коротких кодов на основе GUID.
/// </summary>
public static class ShortCodeGenerator
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Generate(int length = 7)
    {
        var guidBytes = Guid.NewGuid().ToByteArray();
        var number = BitConverter.ToUInt64(guidBytes, 0);

        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = Alphabet[(int)(number % (ulong)Alphabet.Length)];
            number /= (ulong)Alphabet.Length;
        }

        return new string(chars);
    }
}