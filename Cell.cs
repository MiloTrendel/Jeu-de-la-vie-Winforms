using System;

namespace TD_Jeu_de_la_vie_WF
{
    class Cell
    {
        private bool _isAlive;
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        private bool _nextState;
        public bool NextState { get { return _nextState; } set { _nextState = value; } }

        public Cell(bool state)
        {
            IsAlive = state;
        }

        public void ComeAlive()
        {
            NextState = true;
        }

        public void PassAway()
        {
            NextState = false;
        }

        public void Update()
        {
            IsAlive = NextState;
        }
    }
}