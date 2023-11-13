using System;
using System.Security.Cryptography.X509Certificates;

namespace TD_Jeu_de_la_vie_WF
{
    class Coords
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            private set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            private set { _y = value; }
        }


        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
