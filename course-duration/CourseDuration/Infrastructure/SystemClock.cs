using CourseDuration.Domain;

namespace CourseDuration.Infrastructure;

public class SystemClock : Clock
{
    public DateTimeOffset Now()
    {
        return DateTimeOffset.UtcNow;
    }
}
