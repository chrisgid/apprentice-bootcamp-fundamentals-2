using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Game
    {
        private int _totalScore;



        public void Roll(int pinsKnocked)
        {
            _totalScore += pinsKnocked;
        }

        public int GetScore()
        {
            return _totalScore;
        }
    }
}
