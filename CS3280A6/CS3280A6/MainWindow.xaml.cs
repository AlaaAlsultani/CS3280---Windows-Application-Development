using CS3280A6.classes;
using CS3280A6.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS3280A6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Object containing DB Queries
        /// </summary>
        DBQuery DB;

        /// <summary>
        /// Multi-dimensional array of Labels from the UI
        /// </summary>
        Label[,] SeatArray;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //Instantiate Label array
                SeatArray = new Label[6, 6];

                //Populate SeatArray with Labels from UI
                foreach (UIElement uie in FlightSeatGrid.Children)
                {
                    if (uie.Uid != "")
                    {
                        int x = Convert.ToInt32(uie.Uid.Substring(0, 1));
                        int y = Convert.ToInt32(uie.Uid.Substring(1, 1));
                        SeatArray[x, y] = (Label)uie;
                    }
                }

                //Initialize DB Query object
                DB = new DBQuery();

                //Retrieve all flights and bind them to the combo box
                BindingList<Flight> bFlight = DB.SelectAllFlights();
                FlightComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = bFlight });
                FlightComboBox.DisplayMemberPath = "_FlightDetails";
                FlightNameLbl.Content = ((Flight)(FlightComboBox.SelectedItem))._FlightNum;
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Populates the background colors and text of the Labels in the SeatArray
        /// </summary>
        private void populateFlightUI()
        {
            try
            {
                //Retrieve all Seats for a Flight
                List<Seat> bSeat = DB.SelectSeatInfoByFlight(((Flight)FlightComboBox.SelectedItem)._Id);

                BrushConverter bc = new BrushConverter();
                //Set SeatArray at sX and sY to Green if available, red if taken, and if it is the currently selected passenger's seat then set it to blue
                foreach (Seat s in bSeat)
                {
                    SeatArray[s._X, s._Y].Background = (Brush)bc.ConvertFrom(s._Available ? "#FF53FF02" : "#FFFF3131");
                    SeatArray[s._X, s._Y].Content = s._Number;
                    if (PassengerSeatBox.Text != "" && s._Number == Convert.ToInt32(PassengerSeatBox.Text))
                        SeatArray[s._X, s._Y].Background = (Brush)bc.ConvertFrom("#FF0269FF");
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Sets the background colors of the UI to transparent and empties the text
        /// </summary>
        private void resetFlightUI()
        {
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        SeatArray[i, j].Background = new SolidColorBrush(Colors.Transparent);
                        SeatArray[i, j].Content = "";
                    }
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnChange handler for the FlightComboBox. Changes the UI and PassengerComboBox binding
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void FlightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (FlightComboBox.SelectedIndex == -1)
                {
                    return;
                }

                ComboBox myCombo = (ComboBox)sender;
                Flight selectedItem = (Flight)myCombo.SelectedItem;

                FlightNameLbl.Content = selectedItem._FlightNum;

                //Retrieve all Passengers associated with the Flight
                BindingList<Passenger> bPassenger = DB.SelectPassengersByFlight(selectedItem._Id);
                PassengerComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = bPassenger });
                PassengerComboBox.DisplayMemberPath = "_FullName";
                PassengerComboBox.SelectedIndex = -1;

                //Reset and Repopulate the UI
                resetFlightUI();
                populateFlightUI();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnChange handler for the PassengerComboBox. Changes the seat number in the PassengerSeatBox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void PassengerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PassengerComboBox.SelectedIndex == -1)
                {
                    PassengerSeatBox.Text = "";
                    return;
                }


                ComboBox myCombo = (ComboBox)sender;
                Passenger selectedItem = (Passenger)myCombo.SelectedItem;
                ComboBox flightCombo = FlightComboBox;
                Flight selectedFlight = (Flight)flightCombo.SelectedItem;
                //Retrive the newly selected Passenger's seat number
                int seat = DB.SelectPassengerSeatNumberByFlight(selectedItem._Id, selectedFlight._Id);
                PassengerSeatBox.Text = seat.ToString();
                //Redraw the UI to reflect the change in passenger
                populateFlightUI();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the AddPassenger button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void AddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show an add passenger dialog
                AddPassengerWindow addPWindow = new AddPassengerWindow();
                addPWindow.ShowDialog();
            }
            catch(Exception ex)
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
    }
}
