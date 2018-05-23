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

namespace CS3280A5
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Player playing the game
        /// </summary>
        private Player p;

        /// <summary>
        /// Constructor for the Main Menu form
        /// </summary>
        /// <param name="p">Player playing the game</param>
        public MainMenu(Player p)
        {
            try
            {
                InitializeComponent();
                this.p = p;
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Click event handler for the change user button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ChangeUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Change to the UserInfo form
                UserInfoForm userInfoForm = new UserInfoForm();
                App.Current.MainWindow = userInfoForm;
                this.Close();
                userInfoForm.Show();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles errors thrown
        /// </summary>
        /// <param name="Class">Class in which the exception was thrown</param>
        /// <param name="Method">Method in which the exception was thrown</param>
        /// <param name="Message">Pathway the exception took</param>
        private void HandleError(string Class, string Method, string Message)
        {
            try
            {
                MessageBox.Show(Class + "." + Method + " -> " + Message);
            }
            catch (Exception ex)
            {
                //Write to error file here
            }
        }

        /// <summary>
        /// Click event handler for the operator buttons
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Cast sender to Button
                Button myButton = (Button)sender;
                //Initialise game to null
                Game g = null;

                //Create the new game corresponnding to the button clicked
                switch (myButton.Uid)
                {
                    case "Addition":
                        g = new AdditionGame(p);
                        break;
                    case "Subtraction":
                        g = new SubtractionGame(p);
                        break;
                    case "Multiplication":
                        g = new MultiplicationGame(p);
                        break;
                    case "Division":
                        g = new DivisionGame(p);
                        break;
                }

                if (g != null)
                {
                    //Start the game
                    GameForm gameForm = new GameForm(g, p);
                    App.Current.MainWindow = gameForm;
                    this.Close();
                    gameForm.Show();
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
