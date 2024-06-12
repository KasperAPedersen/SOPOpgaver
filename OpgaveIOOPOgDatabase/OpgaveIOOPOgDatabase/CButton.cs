using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpgaveIOOPOgDatabase.CRender;

namespace OpgaveIOOPOgDatabase
{
    internal class CButton : CObject
    {
        public Alignment alignment { get; set; } = Alignment.None;
        public string text = "SWP";

        internal void Render()
        {
            size.Vertical = 3;
            size.Horizontal = text.Length + 4;

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

            Write(absPosition, Border(Get.TopLeft) + new string(Border(Get.Horizontal), size.Horizontal - 2) + Border(Get.TopRight));

            Write(new Position(absPosition.Horizontal, absPosition.Vertical + 1),
                $"{Border(Get.Vertical)} {text} {Border(Get.Vertical)}");

            Write(new Position(absPosition.Horizontal, absPosition.Vertical + 2),
                Border(Get.BottomLeft) + new string(Border(Get.Horizontal), size.Horizontal - 2) + Border(Get.BottomRight));
        }
    }

    internal class CButtonBuilder
    {
        private CButton btn = new();

        public CButton Build()
        {
            btn.Render();
            return btn;
        }

        public CButtonBuilder AddAlignment(Alignment align)
        {
            btn.alignment = align;
            return this;
        }

        internal CButtonBuilder AddPosition(int x, int y)
        {
            Position position = new Position(x, y);
            btn.position = position;
            btn.absPosition = new Position((btn.parent?.absPosition.Horizontal ?? 0) + btn.position.Horizontal, (btn.parent?.absPosition.Vertical ?? 0) + btn.position.Vertical);
            return this;
        }

        public CButtonBuilder AddParent(CObject parent)
        {
            btn.parent = parent;
            btn.absPosition = new Position((btn.parent?.absPosition.Horizontal ?? 0) + btn.position.Horizontal, (btn.parent?.absPosition.Vertical ?? 0) + btn.position.Vertical);
            return this;
        }

        public CButtonBuilder AddText(string text)
        {
            btn.text = text;
            return this;
        }
    }
}
