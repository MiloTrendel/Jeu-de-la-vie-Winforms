using System;

namespace TD_Jeu_de_la_vie_WF.GameEditorAssets
{
    class BeginButton : Button
    {
        public BeginButton(float ratio, StartGrid sttGrid)
        {
            Size = new Size((int)(100 * ratio), (int)(22.5f * ratio));
            Location = new Point(sttGrid.Location.X + sttGrid.Width / 2 - this.Width / 2, sttGrid.Height + 30);
            Name = "begin_button";
            Text = "Begin";
            BackColor = Color.LightGray;
            ForeColor = Color.Black;
            Dock = DockStyle.None;
            Font = new Font("Arial", 14);
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
