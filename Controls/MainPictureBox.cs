using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD_Jeu_de_la_vie_WF.Controls
{
    class MainPictureBox : PictureBox
    {
        public MainPictureBox()
        {
            Name = "Main Picture Box";
            BackColor = Color.Black;
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
        }
    }
}
