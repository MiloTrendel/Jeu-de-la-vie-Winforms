using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class StartGrid : PictureBox
    {
        public StartGrid(int x, int nbCells, int cellSize)
        {
            Size = new Size(nbCells * cellSize, nbCells * cellSize);
            //Size = new Size((int)(275 * GlobalData.assetsRatio), (int)(275 * GlobalData.assetsRatio));
            Location = new Point(x - this.Width - 60, 10);
            Name = "Start Grid";
            BackColor = Color.Black;
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
        }
    }
}
