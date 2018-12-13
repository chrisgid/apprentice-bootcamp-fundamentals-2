using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Table
    {
        private const int DefaultTableSize = 10;
        private const int ScoreNotCalculable = -1;
        private List<IFrame> frames;

        public Table(int tableSize = DefaultTableSize)
        {
            TableSize = tableSize;
            frames = new List<IFrame>();

            for (int i = 0; i < tableSize - 1; i++)
            {
                frames.Add(new Frame());
            }
            // TODO Make this a final frame type
            frames.Add(new Frame());
        }

        public int TableSize { get; }
        public int CurrentFrame { get => CurrentFrameIndex + 1; }
        public int TotalScore
        {
            get
            {
                int total = 0;

                for (int i = 0; i < frames.Count; i++)
                {
                    total += FrameScore(i);
                }
                
                return total;
            }
        }

        private int CurrentFrameIndex { get => frames.FindIndex(frame => !frame.Complete); }

        public void Roll(int pinsKnocked)
        {
            frames[CurrentFrameIndex].Roll(pinsKnocked);
        }

        private int FrameScore(int frameIndex)
        {
            var frame = frames[frameIndex];
            int score = frame.TotalValue;

            if (frame.HasStrike)
            {
                score += frames[frameIndex + 1].RollValue(1)
                       + frames[frameIndex + 1].RollValue(2);

                return score;
            }
            else if (frame.HasSpare)
            {
                score += frames[frameIndex + 1].RollValue(1);
                return score;
            }

            return score;
        }

        private int GetNextRollValue(int frameIndex)
        {
            switch (frames[frameIndex + 1].NumberOfRolls)
            {
                case 0:
                    return ScoreNotCalculable;
                default:
                    return frames[frameIndex + 1].RollValue(1);
            }
        }

        private int GetNextTwoRollValues(int frameIndex)
        {
            switch (frames[frameIndex + 1].NumberOfRolls)
            {
                case 0:
                    return ScoreNotCalculable;
                case 1:
                    int nextNextValue = GetNextRollValue(frameIndex + 1);
                    if (nextNextValue == ScoreNotCalculable)
                    {
                        return ScoreNotCalculable;
                    }
                    else
                    {
                        return nextNextValue + frames[frameIndex + 1].RollValue(1);
                    }
                case 2:
                    return frames[frameIndex + 1].RollValue(1) + frames[frameIndex + 1].RollValue(2);
                default:
                    return ScoreNotCalculable;
            }
        }
    }
}
