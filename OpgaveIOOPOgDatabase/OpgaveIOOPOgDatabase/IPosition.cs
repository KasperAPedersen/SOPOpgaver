using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveIOOPOgDatabase
{
    struct Position(int horizontal, int vertical)
    {
        public int Horizontal { get; set; } = horizontal;
        public int Vertical { get; set; } = vertical;
    }

    internal interface IPosition
    {
        Position position { get; set; }
    }
}
