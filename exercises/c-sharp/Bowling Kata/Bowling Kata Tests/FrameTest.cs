using NUnit.Framework;
using BowlingKata;
using System;

namespace BowlingKataTests
{
    [TestFixture]
    class FrameTest
    {
        Frame frame;

        [SetUp]
        public void SetUp()
        {
            frame = new Frame();
        }

        [Test]
        public void EmptyFrameValueIsZero()
        {
            Assert.AreEqual(0, frame.TotalValue);
        }

        [Test]
        public void CanAddNonStrikeRoll()
        {
            frame.Roll(3);

            Assert.AreEqual(3, frame.TotalValue);
        }

        [Test]
        public void CanAddTwoNonStrikeOrSpareThrows()
        {
            frame.Roll(2);
            frame.Roll(5);

            Assert.AreEqual(7, frame.TotalValue);
        }

        [Test]
        public void FrameHasStrike()
        {
            frame.Roll(10);

            Assert.That(frame.HasStrike, Is.True);
            Assert.That(frame.HasSpare, Is.False);
        }

        [Test]
        public void FrameHasSpare()
        {
            frame.Roll(0);
            frame.Roll(10);

            Assert.That(frame.HasSpare, Is.True);
            Assert.That(frame.HasStrike, Is.False);
        }

        [Test]
        public void FrameDoesNotHaveSpareOrStrike()
        {
            frame.Roll(6);
            frame.Roll(3);

            Assert.That(frame.HasStrike, Is.False);
            Assert.That(frame.HasSpare, Is.False);
        }

        [Test]
        public void FrameScoreCannotBeMoreThanTen()
        {
            frame.Roll(6);

            Assert.Throws<ArgumentOutOfRangeException>(() => frame.Roll(5));
        }

        [Test]
        public void FrameCannotTakeMoreThanTwoRolls()
        {
            frame.Roll(1);
            frame.Roll(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => frame.Roll(1));
        }

        [Test]
        public void FrameIsCompleteWithStrike()
        {
            frame.Roll(10);

            Assert.That(frame.Complete && frame.HasStrike, Is.True);
        }

        [Test]
        public void FrameIsComplete()
        {
            frame.Roll(1);
            frame.Roll(5);

            Assert.That(frame.Complete, Is.True);
        }

        [Test]
        public void CanGetRollValues()
        {
            int rollValue1 = 3;
            int rollValue2 = 6;

            frame.Roll(rollValue1);
            frame.Roll(rollValue2);

            Assert.That(frame.RollValue(1), Is.EqualTo(rollValue1));
            Assert.That(frame.RollValue(2), Is.EqualTo(rollValue2));
        }

        [Test]
        public void InvalidRollValueNumbersThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => frame.RollValue(1));
        }
    }
}
