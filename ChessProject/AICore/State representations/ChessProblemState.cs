using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class ChessProblemState : AbstractState
    {
        char[,] chessboard;

        /// <summary>
        /// K - king
        /// B - bishop
        /// R - rook
        /// 
        /// 0 - empty square
        /// </summary>

        static char[,] GOAL = new char[,]
        {
            { '#', '#', '#', '#', '#' },
            { '#', 'B', 'B', '0', '#' },
            { '#', 'R', 'R', 'K', '#' },
            { '#', '#', '#', '#', '#' }
        };

        public ChessProblemState()
        {
            this.chessboard = new char[,]
            {
                { '#', '#', '#', '#', '#' },
                { '#', 'K', 'B', 'B', '#' },
                { '#', 'R', 'R', '0', '#' },
                { '#', '#', '#', '#', '#' }
            };
        }

        public ChessProblemState(char[,] board)
        {
            this.chessboard = board;
        }

        public int GetXLength
        {
            get { return this.chessboard.GetLength(0); }
        }

        public int GetYLength
        {
            get { return this.chessboard.GetLength(1); }
        }

        public char[,] GetState
        {
            get { return (char[,])this.chessboard.Clone(); }
        }

        public override bool IsGoalState()
        {
            for (int i = 0; i < this.GetXLength; i++)
            {
                for (int u = 0; u < this.GetYLength; u++)
                {
                    if (this.chessboard[i, u] != GOAL[i, u]) return false;
                }
            }
            return true;
        }

        public override bool IsState()
        {
            for (int i = 0; i < this.GetYLength; i++)
            {
                if (chessboard[0,i] != '#' || chessboard[this.GetXLength - 1, i] != '#') { return false; }
            }

            for (int i = 1; i < this.GetXLength - 1; i++)
            {
                if (chessboard[i, 0] != '#' || chessboard[i, this.GetYLength - 1] != '#') { return false; }
            }

            return true;
        }

        public bool IsOperator(int x, int y, Direction8 dir)
        {
            if (!IsState()) return false;
            if (x < 0 && x > this.GetXLength - 1) return false;
            if (y < 0 && y > this.GetYLength - 1) return false;


            char piece = this.chessboard[x, y];
            if (piece == '#') return false;
            if (piece == 'R' && (int)dir > 3) return false;
            if (piece == 'B' && (int)dir < 4) return false;
            if (piece == '0') return false;
            switch (dir)
            {
                case Direction8.Up:
                    if (chessboard[x - 1, y] != '0') return false;
                    break;
                case Direction8.Down:
                    if (chessboard[x + 1, y] != '0') return false;
                    break;
                case Direction8.Left:
                    if (chessboard[x, y - 1] != '0') return false;
                    break;
                case Direction8.Right:
                    if (chessboard[x, y + 1] != '0') return false;
                    break;
                case Direction8.UpLeft:
                    if (chessboard[x - 1, y - 1] != '0') return false;
                    break;
                case Direction8.UpRight:
                    if (chessboard[x - 1, y + 1] != '0') return false;
                    break;
                case Direction8.DownLeft:
                    if (chessboard[x + 1, y - 1] != '0') return false;
                    break;
                case Direction8.DownRight:
                    if (chessboard[x + 1, y + 1] != '0') return false;
                    break;

            }
            return true;
        }

        public bool ApplyOperator(int x, int y, Direction8 dir)
        {
            if (!IsOperator(x, y, dir)) return false;
            ChessProblemState clone = (ChessProblemState)this.Clone();
            char tempswap;
            switch (dir)
            {
                case Direction8.Up:
                    tempswap = chessboard[x - 1, y];
                    chessboard[x - 1, y] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.Down:
                    tempswap = chessboard[x + 1, y];
                    chessboard[x + 1, y] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.Left:
                    tempswap = chessboard[x, y - 1];
                    chessboard[x, y - 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.Right:
                    tempswap = chessboard[x, y + 1];
                    chessboard[x, y + 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.UpLeft:
                    tempswap = chessboard[x - 1, y - 1];
                    chessboard[x - 1, y - 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.UpRight:
                    tempswap = chessboard[x - 1, y + 1];
                    chessboard[x - 1, y + 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.DownLeft:
                    tempswap = chessboard[x + 1, y - 1];
                    chessboard[x + 1, y - 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;
                case Direction8.DownRight:
                    tempswap = chessboard[x + 1, y + 1];
                    chessboard[x + 1, y + 1] = chessboard[x, y];
                    chessboard[x, y] = tempswap;
                    break;

            }
            if (IsState())
                return true;

            this.chessboard = clone.GetState;

            return false;
        }

        public override bool Equals(object obj)
        {
            char[,] vs = (obj as ChessProblemState).GetState;
            for (int i = 0; i < this.GetXLength; i++)
            {
                for (int u = 0; u < this.GetYLength; u++)
                {
                    if (this.chessboard[i, u] != vs[i, u]) return false;
                }
            }
            return true;
        }

        public override object Clone()
        {
            return new ChessProblemState(this.GetState);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.GetXLength; i++)
            {
                for (int u = 0; u < this.GetYLength; u++)
                {
                    sb.Append(this.chessboard[i, u]);
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
