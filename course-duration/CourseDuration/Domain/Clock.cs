namespace CourseDuration.Domain;

public interface Clock
{
    DateTimeOffset Now();
}
