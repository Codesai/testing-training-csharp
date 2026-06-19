using NUnit.Framework;

namespace Trivia.Tests;

public class GameTest
{
    [Test]
    public void simulation_1()
    {
        var rollResults = new List<int>()
        {
            3, 5, 4, 2, 1, 2, 5, 4, 1, 2, 2, 1, 4, 4, 5, 5, 4, 5, 1, 5, 5
        };
        var isAnswersWrongList = new List<bool>()
        {
            false, false, false, true, false, true, false, false, false, false, false, false, false, true, false, false,
            false, false, false, false, false
        };
        var aGame = new GameForTesting(rollResults, isAnswersWrongList);
        aGame.Add("Chet");
        aGame.Add("Pat");
        aGame.Add("Sue");

        aGame.Run();

        var expectedOutput = new List<string>()
        {
            "Chet was added", "They are player number 1", "Pat was added", "They are player number 2", "Sue was added",
            "They are player number 3", "Chet is the current player", "They have rolled a 3",
            "Chet's new location is 3", "The category is Rock", "Rock Question 0", "Answer was correct!!!!",
            "Chet now has 1 Gold Coins.", "Pat is the current player", "They have rolled a 5",
            "Pat's new location is 5", "The category is Science", "Science Question 0", "Answer was correct!!!!",
            "Pat now has 1 Gold Coins.", "Sue is the current player", "They have rolled a 4", "Sue's new location is 4",
            "The category is Pop", "Pop Question 0", "Answer was correct!!!!", "Sue now has 1 Gold Coins.",
            "Chet is the current player", "They have rolled a 2", "Chet's new location is 5", "The category is Science",
            "Science Question 1", "Question was incorrectly answered", "Chet was sent to the penalty box",
            "Pat is the current player", "They have rolled a 1", "Pat's new location is 6", "The category is Sports",
            "Sports Question 0", "Answer was correct!!!!", "Pat now has 2 Gold Coins.", "Sue is the current player",
            "They have rolled a 2", "Sue's new location is 6", "The category is Sports", "Sports Question 1",
            "Question was incorrectly answered", "Sue was sent to the penalty box", "Chet is the current player",
            "They have rolled a 5", "Chet is getting out of the penalty box", "Chet's new location is 10",
            "The category is Sports", "Sports Question 2", "Answer was correct!!!!", "Chet now has 2 Gold Coins.",
            "Pat is the current player", "They have rolled a 4", "Pat's new location is 10", "The category is Sports",
            "Sports Question 3", "Answer was correct!!!!", "Pat now has 3 Gold Coins.", "Sue is the current player",
            "They have rolled a 1", "Sue is getting out of the penalty box", "Sue's new location is 7",
            "The category is Rock", "Rock Question 1", "Answer was correct!!!!", "Sue now has 2 Gold Coins.",
            "Chet is the current player", "They have rolled a 2", "Chet is not getting out of the penalty box",
            "Pat is the current player", "They have rolled a 2", "Pat's new location is 0", "The category is Pop",
            "Pop Question 1", "Answer was correct!!!!", "Pat now has 4 Gold Coins.", "Sue is the current player",
            "They have rolled a 1", "Sue is getting out of the penalty box", "Sue's new location is 8",
            "The category is Pop", "Pop Question 2", "Answer was correct!!!!", "Sue now has 3 Gold Coins.",
            "Chet is the current player", "They have rolled a 4", "Chet is not getting out of the penalty box",
            "Pat is the current player", "They have rolled a 4", "Pat's new location is 4", "The category is Pop",
            "Pop Question 3", "Question was incorrectly answered", "Pat was sent to the penalty box",
            "Sue is the current player", "They have rolled a 5", "Sue is getting out of the penalty box",
            "Sue's new location is 1", "The category is Science", "Science Question 2", "Answer was correct!!!!",
            "Sue now has 4 Gold Coins.", "Chet is the current player", "They have rolled a 5",
            "Chet is getting out of the penalty box", "Chet's new location is 3", "The category is Rock",
            "Rock Question 2", "Answer was correct!!!!", "Chet now has 3 Gold Coins.", "Pat is the current player",
            "They have rolled a 4", "Pat is not getting out of the penalty box", "Sue is the current player",
            "They have rolled a 5", "Sue is getting out of the penalty box", "Sue's new location is 6",
            "The category is Sports", "Sports Question 4", "Answer was correct!!!!", "Sue now has 5 Gold Coins.",
            "Chet is the current player", "They have rolled a 1", "Chet is getting out of the penalty box",
            "Chet's new location is 4", "The category is Pop", "Pop Question 4", "Answer was correct!!!!",
            "Chet now has 4 Gold Coins.", "Pat is the current player", "They have rolled a 5",
            "Pat is getting out of the penalty box", "Pat's new location is 9", "The category is Science",
            "Science Question 3", "Answer was correct!!!!", "Pat now has 5 Gold Coins.", "Sue is the current player",
            "They have rolled a 5", "Sue is getting out of the penalty box", "Sue's new location is 11",
            "The category is Rock", "Rock Question 3", "Answer was correct!!!!", "Sue now has 6 Gold Coins."
        };
        Assert.That(aGame.MessagesShowed, Is.EquivalentTo(expectedOutput));
    }

