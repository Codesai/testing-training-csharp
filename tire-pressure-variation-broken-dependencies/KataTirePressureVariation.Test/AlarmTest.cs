using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataTirePressureVariation.Test;

public class AlarmTest
{
    private AlarmForTesting _alarm = null!;

    [Test]
    public void alarm_activates_when_pressure_is_too_low()
    {
        _alarm = AlarmSampling(10.0);

        _alarm.Check();

        CheckShownMessagesWere("Alarm activated!");
    }

    private void CheckShownMessagesWere(params string[] expectedMessages)
    {
        Assert.That(_alarm.ShownMessages, Is.EqualTo(expectedMessages.ToList()));
    }

    private AlarmForTesting AlarmSampling(params double[] values)
    {
        return new AlarmForTesting(values);
    }

    private class AlarmForTesting : Alarm
    {
        private readonly Queue<double> _sampledValues;
        public List<string> ShownMessages { get; }

        public AlarmForTesting(params double[] values)
        {
            ShownMessages = new List<string>();
            _sampledValues = new Queue<double>(values);
        }

        protected override void Notify(string message)
        {
            ShownMessages.Add(message);
        }

        protected override double SampleValue()
        {
            return _sampledValues.Dequeue();
        }
    }
}