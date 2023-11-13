using System;
using System.Runtime.CompilerServices;
using TD_Jeu_de_la_vie_WF.GameEditorAssets;
using TD_Jeu_de_la_vie_WF.MenuAssets;

namespace TD_Jeu_de_la_vie_WF
{
    public partial class Menu : Form
    {
        Text text;
        Text cellText;
        Text affText;
        StartButton sttButton;
        GameEditor gmEditor;

        public static CelluleSelector? cellSelec;
        public static ComboBox? affSelec;
        int nbCellule;

        public Menu()
        {
            InitializeComponent();

            affSelec = comboBox;
            gmEditor = new GameEditor();

            const string cellSTxt = "Nombre de cellules pour une colonne ?";
            const string affSTxt = "Taille de l'affichage";

            text = new Text("JEU DE LA VIE", new Size(300, 40), new Font("Arial", 30));

            sttButton = new StartButton();
            sttButton.Click += new EventHandler(ChangeScene);

            cellSelec = new CelluleSelector();

            cellText = new Text(cellSTxt, new Size(200, 40), new Font("Arial", 10));

            affSelec.Font = new Font("Arial", 15);
            affSelec.Width = 200;

            affText = new Text(affSTxt, new Size(200, 40), new Font("Arial", 10));

            Controls.Add(text);
            Controls.Add(sttButton);
            Controls.Add(cellSelec);
            Controls.Add(cellText);
            Controls.Add(affText);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            BackColor = Color.DarkGray;
            if (GlobalData.menuCellSelec != null) cellSelec.Text = GlobalData.nbCells.ToString();

            if (GlobalData.menuAffSelec != null) affSelec.Text = GlobalData.menuAffSelec;

            this.Size = new Size(1073, 700);
            this.Text = "Jeu de la vie";
            text.Location = new Point(this.Width / 2 - text.Width / 2, 10);
            sttButton.Location = new Point(this.Width / 2 - sttButton.Width / 2, 500);
            cellSelec.Location = new Point(this.Width / 2 - cellSelec.Width / 2, 200);
            cellText.Location = new Point(this.Width / 2 - cellText.Width / 2, cellSelec.Location.Y - cellText.Height);
            affSelec.Location = new Point(this.Width / 2 - comboBox.Width / 2, 350);
            affText.Location = new Point(this.Width / 2 - affText.Width / 2, comboBox.Location.Y - affText.Height + 5);
        }
        
        private void ChangeScene(object sender, EventArgs e)
        {
            if (cellSelec.Text == string.Empty || cellSelec.Text == "0") cellText.ForeColor = Color.Red;
            else cellText.ForeColor = Color.Black;

            if (affSelec.Text == string.Empty) affText.ForeColor = Color.Red;
            else affText.ForeColor = Color.Black;

            if (cellSelec.Text != string.Empty && affSelec.Text != string.Empty && cellSelec.Text != "0")
            {
                GlobalData.nbCells = int.Parse(cellSelec.Text);
                switch (affSelec.Text)
                {
                    case "Petit":
                        GlobalData.formSize = new Size(854, 550);
                        GlobalData.assetsRatio = 1.6f;
                        break;

                    case "Moyen":
                        GlobalData.formSize = new Size(1073, 700);
                        GlobalData.assetsRatio = 2;
                        break;

                    case "Grand":
                        GlobalData.formSize = new Size(1438, 910);
                        GlobalData.assetsRatio = 2.8f;
                        break;
                }
                GlobalData.UpdateCellSize();
                GlobalData.menuAffSelec = affSelec.Text;
                Jeu j = new Jeu();
                gmEditor.Show();
                this.Hide();
            }
        }
    }
}
