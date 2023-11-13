using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF.MenuAssets
{
    class AffichageSelector : ComboBox
    {
        public string Value { get; set; }
        public string Affichage { get; set; }

        public void AffInit()
        {
            List<AffichageSelector> items = new List<AffichageSelector>();
            items.Add(new AffichageSelector() { Text = "displayText1", Value = "ValueText1" });
            items.Add(new AffichageSelector() { Text = "displayText2", Value = "ValueText2" });
            items.Add(new AffichageSelector() { Text = "displayText3", Value = "ValueText3" });

            this.DataSource = items;
            this.DisplayMember = "Text";
            this.ValueMember = "Value";

        }
    }

    public class Item
    {
        public Item() { }

        public string Value { set; get; }
        public string Text { set; get; }
    }

    
}
