using System;
using System.Collections.Generic;
using System.Threading;

namespace TD_Jeu_de_la_vie_WF
{
    class Game
    {
        public Grid grid;

        public Game(int nbCells)
        {
            grid = new Grid(nbCells, GlobalData.AliveCellsCoords);
        }

        /*public void RunGameConsole()
        {
            for (int i = 0; i < 10; i++)
            {
                // grid.DisplayGrid();
                //grid.UpdateGrid();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }*/
    }
}
