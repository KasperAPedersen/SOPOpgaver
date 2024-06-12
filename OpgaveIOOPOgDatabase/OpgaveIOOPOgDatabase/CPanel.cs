using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpgaveIOOPOgDatabase.CRender;

namespace OpgaveIOOPOgDatabase
{
    internal class CPanel : CObject
    {
        public Alignment alignment { get; set; } = Alignment.None;

        internal void Render()
        {

            if (alignment != Alignment.None && parent != null)
            {
                position = Align(this, parent, alignment);
                absPosition = new Position(absPosition.Horizontal + position.Horizontal, absPosition.Vertical + position.Vertical);
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

            Write(absPosition, new string('#', size.Horizontal));
            for (int i = 1; i < size.Vertical - 1; i++)
            {
                Write(new Position(absPosition.Horizontal, absPosition.Vertical + i), $"#{new string(' ', size.Horizontal - 2)}#");

            }
            Write(new Position(absPosition.Horizontal, absPosition.Vertical + size.Vertical - 1), new string('#', size.Horizontal));

        }
    }

    internal class CPanelBuilder
    {
        private CPanel panel = new();

        public CPanel Build()
        {
            panel.Render();
            return panel;
        }

        public CPanelBuilder AddAlignment(Alignment align)
        {
            panel.alignment = align;
            return this;
        }

        public CPanelBuilder AddPosition(int x, int y)
        {
            Position position = new Position(x, y);
            panel.position = position;
            panel.absPosition = new Position((panel.parent?.absPosition.Horizontal ?? 0) + panel.position.Horizontal, (panel.parent?.absPosition.Vertical ?? 0) + panel.position.Vertical);
            return this;
        }

        public CPanelBuilder AddSize(int x, int y)
        {
            Size size = new Size(x, y);
            panel.size = size;
            return this;
        }

        public CPanelBuilder AddParent(CObject parent)
        {
            panel.parent = parent;
            panel.absPosition = new Position((panel.parent?.absPosition.Horizontal ?? 0) + panel.position.Horizontal, (panel.parent?.absPosition.Vertical ?? 0) + panel.position.Vertical);
            return this;
        }

        public CPanelBuilder Default()
        {
            panel.parent = null;
            panel.position = new Position(0, 0);
            panel.absPosition = new Position(0, 0);
            panel.alignment = Alignment.None;
            return this;
        }
    }
}
