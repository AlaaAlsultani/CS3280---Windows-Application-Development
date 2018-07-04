using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A4
{
    class TicTacToe
    {
        int[] GameBoard;

        int MovesMade;

        public TicTacToe()
        {
            GameBoard = new int[8];
            MovesMade = 0;
        }

        public void MakeMove(int player, int x, int y)
        {
            MovesMade++;
            int PlayerValue = player == 1 ? 1 : -1;
            GameBoard[x] = GameBoard[x] + PlayerValue;
            GameBoard[(y + 1) * 3] = GameBoard[(y + 1) * 3] + PlayerValue;
            if (x % 2 == 1 && y % 2 == 1) {
                GameBoard[6] = GameBoard[6] + PlayerValue;
                GameBoard[7] = GameBoard[7] + PlayerValue;
            }
            else if((x == 0 && y == 0) || (x == 2 && y == 2)){
                GameBoard[6] = GameBoard[6] + PlayerValue;
            }
            else if((x == 0 &&  y == 2) || (x == 2 && y  == 0))
            {
                GameBoard[7] = GameBoard[7] + PlayerValue;
            }
        }

        public int GameWon()
        {
            for(int i = 0; i < GameBoard.Length; i++)
            {
                if(GameBoard[i] == 3)
                {
                    return 1;
                }
                else if(GameBoard[i] == -3)
                {
                    return 2;
                }
            }
            if(MovesMade == 9)
            {
                return 4;
            }
            return 0;
        }
    }
}
