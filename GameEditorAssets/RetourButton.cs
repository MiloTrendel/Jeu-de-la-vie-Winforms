using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class RetourButton : Label
    {
        public RetourButton()
        {
            Text = "Retour";
            Font = new Font("Arial", 15);
            TextAlign = ContentAlignment.MiddleCenter;
            Anchor = AnchorStyles.Left | AnchorStyles.Top;
        }
    }
}
