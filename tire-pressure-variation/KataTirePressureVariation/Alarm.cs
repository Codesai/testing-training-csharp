namespace KataTirePressureVariation;

public class Alarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;
    private readonly Sensor _sensor = new Sensor();
    private bool _alarmOn = false;

    public void Check()
    {
        var psiPressureValue = _sensor.PopNextPressurePsiValue();

        if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
        {
            if (!IsAlarmOn())
            {
                _alarmOn = true;
                Console.WriteLine("Alarm activated!");
            }
        }
        else
        {
            if (IsAlarmOn())
            {
                _alarmOn = false;
                Console.WriteLine("Alarm deactivated!");
            }
        }
    }

    private bool IsAlarmOn()
    {
        return _alarmOn;
    }
}