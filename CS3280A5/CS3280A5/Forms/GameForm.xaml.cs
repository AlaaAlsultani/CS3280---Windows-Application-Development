using CS3280A5.Classes;
using CS3280A5.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CS3280A5
{
    /// <summary>
    /// Interaction logic for GameForm.xaml
    /// </summary>
    public partial class GameForm : Window
    {
        /// <summary>
        /// Game timer
        /// </summary>
        DispatcherTimer myTimer;
        /// <summary>
        /// Current Game object
        /// </summary>
        Game CurGame;
        /// <summary>
        /// Current Player object
        /// </summary>
        Player Player;
        /// <summary>
        /// Current Problem object
        /// </summary>
        Problem CurProblem;
        /// <summary>
        /// Current Game time
        /// </summary>
        int Time;
       
        //I was going to use these sounds for when the user got a correct or incorrect
        //answer but the volume is too loud.
        //SoundPlayer SuccessSound;
        //SoundPlayer FailureSound;

        /// <summary>
        /// Constructor for the Game Form
        /// </summary>
        /// <param name="g">Game type to be played</param>
        /// <param name="p">Player playing the game</param>
        public GameForm(Game g, Player p)
        {
            try
            {
                InitializeComponent();
                CurGame = g;
                Player = p;
                //SuccessSound = new SoundPlayer("../../Sounds/levelup.wav");
                //FailureSound = new SoundPlayer("../../Sounds/fuse.wav");
                //update the operator to match the game type being played
                ChangeOperator();
                //Update the numbers shown
                PopulateProblem();
                //Reset the timer
                Time = 0;
                //Set up the timer with a Tick event handler and a 1 second interval
                myTimer = new DispatcherTimer();
                myTimer.Tick += DispatchTimer_Tick;
                myTimer.Interval = new TimeSpan(0,0,1);
                //Start the timer
                myTimer.Start();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Generate a Problem of the Game Type and populate the UI
        /// </summary>
        public void PopulateProblem()
        {
            try
            {
                //Generate a new problem
                Problem p = CurGame.GenerateProblem();
                CurProblem = p;
                Num1Label.Content = p.GetNum1();
                Num2Label.Content = p.GetNum2();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Change the operator shown on the UI to match the Game's type
        /// </summary>
        public void ChangeOperator()
        {
            try
            {
                //Get the game type's symbol and change the operator accordingly
                switch (CurGame.GetOperator())
                {
                    case "-":
                        OperatorImage.Source = new BitmapImage(new Uri("../Images/MinusSign.png", UriKind.Relative));
                        break;
                    case "*":
                        OperatorImage.Source = new BitmapImage(new Uri("../Images/MultiplySign.png", UriKind.Relative));
                        break;
                    case "÷":
                        OperatorImage.Source = new BitmapImage(new Uri("../Images/DivideSign.png", UriKind.Relative));
                        break;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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

        /// <summary>
        /// OnClick handler for the Submit Answer Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private async void SubAnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //disable the answer button to prevent spam clicking
                AnswerInputBox.IsEnabled = false;
                SubAnswerBtn.IsEnabled = false;
                //Stop the timer
                myTimer.Stop();
                //Assume answer is false
                bool correct = false;
                //Check for an empty input
                if (AnswerInputBox.Text != "")
                {
                    //Check if the supplied answer is correct
                    correct = CurGame.CheckCorrectness(CurProblem, Int32.Parse(AnswerInputBox.Text));
                }
                //Update the score passing in current time and answer correctness
                CurGame.UpdateScore(Time, correct);
                //Update the progress bar by 1/10 of its total value
                RoundProgressBar.Value += 10;
                //Update the round number
                CurrentRoundLbl.Content = 10 - CurGame.RemRounds;
                await ShowResult(correct);
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handler for the timer tick event
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void DispatchTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //Increment the time
                Time++;
                //Update the UI timer
                TimerLbl.Content = Time;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Display the correctness of the user's supplied answer
        /// </summary>
        /// <param name="correct">Boolean representing correctness</param>
        private async Task ShowResult(bool correct)
        {
            try
            {
                //If answer is correct change it to green, else red
                AnswerInputBox.Foreground = correct ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                //Delay for 3 seconds before continuing
                await Task.Delay(3000);
                //Change the color back to white
                AnswerInputBox.Foreground = new SolidColorBrush(Colors.White);
                //Clear the answer box
                AnswerInputBox.Text = "";
                //Check to see if the game is over
                AnswerInputBox.IsEnabled = true;
                SubAnswerBtn.IsEnabled = true;
                AnswerInputBox.Focus();
                if (CurGame.RemRounds != 0)
                {
                    //Get a new problem
                    PopulateProblem();
                    //Restart the timer
                    myTimer.Start();
                }
                else
                {
                    //Display the results window
                    ResultsForm resultsForm = new ResultsForm(CurGame.Score, Player);
                    App.Current.MainWindow = resultsForm;
                    this.Close();
                    resultsForm.Show();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Event listener for the key up event on the answer input textbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private async void AnswerInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Check to see if the key pressed is enter
                if (e.Key != System.Windows.Input.Key.Enter || SubAnswerBtn.IsEnabled == false)
                return;

                AnswerInputBox.IsEnabled = false;
                SubAnswerBtn.IsEnabled = false;
                //Do the same as the button click handler above
                myTimer.Stop();
                bool correct = false;
                if (AnswerInputBox.Text != "")
                {
                    correct = CurGame.CheckCorrectness(CurProblem, Int32.Parse(AnswerInputBox.Text));
                }
                CurGame.UpdateScore(Time, correct);
                RoundProgressBar.Value += 10;
                CurrentRoundLbl.Content = 10 - CurGame.RemRounds;
                await ShowResult(correct);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Text Input event listener for the answer input Textbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void AnswerInputBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //Cast the sender to a Textbox
                TextBox textBox = (TextBox)sender;
                //Check for the input being a digit
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Click event handler for the main menu button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            //Display the Main Menu
            MainMenu mainMenu = new MainMenu(Player);
            App.Current.MainWindow = mainMenu;
            this.Close();
            mainMenu.Show();
        }
    }
}
