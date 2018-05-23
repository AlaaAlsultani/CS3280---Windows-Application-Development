using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A4WPF
{
    /// <summary>
    /// TicTacToe Class - Contains functions for making moves and checking for win/loss/tie
    /// </summary>
    class TicTacToe
    {
        #region Attributes

        /// <summary>
        /// Integer array that holds the value of the active squares in a row/col/diag
        /// Corresponds to 0-7 in the GameGroups enum
        /// </summary>
        private int[] GroupValues;
        /// <summary>
        /// Count of the total moves made. 9 = Tie
        /// </summary>
        private int MovesMade;
        /// <summary>
        /// 1 or 2, changes everytime a move is made
        /// </summary>
        private int CurrentPlayer;
        /// <summary>
        /// 1,2, or 3 representing Player 1, Player 2, or a Tie
        /// </summary>
        private int Winner;
        /// <summary>
        /// boolean representing whether or not the current game is active
        /// </summary>
        private bool Active;


        /// <summary>
        /// Enum holding the different types of Win conditions as well as Cont which signifies no win condition has been met.
        /// </summary>
        private enum GameGroups
        {
            Col1 = 0,
            Col2 = 1,
            Col3 = 2,
            Row1 = 3,
            Row2 = 4,
            Row3 = 5,
            Diag = 6,
            ADiag = 7,
            Tie = 8,
            Cont = 9
        }

        #endregion

        #region Constructor/s

        /// <summary>
        /// Default Constructor for the TicTacToe class
        /// </summary>
        public TicTacToe()
        {
            GroupValues = new int[8];
            MovesMade = 0;
            CurrentPlayer = 1;
            Active = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Increment the corresponding win conditions depending on x and y coordinate in the grid.
        /// </summary>
        /// <param name="x">x coordinate of clicked square</param>
        /// <param name="y">y coordinate of clicked square</param>
        public void MakeMove(int x, int y)
        {
            //Make sure the current TicTacToe class is Active
            if (!Active)
                return;

            //Increment moves made
            MovesMade++;

            //Player 1 is given a value of 1 while Player 2 is given a value of -1
            int PlayerValue = CurrentPlayer == 1 ? 1 : -1;

            //Immediately add the players value to the x coordinate of the click
            GroupValues[x] = GroupValues[x] + PlayerValue;

            //Add the players value to the y coordinate of the click. The beginning of the y coordinate values is at index 3
            GroupValues[3 + y] = GroupValues[3 + y] + PlayerValue;

            //If the click happened in the middle square increment both diagonals
            if (x % 2 == 1 && y % 2 == 1)
            {
                GroupValues[6] = GroupValues[6] + PlayerValue;
                GroupValues[7] = GroupValues[7] + PlayerValue;
            }
            //If the click happened in the top left or bottom right square increment the diagonal
            else if ((x == 0 && y == 0) || (x == 2 && y == 2))
            {
                GroupValues[6] = GroupValues[6] + PlayerValue;
            }
            //If the click happened in the top right or bottom left square increment the anti diagonal
            else if ((x == 0 && y == 2) || (x == 2 && y == 0))
            {
                GroupValues[7] = GroupValues[7] + PlayerValue;
            }

        }

        /// <summary>
        /// Loop through the Win Condition array looking for a value of +-3
        /// Check for a Tie
        /// Return Continue if neither is found.
        /// </summary>
        /// <returns>A string representing the Win Condition that was met</returns>
        public string GameStatus()
        {
            for (int i = 0; i < GroupValues.Length; i++)
            {
                //If the current player is P1 then look for a 3 in the GroupValues Array if P2 then look for -3
                if (CurrentPlayer == 1 ? GroupValues[i] == 3 : GroupValues[i] == -3)
                {
                    //If a winning combo is found Deactivate the board set the winner property 
                    //to the current player and return the Win condition that was met
                    Active = false;
                    Winner = CurrentPlayer;
                    return ((GameGroups)i).ToString();
                }
            }
            if (MovesMade == 9)
            {
                Active = false;
                Winner = 3;
                return ((GameGroups)8).ToString();
            }
            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
            return ((GameGroups)9).ToString();
        }

        /// <summary>
        /// Getter function for the CurrentPlayer
        /// </summary>
        /// <returns>int value of CurrentPlayer</returns>
        public int GetCurrentPlayer()
        {
            return CurrentPlayer;
        }

        /// <summary>
        /// Getter function for the Active field
        /// </summary>
        /// <returns>boolean representing the active state of the board</returns>
        public bool IsActive()
        {
            return Active;
        }

        /// <summary>
        /// Getter function for the winner of the game
        /// </summary>
        /// <returns>integer representing P1, P2, or Tie</returns>
        public int GetWinner()
        {
            return Winner;
        }

        #endregion
    }
}
