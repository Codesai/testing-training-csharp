namespace CourseDuration.Domain;

public class Course
{
    private static readonly TimeSpan MaxMinutesShortCourses = TimeSpan.FromMinutes(10);
    private readonly string _name;
    private readonly Configuration _configuration;
    private readonly Clock _clock;
    private DateTimeOffset _startTime;
    private TimeSpan _durationInMinutes;
    private readonly CourseView _courseView;

    public Course(string name, Configuration configuration, Clock clock, CourseView courseView)
    {
        _name = name;
        _configuration = configuration;
        _clock = clock;
        _courseView = courseView;
        _durationInMinutes = TimeSpan.Zero;
    }

    public void ShowDetails()
    {
        _courseView.DisplayLine("Title: " + GetTitle());
        _courseView.DisplayLine("Duration: " + (long)_durationInMinutes.TotalMinutes + " minutes");
        _courseView.DisplayLine("Type: " + (IsShort() ? "short" : "long"));
    }

    public void Start()
    {
        _startTime = _clock.Now();
    }

    public void End()
    {
        var endTime = _clock.Now();
        _durationInMinutes = ComputeMinutesBetween(_startTime, endTime);
    }

    private bool IsShort()
    {
        return _durationInMinutes < MaxMinutesShortCourses;
    }

    private string GetTitle()
    {
        return _name + " course in " + GetCollege() + " college";
    }

    private TimeSpan ComputeMinutesBetween(DateTimeOffset startTime, DateTimeOffset endTime)
    {
        return TimeSpan.FromMinutes((long)(endTime - startTime).TotalMinutes);
    }

    private string GetCollege()
    {
        string? college = _configuration.GetValue("COLLEGE");
        if (college == null)
        {
            return "ups! ->";
        }
        return college;
    }
}
