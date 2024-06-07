using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveIOOPOgDatabase
{
    struct Size(int horizontal, int vertical)
    {
        public int Horizontal { get; set; } = horizontal; 
        public int Vertical { get; set; } = vertical;
    }

    internal interface ISize
    {
        Size size { get; set; }
    }
}
