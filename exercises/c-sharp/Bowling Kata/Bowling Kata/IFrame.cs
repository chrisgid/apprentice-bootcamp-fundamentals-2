using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public interface IFrame
    {
        int TotalValue { get; }
        bool HasStrike { get; }
        bool HasSpare { get; }
        bool Complete { get; }

        void Roll(int pinsKnocked);
        int RollValue(int rollNumber);
    }
}
