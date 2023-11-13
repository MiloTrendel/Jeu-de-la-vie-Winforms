using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class CellNumberButton : Button
    {
        public int amount { get; private set; }
        public CellNumberButton(string text, int amount, Point point)
        {
            this.amount = amount;
            Size = new Size(40, 40);
            Location = point;
            Text = text;
            TextAlign = ContentAlignment.MiddleCenter;
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
        }
    }
}
