using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.Controls
{
    class GameButton : Button
    {
        public GameButton()
        {
            Name = "btn_simulation";
            Text = "Start";
            BackColor = Color.LightGray;
            ForeColor = Color.Black;
            Dock = DockStyle.None;
            Font = new Font("Arial", 14);
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
