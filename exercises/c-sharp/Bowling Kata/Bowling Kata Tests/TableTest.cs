using NUnit.Framework;
using BowlingKata;

namespace BowlingKataTests
{
    [TestFixture]
    class TableTest
    {
        Table table;

        [SetUp]
        public void Setup()
        {
            table = new Table();
        }

        [Test]
        public void HasTenFramesByDefault()
        {
            Assert.That(table.TableSize, Is.EqualTo(10));
        }

        [Test]
        public void CanAddRollToTotalScore()
        {
            table.Roll(4);

            Assert.That(table.TotalScore, Is.EqualTo(4));
        }

        [Test]
        public void CanAddMultipleNonSpareOrStrikeRolls()
        {
            table.Roll(2);
            table.Roll(7);
            table.Roll(3);
            table.Roll(4);
            table.Roll(5);
            table.Roll(2);

            Assert.That(table.TotalScore, Is.EqualTo(23));
        }

        [Test]
        public void CanCalculateScoreAfterStrikeOnFirstRoll()
        {
            table.Roll(10);
            table.Roll(4);
            table.Roll(3);
            table.Roll(10);
            table.Roll(2);
            table.Roll(6);

            Assert.That(table.TotalScore, Is.EqualTo(50));
            Assert.That(table.CurrentFrame, Is.EqualTo(5));
        }
    }
}
