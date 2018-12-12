using NUnit.Framework;
using BowlingKata;

namespace BowlingKataTests
{
    [TestFixture]
    class GameTest
    {
        Game game;

        [SetUp]
        public void SetUp()
        {
             game = new Game();
        }

        [Test]
        public void CanTakeInARoll()
        {
            var expectedScore = 9;

            game.Roll(4);
            game.Roll(5);
            var actualScore = game.GetScore();

            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
