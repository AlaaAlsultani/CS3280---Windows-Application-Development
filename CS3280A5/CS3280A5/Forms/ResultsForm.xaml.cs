using CS3280A5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS3280A5.Forms
{
    /// <summary>
    /// Interaction logic for ResultsForm.xaml
    /// </summary>
    public partial class ResultsForm : Window
    {
        /// <summary>
        /// Player of the Game
        /// </summary>
        private Player Player;
        /// <summary>
        /// Score received by the Player
        /// </summary>
        private int Score;

        /// <summary>
        /// Constructor for the Results Form
        /// </summary>
        /// <param name="Score">Score received by the Player</param>
        /// <param name="p">Player of the Game</param>
        public ResultsForm(int Score, Player p)
        {
            try
            {
                InitializeComponent();
                this.Player = p;
                this.Score = Score;
                //Update the UI to reflect the passed in values
                populateScore();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Changes the UI elements to represent the Player's performance
        /// </summary>
        private void populateScore()
        {
            try
            {
                //Populate the messages with the username and score
                UserPerformanceLbl.Content = "Great Job " + Player.GetName() + "!";
                PointLbl.Content = "You Got " + Score + " Points";
                //Change the progress bar to reflect the score received
                ScoreProgressBar.Value = Score;
                //Change the opacity of the images depending on the Player's score
                if (Score >= 2450)
                    DiamondImage.Opacity = 100;
                if (Score >= 1900)
                    EmeraldImage.Opacity = 100;
                if (Score >= 1350)
                    GoldImage.Opacity = 100;
                if (Score >= 750)
                    IronImage.Opacity = 100;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Click event handler for the Main Menu Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Change to the Main Menu form
                MainMenu mainMenu = new MainMenu(Player);
                App.Current.MainWindow = mainMenu;
                this.Close();
                mainMenu.Show();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles exceptions thrown and displays the path the exception took.
        /// </summary>
        /// <param name="Class">Class in which the exception was thrown</param>
        /// <param name="Method">Method in which the exception was thrown</param>
        /// <param name="Message">Message of the pathway the exception took</param>
        private void HandleError(string Class, string Method, string Message)
        {
            try
            {
                MessageBox.Show(Class + "." + Method + " -> " + Message);
            }
            catch (Exception ex)
            {
                //Write to a file here
            }
        }
    }
}
