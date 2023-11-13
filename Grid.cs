using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace TD_Jeu_de_la_vie_WF
{
    class Grid
    {
        private int _gridSize;
        public int GridSize { get { return _gridSize; } set { _gridSize = value; } }

        Cell[,] TabCells;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            this.GridSize = nbCells;
            TabCells = new Cell[GridSize, GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    TabCells[i, j] = new Cell(false);
                    for (int k = 0; k < AliveCellsCoords.Count; k++)
                    {
                        if (AliveCellsCoords[k].X == i && AliveCellsCoords[k].Y == j)
                        {
                            TabCells[i, j] = new Cell(true);
                            break;
                        }
                    }
                }
            }
        }

        public int GetNbAliveNeighboor(int i, int j)
        {
            int closeCells = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        if (i + x >= 0 && j + y >= 0 && i + x < GridSize && j + y < GridSize)
                        {
                            if (TabCells[i + x, j + y].IsAlive)
                                closeCells++;
                        }
                    }
                }
            }
            return closeCells;
        }

        public List<Coords> UpdateGrid()
        {
            List<Coords> tempCoords = new List<Coords> ();
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    int closeCells = GetNbAliveNeighboor(i, j);

                    if (TabCells[i, j].IsAlive && (closeCells == 2 || closeCells == 3))
                    {
                        TabCells[i, j].NextState = true;
                        tempCoords.Add(new Coords(i, j));
                        Console.WriteLine("Didnt change");
                    }
                    else if (!TabCells[i, j].IsAlive && closeCells == 3)
                    {
                        TabCells[i, j].NextState = true;
                        tempCoords.Add(new Coords(i, j));
                        GlobalData.hasChanged = true;
                        Console.WriteLine("Changed appear");
                    }
                    else
                    {
                        TabCells[i, j].NextState = false;
                        tempCoords.Remove(new Coords(i, j));
                        GlobalData.hasChanged = true;
                        Console.WriteLine("Changed died");
                    }
                }
            }

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    TabCells[i, j].Update();
                }
            }
            return tempCoords;
        }
    }
}