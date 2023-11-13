using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.MenuAssets
{
    class Text : Label
    {
        public Text(string text, Size size, Font fontSize)
        {
            Text = text;
            Size = size;
            Font = fontSize;
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
