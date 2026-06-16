namespace Trivia.Tests;

public static class SamplingHelper
{
    public static void PrintValues<T>(List<T> values, Func<T, string> formatter)
    {
        var joined = string.Join(", ", values.Select(formatter));

        Console.WriteLine($"new List<T> {{ {joined} }};");
    }
}