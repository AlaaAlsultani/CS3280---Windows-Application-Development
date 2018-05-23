using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS3280A4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Attributes
        /// <summary>
        /// Class representing the logical version of the TicTacToe board
        /// </summary>
        private TicTacToe MyBoard;
        /// <summary>
        /// 3x3 array containing the references to the label components on the visual TicTacToe board
        /// </summary>
        private Label[,] MyLabels;

        #endregion

        /// <summary>
        /// Constructor for the WPF Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MyLabels = new Label[3, 3] { { Label00, Label10, Label20 }, { Label01, Label11, Label21 }, { Label02, Label12, Label22 } };
            ActionBtn.Content = "Start Game";
        }

        #region Methods
        #region EventHandlers
        /// <summary>
        /// Click handler for all 9 tiles of the TicTacToe board.
        /// Checks necessary conditions and adds to the logical TicTacToe board.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event</param>
        private void TicTacTile_Click(object sender, MouseButtonEventArgs e)
        {
            //Check that the board has been initialized
            if (MyBoard == null)
                return;
            //Check that the current board is active
            if (!MyBoard.IsActive())
                return;

            //Get the element that was clicked
            Label myLabel = (Label)sender;

            //If the element has already been changed then return
            if (!myLabel.Content.Equals(""))
                return;

            //Store who the current player is
            int player = MyBoard.GetCurrentPlayer();

            //Make a move sending in x = first digit of Uid and y = second digit of Uid
            MyBoard.MakeMove(Int32.Parse(myLabel.Uid.Substring(0, 1)), Int32.Parse(myLabel.Uid.Substring(1, 1)));

            //Add a message about the move to the event tracking RichTextBox
            GameMessageBox.AppendText("Player " + player + " placed a " + (player == 1 ? "X" : "O") + " at position (" + 
               (Int32.Parse(myLabel.Uid.Substring(0, 1)) + 1) + ", " + (Int32.Parse(myLabel.Uid.Substring(1, 1)) + 1) + ")");

            //Keep the text box scrolled to the bottom
            GameMessageBox.ScrollToEnd();

            //X represents P1 and O represents P2
            myLabel.Content = player == 1 ? "X" : "O";

            //Change the Status message to display the other player
            StatusMessageLabel.Content = player == 1 ? "Player 2's Turn" : "Player 1's Turn";

            //Check for a win condition being met
            string status = MyBoard.GameStatus();

            //If no win condition then return
            if (status == "Cont")
                return;

            //Change the background color of the winning squares or all squares in case of tie
            PaintWinningTiles(status);

            //Increment the score in the ScoreTracker
            IncrementScore();

            //Set the text of the start button to be new game and enable it
            ActionBtn.Content = "New Game";
            ActionBtn.IsEnabled = true;
        }

        /// <summary>
        /// Click event for the main button used to start a new game
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event</param>
        private void ActionBtn_Click(object sender, RoutedEventArgs e)
        {
            Button myButton = (Button)sender;

            //Disable the start button
            myButton.IsEnabled = false;

            //Start up a new game
            MyBoard = new TicTacToe();

            //Reset the visual board
            ResetTiles();

            //Set the status message to Player 1's turn
            StatusMessageLabel.Content = "Player 1's Turn";

            //Clear out move history
            GameMessageBox.Document.Blocks.Clear();
        }

        #endregion

        /// <summary>
        /// Paint the tiles according to the passed in win condition
        /// </summary>
        /// <param name="status">String representing the win condition</param>
        private void PaintWinningTiles(string status)
        {
            //New Black Brush
            SolidColorBrush myBrush = new SolidColorBrush(System.Windows.Media.Colors.Black);
            
            //If the win condition was a row or column then loop through the tiles and paint them
            if (status != "Diag" && status != "ADiag"&& status != "Tie")
            {
                for (int i = 0; i < 3; i++)
                {
                    MyLabels[status.Substring(0, 3) == "Row" ? Int32.Parse(status.Substring(3, 1)) - 1
                        : i, status.Substring(0, 3) == "Row" ? i : Int32.Parse(status.Substring(3, 1)) - 1].Background = myBrush;
                }
            }
            //If the win condition was diag then paint the tiles with x and y coordinates that are the same
            else if (status == "Diag")
            {
                for (int i = 0; i < 3; i++)
                {
                    MyLabels[i, i].Background = myBrush;
                }
            }
            //If there was a tie then paint all of the tiles
            else if(status == "Tie")
            {
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        MyLabels[i, j].Background = myBrush;
                    }
                }
            }
            //If the win condition was the anti diagonal paint the corresponding tiles
            else
            {
                MyLabels[1, 1].Background = myBrush;
                MyLabels[2, 0].Background = myBrush;
                MyLabels[0, 2].Background = myBrush;
            }
        }

        /// <summary>
        /// Changes the backgrounds of the labels to be transparent and the content to be an empty string
        /// </summary>
        private void ResetTiles()
        {
            //New Transparent Brush
            SolidColorBrush myBrush = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
            //Loop through each tile emptying its content and making it trnasparent
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    MyLabels[i, j].Background = myBrush;
                    MyLabels[i, j].Content = "";
                }
            }
        }

        /// <summary>
        /// Increment the Score of the winner or increment the tie value
        /// </summary>
        private void IncrementScore()
        {
            //Find out who won
            int winner = MyBoard.GetWinner();
            //Increment the value of the winner/tie and add a new message to the Event Tracking RichTextBox
            switch (winner)
            {
                case 1:
                    P1WinLabel.Content = Int32.Parse(P1WinLabel.Content.ToString()) + 1;
                    StatusMessageLabel.Content = "Player 1 Won!";
                    break;
                case 2:
                    P2WinLabel.Content = Int32.Parse(P2WinLabel.Content.ToString()) + 1;
                    StatusMessageLabel.Content = "Player 2 Won!";
                    break;
                case 3:
                    TieCountLabel.Content = Int32.Parse(TieCountLabel.Content.ToString()) + 1;
                    StatusMessageLabel.Content = "Game Tie, No one Wins!";
                    break;
            }
        }

        #endregion
    }
}
