namespace KataTirePressureVariation;

public class Alarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;
    private readonly Sensor _sensor = new Sensor();
    private bool _alarmOn = false;

    public void Check()
    {
        var psiPressureValue = SampleValue();

        if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
        {
            if (!IsAlarmOn())
            {
                _alarmOn = true;
                Notify("Alarm activated!");
            }
        }
        else
        {
            if (IsAlarmOn())
            {
                _alarmOn = false;
                Notify("Alarm deactivated!");
            }
        }
    }

    protected virtual void Notify(string message)
    {
        Console.WriteLine(message);
    }

    protected virtual double SampleValue()
    {
        return _sensor.PopNextPressurePsiValue();
    }

    private bool IsAlarmOn()
    {
        return _alarmOn;
    }
}