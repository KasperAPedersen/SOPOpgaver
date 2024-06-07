using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveIOOPOgDatabase
{
    internal class CObject : CRender
    {
        public Position position;
        public Size size;
        public CObject? parent;

        public CObject(Position position, Size size, CObject? parent = null)
        {
            this.position = position;
            this.size = size;
            this.parent = parent;
        }

    }
}
