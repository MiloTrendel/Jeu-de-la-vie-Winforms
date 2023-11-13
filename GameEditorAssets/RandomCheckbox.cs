using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class RandomCheckbox : CheckBox
    {
        public RandomCheckbox(int x)
        {
            Location = new Point(x / 2 - this.Width / 2, 100);
            Font = new Font("Arial", 15);
            Text = "Random";
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
        }
    }
}
