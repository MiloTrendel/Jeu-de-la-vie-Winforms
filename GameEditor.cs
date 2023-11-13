using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using TD_Jeu_de_la_vie_WF.GameEditorAssets;

namespace TD_Jeu_de_la_vie_WF
{
    public partial class GameEditor : Form
    {
        List<string> inputText = new List<string>();
        System.Windows.Forms.Timer timer;
        RetourButton rtButton;
        StartGrid sttGrid;
        List<EditableCell> cellList;
        List<EditableCell> currCellList;
        TextBoxMulti textBox;
        BeginButton beginButton;
        RandomCheckbox rndCheckBox;
        SizeLabel sizeLabel;

        CellNumberButton add1Cell;
        CellNumberButton add5Cell;
        CellNumberButton remove1Cell;
        CellNumberButton remove5Cell;

        string currText = string.Empty;

        public GameEditor()
        {
            InitializeComponent();

            cellList = new List<EditableCell>();
            currCellList = new List<EditableCell>();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(UpdateGrid);

            rtButton = new RetourButton();
            rtButton.Click += new EventHandler(Retour_Click);

            // sizeLabel = new SizeLabel();

            Controls.Add(rtButton);
            Controls.Add(sizeLabel);
        }

        private void GameEditor_Load(object sender, EventArgs e)
        {
            Size = GlobalData.formSize;
            BackColor = Color.DarkGray;

            textBox = new TextBoxMulti(GlobalData.assetsRatio, this.Width);

            sttGrid = new StartGrid(textBox.Location.X, GlobalData.nbCells, GlobalData.cellSize);
            sttGrid.MouseClick += new MouseEventHandler(UpdateCell_OnClick);
            sttGrid.Paint += new PaintEventHandler(PaintGrid);

            beginButton = new BeginButton(GlobalData.assetsRatio, sttGrid);
            beginButton.Click += new EventHandler(Begin_Click);

            /* rndCheckBox = new RandomCheckbox(sttGrid.Location.X);
            rndCheckBox.Click += new EventHandler(CheckBox_Click);

            sizeLabel.Text = GlobalData.nbCells.ToString();
            sizeLabel.Size = new Size((int)(50 * GlobalData.assetsRatio), (int)(20 * GlobalData.assetsRatio));
            sizeLabel.Location = new Point(sttGrid.Location.X / 2 - sizeLabel.Width / 2, sttGrid.Location.Y + sttGrid.Height / 2 - sizeLabel.Height / 2);

            add1Cell = new CellNumberButton("+1", 1, new Point(sizeLabel.Location.X + sizeLabel.Width, sizeLabel.Location.Y));
            add5Cell = new CellNumberButton("+5", 5, new Point(add1Cell.Location.X + add1Cell.Width, sizeLabel.Location.Y));
            remove1Cell = new CellNumberButton("-1", -1, new Point(sizeLabel.Location.X - add1Cell.Width, sizeLabel.Location.Y));
            remove5Cell = new CellNumberButton("-5", -5, new Point(remove1Cell.Location.X - remove1Cell.Width, sizeLabel.Location.Y));

            add1Cell.Click += new EventHandler(AddCell_Click);
            add5Cell.Click += new EventHandler(AddCell_Click);
            remove1Cell.Click += new EventHandler(AddCell_Click);
            remove5Cell.Click += new EventHandler(AddCell_Click);
            */

            timer.Start();

            Controls.Add(sttGrid);
            Controls.Add(textBox);
            Controls.Add(beginButton);
            Controls.Add(rndCheckBox);
            //Controls.Add(add1Cell);
            //Controls.Add(add5Cell);
            //Controls.Add(remove1Cell);
            //Controls.Add(remove5Cell);
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            List<int> inputCellList = textBox.GetCellFromText(ref inputText);
            UpdateCellFromText();
            // sizeLabel.Text = GlobalData.nbCells.ToString();

            this.Refresh();
        }

