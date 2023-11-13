using System;
using System.Windows.Forms.Design;

namespace TD_Jeu_de_la_vie_WF.Controls
{
    class MainLabel : Label
    {
        public MainLabel() 
        {
            AutoSize = false;
            Anchor = AnchorStyles.None;
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
            Text = "0";
            Dock = DockStyle.None;
        }
    }
}
