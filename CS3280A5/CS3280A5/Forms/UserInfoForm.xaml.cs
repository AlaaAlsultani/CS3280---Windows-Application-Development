using CS3280A5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS3280A5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserInfoForm : Window
    {
        /// <summary>
        /// Default Constructor for the UserInfoForm
        /// </summary>
        public UserInfoForm()
        {
            InitializeComponent();
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
            catch(Exception ex)
            {
                //Write to error file here
            }
        }

        /// <summary>
        /// Click event handler for the Player Info Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void PlayerInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check for non-empty input
                if (AgeEntryBox.Text != "" && NameEntryBox.Text != "")
                {
                    //Create a new Player object
                    Player P = new Player(Int32.Parse(AgeEntryBox.Text), NameEntryBox.Text);
                    //Change to the Main Menu passing along the Player object
                    MainMenu mainMenu = new MainMenu(P);
                    App.Current.MainWindow = mainMenu;
                    this.Close();
                    mainMenu.Show();
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        //Contains no check for Username allowing for users to enter names that aren't their real life name
        /// <summary>
        /// Change event handler for the Age Entry Textbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void AgeEntry_Changed(object sender, TextCompositionEventArgs e)
        {
                try
                {
                    //Cast the sender to a Textbox
                    TextBox textBox = (TextBox)sender;
                    //Check for the input being a digit
                    e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
                }
                catch (Exception ex)
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
        }
    }
}
