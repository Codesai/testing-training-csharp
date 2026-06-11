using CourseDuration.Domain;
using CourseDuration.Infrastructure;

namespace CourseDuration;

public class Program
{
    public static void Main(string[] args)
    {
        var courseName = args.Length > 0 ? args[0] : "Programming 101";
        var course = StartCourse(courseName);
        RunCourse();
        EndCourse(course);
        course.ShowDetails();
    }

    private static Course StartCourse(string courseName)
    {
        var configuration = new EnvConfiguration();
        var clock = new SystemClock();
        var courseView = new ConsoleCourseView();
        var course = new Course(courseName, configuration, clock, courseView);
        course.Start();
        return course;
    }

    private static void EndCourse(Course course)
    {
        course.End();
    }

    private static void RunCourse()
    {
        Thread.Sleep(TimeSpan.FromMinutes(1));
    }
}
