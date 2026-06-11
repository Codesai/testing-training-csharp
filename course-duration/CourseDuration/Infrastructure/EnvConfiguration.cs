using CourseDuration.Domain;

namespace CourseDuration.Infrastructure;

public class EnvConfiguration : Configuration
{
    public string? GetValue(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }
}
