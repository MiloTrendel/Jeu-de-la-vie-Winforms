using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class SizeLabel : Label
    {
        public SizeLabel()
        { 
            Anchor = AnchorStyles.None;
            Dock = DockStyle.None;
            BorderStyle = BorderStyle.FixedSingle;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Arial", 10);
        }  
    }
}
