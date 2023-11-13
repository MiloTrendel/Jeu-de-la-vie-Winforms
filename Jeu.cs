using TD_Jeu_de_la_vie_WF.Controls;
using System;

using System.Windows.Forms;

namespace TD_Jeu_de_la_vie_WF
{
    public partial class Jeu : Form
    {
        MainPictureBox mnPicBox;
        MainLabel mnLabel;
        Grid grid;
        Button simuButton;
        GameButton restartButton;

        System.Windows.Forms.Timer timer;

        int generation;
        int nbCells;

        bool paused;
        bool started;


        public Jeu()
        {
            InitializeComponent();

            generation = 0;
            paused = false;
            started = false;

            mnPicBox = new MainPictureBox();

            mnLabel = new MainLabel();

            simuButton = new GameButton();
            restartButton = new GameButton();

            restartButton.Text = "Restart";

            restartButton.Click += new EventHandler(restartButton_Click);
            
            
            simuButton.Anchor = AnchorStyles.None;
            simuButton.Click += new EventHandler(simuButton_Click);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += new EventHandler(UpdateGrid);

            Controls.Add(mnPicBox);
            Controls.Add(mnLabel);
            Controls.Add(simuButton);
            Controls.Add(restartButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Jeu de la vie";
            BackColor = Color.DarkGray; 

            Size = GlobalData.formSize;
            nbCells = GlobalData.nbCells;
            
            grid = new Grid(GlobalData.nbCells, GlobalData.AliveCellsCoords);
            mnPicBox.Size = new Size(GlobalData.cellSize * GlobalData.nbCells, GlobalData.nbCells * GlobalData.cellSize);
            mnLabel.Size = new Size((int)(85 * GlobalData.assetsRatio), (int)(18.5f * GlobalData.assetsRatio));
            simuButton.Size = new Size((int)(100 * GlobalData.assetsRatio), (int)(22.5f * GlobalData.assetsRatio));
            restartButton.Size = new Size((int)(100 * GlobalData.assetsRatio), (int)(22.5f * GlobalData.assetsRatio));

            mnLabel.Font = new Font("Arial", 17);

            mnPicBox.Location = new Point(this.Width / 2 - mnPicBox.Width / 2, 10);
            mnLabel.Location = new Point(this.Width / 2 - mnLabel.Width / 2, mnPicBox.Height + 30);
            simuButton.Location = new Point(mnPicBox.Location.X + mnPicBox.Width + 15, mnPicBox.Height / 2 - 40);
            restartButton.Location = new Point(mnPicBox.Location.X + mnPicBox.Width + 15, mnPicBox.Height / 2 + 40);

            mnPicBox.Paint += new PaintEventHandler(mnPicBox_Paint);
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            GlobalData.AliveCellsCoords = grid.UpdateGrid();
            Console.WriteLine("Changed " + GlobalData.hasChanged + " count : " + GlobalData.AliveCellsCoords.Count);
            if (GlobalData.hasChanged || GlobalData.PrevAliveCellsCoords.Count != 0)
            {
                UpdateUi();
                generation++;
                mnLabel.Text = generation.ToString();
                this.Refresh();
                GlobalData.PrevAliveCellsCoords = GlobalData.AliveCellsCoords;
                GlobalData.hasChanged = false;
            }
            else
                timer.Stop();
        }

        private void UpdateUi()
        {
            if (!started) simuButton.Text = "Start";
        }

        private void simuButton_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                timer.Start();
                simuButton.Text = "Pause";
                paused = true;
            }
            else
            {
                timer.Stop();
                simuButton.Text = "Resume";
                paused = false;
            }
            if (!started) started = true;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            generation = 0;
            mnLabel.Text = generation.ToString();
            GlobalData.AliveCellsCoords = GlobalData.StartAliveCellCoords;
            paused = false;
            started = false;
            UpdateUi();
            grid = new Grid(GlobalData.nbCells, GlobalData.AliveCellsCoords);
            this.Refresh();
        }


        private void mnPicBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.White);
            for (int i = 0; i < nbCells; i++)
            {
                for (int j = 0; j < nbCells; j++)
                {
                    for (int k = 0; k < GlobalData.AliveCellsCoords.Count; k++)
                    {
                        if (GlobalData.AliveCellsCoords[k].X == i && GlobalData.AliveCellsCoords[k].Y == j)
                        {
                            g.FillRectangle(brush, i * GlobalData.cellSize + 1, j * GlobalData.cellSize + 1, GlobalData.cellSize - 2, GlobalData.cellSize - 2);
                        }
                    }
                }
            }
        }
    }
}