    [Test]
    public void simulation_2()
    {
        var rollResults = new List<int>()
        {
            5, 4, 2, 4, 4, 4, 2, 1, 3, 4, 1, 3, 2, 5, 4, 5, 5, 4, 5, 2, 2, 2, 4, 4, 5, 1, 2, 4
        };
        var isAnswersWrongList = new List<bool>()
        {
            false, false, false, false, true, false, true, false, false, false, false, false, false, false, false,
            false, false, false, false, false, true, false, false, false, false, true, true, false
        };
        var aGame = new GameForTesting(rollResults, isAnswersWrongList);
        aGame.Add("Chet");
        aGame.Add("Pat");
        aGame.Add("Sue");
        aGame.Add("Roe");
        aGame.Add("Joe");

        aGame.Run();

        var expectedOutput = new List<string>()
        {
            "Chet was added", "They are player number 1", "Pat was added", "They are player number 2", "Sue was added",
            "They are player number 3", "Roe was added", "They are player number 4", "Joe was added",
            "They are player number 5", "Chet is the current player", "They have rolled a 5",
            "Chet's new location is 5", "The category is Science", "Science Question 0", "Answer was correct!!!!",
            "Chet now has 1 Gold Coins.", "Pat is the current player", "They have rolled a 4",
            "Pat's new location is 4", "The category is Pop", "Pop Question 0", "Answer was correct!!!!",
            "Pat now has 1 Gold Coins.", "Sue is the current player", "They have rolled a 2", "Sue's new location is 2",
            "The category is Sports", "Sports Question 0", "Answer was correct!!!!", "Sue now has 1 Gold Coins.",
            "Roe is the current player", "They have rolled a 4", "Roe's new location is 4", "The category is Pop",
            "Pop Question 1", "Answer was correct!!!!", "Roe now has 1 Gold Coins.", "Joe is the current player",
            "They have rolled a 4", "Joe's new location is 4", "The category is Pop", "Pop Question 2",
            "Question was incorrectly answered", "Joe was sent to the penalty box", "Chet is the current player",
            "They have rolled a 4", "Chet's new location is 9", "The category is Science", "Science Question 1",
            "Answer was correct!!!!", "Chet now has 2 Gold Coins.", "Pat is the current player", "They have rolled a 2",
            "Pat's new location is 6", "The category is Sports", "Sports Question 1",
            "Question was incorrectly answered", "Pat was sent to the penalty box", "Sue is the current player",
            "They have rolled a 1", "Sue's new location is 3", "The category is Rock", "Rock Question 0",
            "Answer was correct!!!!", "Sue now has 2 Gold Coins.", "Roe is the current player", "They have rolled a 3",
            "Roe's new location is 7", "The category is Rock", "Rock Question 1", "Answer was correct!!!!",
            "Roe now has 2 Gold Coins.", "Joe is the current player", "They have rolled a 4",
            "Joe is not getting out of the penalty box", "Chet is the current player", "They have rolled a 1",
            "Chet's new location is 10", "The category is Sports", "Sports Question 2", "Answer was correct!!!!",
            "Chet now has 3 Gold Coins.", "Pat is the current player", "They have rolled a 3",
            "Pat is getting out of the penalty box", "Pat's new location is 9", "The category is Science",
            "Science Question 2", "Answer was correct!!!!", "Pat now has 2 Gold Coins.", "Sue is the current player",
            "They have rolled a 2", "Sue's new location is 5", "The category is Science", "Science Question 3",
            "Answer was correct!!!!", "Sue now has 3 Gold Coins.", "Roe is the current player", "They have rolled a 5",
            "Roe's new location is 0", "The category is Pop", "Pop Question 3", "Answer was correct!!!!",
            "Roe now has 3 Gold Coins.", "Joe is the current player", "They have rolled a 4",
            "Joe is not getting out of the penalty box", "Chet is the current player", "They have rolled a 5",
            "Chet's new location is 3", "The category is Rock", "Rock Question 2", "Answer was correct!!!!",
            "Chet now has 4 Gold Coins.", "Pat is the current player", "They have rolled a 5",
            "Pat is getting out of the penalty box", "Pat's new location is 2", "The category is Sports",
            "Sports Question 3", "Answer was correct!!!!", "Pat now has 3 Gold Coins.", "Sue is the current player",
            "They have rolled a 4", "Sue's new location is 9", "The category is Science", "Science Question 4",
            "Answer was correct!!!!", "Sue now has 4 Gold Coins.", "Roe is the current player", "They have rolled a 5",
            "Roe's new location is 5", "The category is Science", "Science Question 5", "Answer was correct!!!!",
            "Roe now has 4 Gold Coins.", "Joe is the current player", "They have rolled a 2",
            "Joe is not getting out of the penalty box", "Chet is the current player", "They have rolled a 2",
            "Chet's new location is 5", "The category is Science", "Science Question 6",
            "Question was incorrectly answered", "Chet was sent to the penalty box", "Pat is the current player",
            "They have rolled a 2", "Pat is not getting out of the penalty box", "Sue is the current player",
            "They have rolled a 4", "Sue's new location is 1", "The category is Science", "Science Question 7",
            "Answer was correct!!!!", "Sue now has 5 Gold Coins.", "Roe is the current player", "They have rolled a 4",
            "Roe's new location is 9", "The category is Science", "Science Question 8", "Answer was correct!!!!",
            "Roe now has 5 Gold Coins.", "Joe is the current player", "They have rolled a 5",
            "Joe is getting out of the penalty box", "Joe's new location is 9", "The category is Science",
            "Science Question 9", "Answer was correct!!!!", "Joe now has 1 Gold Coins.", "Chet is the current player",
            "They have rolled a 1", "Chet is getting out of the penalty box", "Chet's new location is 6",
            "The category is Sports", "Sports Question 4", "Question was incorrectly answered",
            "Chet was sent to the penalty box", "Pat is the current player", "They have rolled a 2",
            "Pat is not getting out of the penalty box", "Question was incorrectly answered",
            "Pat was sent to the penalty box", "Sue is the current player", "They have rolled a 4",
            "Sue's new location is 5", "The category is Science", "Science Question 10", "Answer was correct!!!!",
            "Sue now has 6 Gold Coins."
        };
        Assert.That(aGame.MessagesShowed, Is.EquivalentTo(expectedOutput));
    }


    class GameForTesting : Game
    {
        private readonly Queue<int> _rollResults;
        private readonly Queue<bool> _isAnswersWrongList;
        public readonly List<string> MessagesShowed;

        public GameForTesting(List<int> rollResults, List<bool> isAnswersWrongList)
        {
            _rollResults = new Queue<int>(rollResults);
            _isAnswersWrongList = new Queue<bool>(isAnswersWrongList);
            MessagesShowed = new List<string>();
        }

        protected override int GetRollResult()
        {
            return _rollResults.Dequeue();
        }

        protected override bool IsWrongAnswer()
        {
            return _isAnswersWrongList.Dequeue();
        }

        protected override void ShowMessage(string message)
        {
            MessagesShowed.Add(message);
        }
    }
}