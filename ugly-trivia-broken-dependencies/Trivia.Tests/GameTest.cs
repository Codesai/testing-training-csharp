using NUnit.Framework;

namespace Trivia.Tests;

public class GameTest
{
    [Test]
    public void canary_test()
    {
        Assert.That(true, Is.EqualTo(true));
    }

    private class GameForTesting : Game
    {
        public readonly List<string> MessagesShown;
        private readonly Queue<int> _rollResults;
        private readonly Queue<bool> _answerIsRightList;

        public GameForTesting(
            List<int> rollResults,
            List<bool> answerIsRightList)
        {
            MessagesShown = new List<string>();
            _rollResults = new Queue<int>(rollResults);
            _answerIsRightList = new Queue<bool>(answerIsRightList);
        }

        protected override bool IsAnswerRight()
        {
            return _answerIsRightList.Dequeue();
        }

        protected override int GetRollResult()
        {
            return _rollResults.Dequeue();
        }

        protected override void ShowMessage(string message)
        {
            MessagesShown.Add(message);
        }
    }
}