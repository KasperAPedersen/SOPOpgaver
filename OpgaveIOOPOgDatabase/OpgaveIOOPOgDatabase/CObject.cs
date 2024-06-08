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
        public Position absPosition;
        public Size size;
        public CObject? parent;
    }
}
