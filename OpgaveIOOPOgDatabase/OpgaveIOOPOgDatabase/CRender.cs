using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OpgaveIOOPOgDatabase
{
    internal class CRender
    {
        internal void Write(Position pos, string text)
        {
            Console.SetCursorPosition(pos.Horizontal, pos.Vertical);
            Console.Write(text);
        }

        internal void Erase(Position pos, Size size)
        {
            string tmp = string.Concat(Enumerable.Repeat(" ", size.Horizontal));
            for(int i = 0; i < size.Vertical; i++)
            {
                Console.SetCursorPosition(pos.Horizontal, pos.Vertical + i);
                Console.Write(tmp);
            }
        }
    }
}
