using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpgaveIOOPOgDatabase
{
    internal class CBox : CObject
    {
        public CBox(Position position, Size size, CObject? parent = null) : base(position, size, parent) 
        {
            Render();
            
        }

        internal void Render()
        {
            if (parent != null)
            {
                if (position.Horizontal + size.Horizontal > parent.size.Horizontal)
                {
                    size.Horizontal = parent.size.Horizontal - position.Horizontal;
                }

                if (position.Vertical + size.Vertical > parent.size.Vertical)
                {
                    size.Vertical = parent.size.Vertical - position.Vertical;
                }
            }

            string line = string.Concat(Enumerable.Repeat("X", size.Horizontal));

            for(int i = 0; i < size.Vertical; i++)
            {
               Write(new Position(position.Horizontal, position.Vertical + i), line);
            }
        }
    }
}
