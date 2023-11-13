using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class TextBoxMulti : TextBox
    {
        public TextBoxMulti(float ratio, int width)
        {
            Size = new Size(100, (int)(275 * ratio));
            Location = new Point(width - this.Width - 100, 10);
            this.Multiline = true;
        }

        public List<int> GetCellFromText(ref List<string> inputText)
        {
            string[] lineReturnSplit = Text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> intText = new List<int>();
            inputText.Clear();
            
            int temp;

            for (int i = 0; i < lineReturnSplit.Length; i++)
            {
                if (int.TryParse(lineReturnSplit[i], out temp))
                {
                    inputText.Add(lineReturnSplit[i]);
                    intText.Add(int.Parse(lineReturnSplit[i]));
                }
            }
            return intText;
        }
    }
}
