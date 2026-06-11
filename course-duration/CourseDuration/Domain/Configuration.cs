namespace CourseDuration.Domain;

public interface Configuration
{
    string? GetValue(string key);
}
