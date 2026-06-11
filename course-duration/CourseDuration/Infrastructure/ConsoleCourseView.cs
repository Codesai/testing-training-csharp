using CourseDuration.Domain;

namespace CourseDuration.Infrastructure;

public class ConsoleCourseView : CourseView
{
    public void DisplayLine(string line)
    {
        Console.WriteLine(line);
    }
}
