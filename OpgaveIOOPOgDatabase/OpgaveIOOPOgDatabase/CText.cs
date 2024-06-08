using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpgaveIOOPOgDatabase.CRender;

namespace OpgaveIOOPOgDatabase
{
    internal class CText : CObject
    {
        public Alignment alignment { get; set; } = Alignment.None;
        public string text = "Swoopai";

        internal void Render()
        {
            if (alignment != Alignment.None && parent != null)
            {
                position = Align(this, parent, alignment);
                position = new Position(position.Horizontal - (text.Length / 2), position.Vertical);
                absPosition = new Position(absPosition.Horizontal + (position.Horizontal < 0 ? 1 : position.Horizontal), absPosition.Vertical + (position.Vertical < 0 ? 1 : position.Vertical));
            }

            if (parent != null)
            {
                position.Horizontal = Math.Max(1, position.Horizontal);
                position.Vertical = Math.Max(1, position.Vertical);
                
            }

            if (position.Horizontal + size.Horizontal > (parent?.size.Horizontal ?? Console.WindowWidth))
                size.Horizontal = (parent?.size.Horizontal ?? Console.WindowWidth) - position.Horizontal - 1;

            if (position.Vertical + size.Vertical > (parent?.size.Vertical ?? Console.WindowHeight))
                size.Vertical = (parent?.size.Vertical ?? Console.WindowHeight) - position.Vertical - 1;

            
            Write(absPosition, text);
        }
    }

    internal class CTextBuilder
    {
        private CText text = new();

        public CText Build()
        {
            text.Render();
            return text;
        }

        public CTextBuilder AddAlignment(Alignment align)
        {
            text.alignment = align;
            return this;
        }

        public CTextBuilder AddText(string newText)
        {
            text.text = newText;
            text.size = new Size(newText.Length, 1);
            return this;
        }

        public CTextBuilder AddPosition(int x, int y)
        {
            Position position = new Position(x, y);
            text.position = position;
            text.absPosition = new Position((text.parent?.absPosition.Horizontal ?? 0) + text.position.Horizontal, (text.parent?.absPosition.Vertical ?? 0) + text.position.Vertical);

            return this;
        }

        public CTextBuilder AddParent(CObject parent)
        {
            text.parent = parent;
            text.absPosition = new Position((text.parent?.absPosition.Horizontal ?? 0) + text.position.Horizontal, (text.parent?.absPosition.Vertical ?? 0) + text.position.Vertical);

            return this;
        }

        public CTextBuilder Default()
        {
            text.parent = null;
            text.position = new Position(0, 0);
            text.alignment = Alignment.None;
            text.text = "Swoopai";
            return this;
        }
    }
}
