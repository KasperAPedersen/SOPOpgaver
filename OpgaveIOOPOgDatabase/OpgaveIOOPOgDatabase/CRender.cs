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
            string tmp = new string(' ', size.Horizontal);
            for(int i = 0; i < size.Vertical; i++)
            {
                Console.SetCursorPosition(pos.Horizontal, pos.Vertical + i);
                Console.Write(tmp);
            }
        }

        internal Position Align(CObject obj, CObject parent, Alignment alignment)
        {
            Position pos = new Position(0, 0);

            switch(alignment)
            {
                case Alignment.TopLeft:
                    pos = new Position(1, 1);
                    break;
                case Alignment.TopRight:
                    pos = new Position(parent.size.Horizontal - obj.size.Horizontal - obj.position.Horizontal - 1, 1);
                    break;
                case Alignment.TopCenter:
                    pos = new Position((parent.size.Horizontal - obj.size.Horizontal - 1) / 2, 1);
                    break;
                case Alignment.BottomLeft:
                    pos = new Position(1, parent.size.Vertical - obj.size.Vertical - 1 - obj.position.Vertical);
                    break;
                case Alignment.BottomRight:
                    pos = new Position(parent.size.Horizontal - obj.size.Horizontal - 1 - obj.position.Horizontal, parent.size.Vertical - obj.size.Vertical - 1 - obj.position.Vertical);
                    break;
                case Alignment.BottomCenter:
                    pos = new Position((parent.size.Horizontal - obj.size.Horizontal) / 2, parent.size.Vertical - obj.size.Vertical - 1 - obj.position.Vertical);
                    break;
                case Alignment.MiddleLeft:
                    pos = new Position(1, (parent.size.Vertical - obj.size.Vertical) / 2);
                    break;
                case Alignment.MiddleRight:
                    pos = new Position(parent.size.Horizontal - obj.size.Horizontal - 1 - obj.position.Horizontal, ((parent.size.Vertical - obj.size.Vertical) / 2));
                    break;
                case Alignment.MiddleCenter:
                    pos = new Position((parent.size.Horizontal - obj.size.Horizontal) / 2, (parent.size.Vertical - obj.size.Vertical) / 2);
                    break;

            }

            return pos;
        }
    
        public enum Alignment
        {
            None = 0,
            TopLeft = 1,
            TopCenter = 2,
            TopRight = 3,
            BottomLeft = 4,
            BottomRight = 5,
            BottomCenter = 6,
            MiddleLeft = 7,
            MiddleRight = 8,
            MiddleCenter = 9
        }

        internal static char Border(Get _part)
        {
            return _part switch
            {
                Get.TopLeft => '┌',
                Get.TopRight => '┐',
                Get.BottomLeft => '└',
                Get.BottomRight => '┘',
                Get.Horizontal => '─',
                Get.HorizontalDown => '┬',
                Get.HorizontalUp => '┴',
                Get.Vertical => '│',
                Get.VerticalLeft => '├',
                Get.VerticalRight => '┤',
                Get.Cross => '┼',
                Get.ArrowDown => '↓',
                _ => throw new InvalidOperationException("Unknown Global.Border part."),
            };
        }

        internal enum Get
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Horizontal,
            HorizontalDown,
            HorizontalUp,
            Vertical,
            VerticalLeft,
            VerticalRight,
            Cross,
            ArrowDown
        }
    }
}