        private void UpdateCell_OnClick(object sender, MouseEventArgs e)
        {
            int tempX = e.X / GlobalData.cellSize;
            int tempY = e.Y / GlobalData.cellSize;
            bool isNotPresent = false;
            if (cellList.Count != 0)
            {
                for (int i = 0; i < cellList.Count; i++)
                {
                    if (!(cellList[i].x == tempX && cellList[i].y == tempY))
                        isNotPresent = true; 

                    else
                    {
                        for (int j = 0; j < inputText.Count - inputText.Count % 2; j += 2)
                        {
                            if (inputText[j] == (tempX + 1).ToString() && inputText[j + 1] == (tempY + 1).ToString())
                            {
                                if (j == 0)
                                    textBox.Text = textBox.Text.Replace(inputText[j] + " " + inputText[j + 1] + "\r\n", string.Empty);
                                else 
                                    textBox.Text = textBox.Text.Replace("\r\n" + inputText[j] + " " + inputText[j + 1], string.Empty);
                            }
                        }
                        isNotPresent = false;
                        break;
                    }
                }
            }
            else isNotPresent = true;

            if (isNotPresent)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Text[textBox.Text.Length - 1] != '\n' && textBox.Text[textBox.Text.Length - 2] != '\r')
                    {
                        textBox.Text += "\r\n" + (tempX + 1) + " " + (tempY + 1) + "\r\n";
                    }
                    else
                    {
                        textBox.Text += (tempX + 1) + " " + (tempY + 1) + "\r\n";
                    }
                }
                else
                {
                    textBox.Text = "";
                    textBox.Text += (tempX + 1) + " " + (tempY + 1) + "\r\n";
                }
                
            }
            textBox.Select(textBox.Text.Length, 0);
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            if (cellList.Count != 0 || GlobalData.isRandom )
            {
                if (!GlobalData.isRandom)
                {
                    for (int i = 0; i < cellList.Count; i++)
                    {
                        GlobalData.StartAliveCellCoords.Add(new Coords(cellList[i].x, cellList[i].y));
                    }
                    GlobalData.AliveCellsCoords = GlobalData.StartAliveCellCoords;
                    GlobalData.PrevAliveCellsCoords = GlobalData.StartAliveCellCoords;
                }
                else
                {
                    Random rand = new Random();

                    for (int i = 0; i < rand.Next(5, GlobalData.nbCells * GlobalData.nbCells / 2); i++)
                    {
                        GlobalData.StartAliveCellCoords.Add(new Coords(rand.Next(0, GlobalData.nbCells), rand.Next(0, GlobalData.nbCells)));
                    }
                    GlobalData.AliveCellsCoords = GlobalData.StartAliveCellCoords;
                    GlobalData.PrevAliveCellsCoords = GlobalData.StartAliveCellCoords;
                }

                Jeu jeu = new Jeu();
                jeu.Show();
                this.Hide();
            }
        }

        private void Retour_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (!GlobalData.isRandom)
            {
                GlobalData.isRandom = true;
                sttGrid.MouseClick -= UpdateCell_OnClick;
                textBox.ReadOnly = true;
                currText = textBox.Text;
                textBox.Text = "";
                currCellList = cellList;
                cellList.Clear();
            }
            else
            {
                GlobalData.isRandom = false;
                textBox.ReadOnly = false;
                textBox.Text = currText;
                cellList = currCellList;
                sttGrid.MouseClick += new MouseEventHandler(UpdateCell_OnClick);
            }
        }

        private void AddCell_Click(object sender, EventArgs e)
        {
            CellNumberButton button = sender as CellNumberButton;
            if (GlobalData.nbCells + button.amount < 1)
                GlobalData.nbCells = 1;
            else
                GlobalData.nbCells += button.amount;
            GlobalData.UpdateCellSize();
            // sttGrid.Size = new Size(GlobalData.nbCells * GlobalData.cellSize, GlobalData.nbCells * GlobalData.cellSize);

            foreach (EditableCell cell in cellList)
            {
                cell.x += button.amount;
                cell.y += button.amount;
            }
        }

        private void UpdateCellFromText()
        {
            cellList.Clear();
            for (int i = 0; i < inputText.Count - inputText.Count % 2; i += 2)
            {
                cellList.Add(new EditableCell(int.Parse(inputText[i]) - 1, int.Parse(inputText[i + 1]) - 1));
            }
        }

        private void PaintGrid(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.White);

            PaintWhiteGrid(g);

            for (int i = 0; i < cellList.Count; i++)
            {
                g.FillRectangle(brush, cellList[i].x * GlobalData.cellSize + 1, cellList[i].y * GlobalData.cellSize + 1, GlobalData.cellSize - 1, GlobalData.cellSize - 1);
            }
        }

        private void PaintWhiteGrid(Graphics g)
        {
            int diff = (sttGrid.Width - (GlobalData.cellSize * GlobalData.nbCells)) / 2;

            SolidBrush brush = new SolidBrush(Color.Gray);
            for (int i = 0; i < GlobalData.nbCells + 1; i++)
            {
                g.FillRectangle(brush, i * GlobalData.cellSize, 0, 1, sttGrid.Height); // - diff
            }

            for (int i = 0; i < GlobalData.nbCells + 1; i++)
            {
                g.FillRectangle(brush, 0, i * GlobalData.cellSize, sttGrid.Width, 1); // - diff
            }
        }
    }
}
