using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Frame : IFrame
    {
        private const int maxScore = 10;
        private const int maxRolls = 2;
        private readonly int strikeScore = maxScore;
        private List<int> Rolls = new List<int>();
        
        public int TotalValue { get => Rolls.Sum(); }

        public bool HasStrike { get => Rolls.Count > 0 && Rolls.First() == strikeScore; }
        public bool HasSpare { get => !HasStrike && Rolls.Sum() == maxScore; }
        public bool Complete { get => Rolls.Count >= maxRolls || HasStrike; }

        public void Roll(int pinsKnocked)
        {
            int newScore = TotalValue + pinsKnocked;

            if (newScore <= maxScore && !Complete)
            {
                Rolls.Add(pinsKnocked);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Frame cannot have a higher score than {maxScore} or more than {maxRolls} rolls");
            }
        }

        public int RollValue(int rollNumber)
        {
            bool validRollNumber = rollNumber > 0 && rollNumber <= Rolls.Count;

            if (!validRollNumber)
            {
                throw new ArgumentOutOfRangeException("Invalid roll number");
            }

            int rollIndex = rollNumber - 1;
            return Rolls[rollIndex];
        }
    }
}
