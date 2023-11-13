using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TD_Jeu_de_la_vie_WF
{
    static class GlobalData
    {
        public static int nbCells;
        public static string menuAffSelec = null;
        public static string menuCellSelec = null;
        public static Size formSize;
        public static float assetsRatio;

        public static bool hasChanged = false;
        public static bool isRandom = false;

        public static int cellSize;

        public static List<Coords> StartAliveCellCoords = new List<Coords>();
        public static List<Coords> PrevAliveCellsCoords = new List<Coords>();
        public static List<Coords> AliveCellsCoords = new List<Coords>();

        public static void UpdateCellSize()
        {
            cellSize = (int)(275 * assetsRatio) / nbCells;
        }
    }
}
