using CS3280A6.classes;
using CS3280A6.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Database Query object
        /// </summary>
        DBQuery DB;
        /// <summary>
        /// Logical representation of the Flight User Interface Labels
        /// </summary>
        Label[,] SeatLabelGrid;
        /// <summary>
        /// Add Passenger Window object
        /// </summary>
        wndAddPassenger wndAddPass;
        /// <summary>
        /// Bound list of flights
        /// </summary>
        BindingList<Flight> BoundFlight;
        /// <summary>
        /// Bound list of passengers
        /// </summary>
        BindingList<Passenger> BoundPassenger;
        /// <summary>
        /// Status representing if a new passenger is being added or seat being changed
        /// </summary>
        string Status;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                //Initialize the Status and SeatLabelGrid
                Status = "";
                SeatLabelGrid = new Label[6, 6];

                //Populate the SeatLabelgrid
                foreach (UIElement uie in FlightSeatGrid.Children)
                {
                    if (uie.Uid != "")
                    {
                        int x = Convert.ToInt32(uie.Uid.Substring(0, 1));
                        int y = Convert.ToInt32(uie.Uid.Substring(1, 1));
                        SeatLabelGrid[x, y] = (Label)uie;
                    }
                }

                //Iniatialze DB object and bind flight data
                DB = new DBQuery();
                BoundFlight = DB.SelectAllFlights();
                cbChooseFlight.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = BoundFlight });
                cbChooseFlight.DisplayMemberPath = "_FlightDetails";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnSelectionChanged Listener for the Choose Flight Combo Box.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Enable/Disable corresponding buttons
                populateButtonUI();

                //Change flight title to the newly selected flight number
                Flight_Title.Content = ((Flight)(cbChooseFlight.SelectedItem))._FlightNum;

                //Change the bound passengers 
                rebindPassengers();

                //Redraw the flight User Interface
                resetFlightUI();
                populateFlightUI();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick Listener for the Add Passenger button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show Add Passenger window
                wndAddPass = new wndAddPassenger(((Flight)(cbChooseFlight.SelectedItem))._Id);
                wndAddPass.ShowDialog();
                //Enable/Disable buttons
                resetButtonUI();
                //Rebind the passengers with the newly inserted passenger included
                rebindPassengers();
                //Set the currently selected index to be the last passenger added
                cbChoosePassenger.SelectedIndex = BoundPassenger.Count - 1;
                //Change the status to Adding Passenger
                Status = "Adding Passenger";
                //Show a message to the user
                FlightStatusTxt.Text = "Please select an empty seat(blue) for " + ((Passenger)(cbChoosePassenger.SelectedItem))._FullName + ".";
            }
            catch (Exception ex)
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
                List<Seat> bSeat = DB.SelectSeatInfoByFlight(((Flight)cbChooseFlight.SelectedItem)._Id);

                BrushConverter bc = new BrushConverter();
                //Set SeatArray at sX and sY to Green if available, red if taken, and if it is the currently selected passenger's seat then set it to blue
                foreach (Seat s in bSeat)
                {
                    SeatLabelGrid[s._X, s._Y].Background = (Brush)bc.ConvertFrom(s._Available ? "#FF0269FF" : "#FFFF3131");
                    SeatLabelGrid[s._X, s._Y].Content = s._Number;
                    if (!s._Available)
                    {
                        int pId = DB.SelectPassengerIdBySeatNumberAndFlight(s._Number, ((Flight)(cbChooseFlight.SelectedItem))._Id);
                        foreach(Passenger p in BoundPassenger)
                        {
                            if(p._Id == pId)
                            {
                                SeatLabelGrid[s._X, s._Y].DataContext = p;
                                break;
                            }
                        }
                    }

                    if (lblPassengersSeatNumber.Content.ToString() != "" && s._Number == Convert.ToInt32(lblPassengersSeatNumber.Content.ToString()))
                        SeatLabelGrid[s._X, s._Y].Background = (Brush)bc.ConvertFrom("#FF53FF02");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
                        SeatLabelGrid[i, j].Background = new SolidColorBrush(Colors.Transparent);
                        SeatLabelGrid[i, j].Content = "";
                        SeatLabelGrid[i, j].DataContext = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Error Handler for the MainWindow
        /// </summary>
        /// <param name="sClass">Class in which error occured</param>
        /// <param name="sMethod">Method in which error occured</param>
        /// <param name="sMessage">Message thrown with error</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// OnSelectionChanged Listener for the Choose Passenger Combo Box
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Check to see if no passenger is selected
                if (cbChoosePassenger.SelectedIndex == -1)
                {
                    //empty the seat number label
                    lblPassengersSeatNumber.Content = "";
                    //reset and repopulate the button and flight UIs
                    populateButtonUI();
                    populateFlightUI();
                    return;
                }


                ComboBox myCombo = (ComboBox)sender;
                Passenger selectedItem = (Passenger)myCombo.SelectedItem;
                ComboBox flightCombo = cbChooseFlight;
                Flight selectedFlight = (Flight)flightCombo.SelectedItem;
                //Retrive the newly selected Passenger's seat number
                int seat = DB.SelectPassengerSeatNumberByFlight(selectedItem._Id, selectedFlight._Id);
                if (seat != -1)
                    lblPassengersSeatNumber.Content = seat.ToString();
                else
                    lblPassengersSeatNumber.Content = "";
                //Redraw the UI to reflect the change in passenger
                populateFlightUI();
                resetButtonUI();
                populateButtonUI();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnMouseDown Listener for the Labels in the Flight UI
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label myLabel = (Label)sender;
                //If the Seat is occupied and the Status does not signal a changing of a seat or new passenger then change combo box to the selected passenger
                if (myLabel.DataContext != null && Status == "")
                {
                    cbChoosePassenger.SelectedIndex = BoundPassenger.IndexOf((Passenger)(myLabel.DataContext));
                }
                //If the seat is empty and the status is changing or a new passenger
                else if (myLabel.DataContext == null && Status != "")
                {
                    int pId = ((Passenger)(cbChoosePassenger.SelectedItem))._Id;
                    //Update the passenger's seat to the clicked label's number
                    DB.UpdatePassengerSeatNumber(((Flight)(cbChooseFlight.SelectedItem))._Id, pId, Convert.ToInt32(myLabel.Content));
                    lblPassengersSeatNumber.Content = myLabel.Content;
                    FlightStatusTxt.Text = "";
                    Status = "";
                    resetButtonUI();
                    resetFlightUI();
                    populateButtonUI();
                    populateFlightUI();
                }
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables and Disables buttons depending on the status of the combo boxes and Status
        /// </summary>
        private void populateButtonUI()
        {
            try
            {
                cbChooseFlight.IsEnabled = true;
                if (cbChooseFlight.SelectedIndex != -1)
                {
                    cbChoosePassenger.IsEnabled = true;
                    cmdAddPassenger.IsEnabled = true;
                }
                if (cbChoosePassenger.SelectedIndex != -1)
                {
                    cmdChangeSeat.IsEnabled = true;
                    cmdDeletePassenger.IsEnabled = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Disables all buttons and comboboxes
        /// </summary>
        private void resetButtonUI()
        {
            try
            {
                cbChooseFlight.IsEnabled = false;
                cbChoosePassenger.IsEnabled = false;
                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
                cmdAddPassenger.IsEnabled = false;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// OnClick Listener for the Delete Passenger button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedIndex == -1)
                    return;

                //Get the FlightId, PassengerId, and SeatId
                int pId = ((Passenger)cbChoosePassenger.SelectedItem)._Id;
                int fId = ((Flight)cbChooseFlight.SelectedItem)._Id;
                int sId = (DB.SelectPassengerSeat(fId, pId))._Id;

                //Remove the passenger from the DB and set the seat to Available
                DB.RemovePassengerFromFlight(pId, fId, sId);
                rebindPassengers();

                //Reset the flight UI and button UI
                resetButtonUI();
                resetFlightUI();
                populateButtonUI();
                populateFlightUI();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick Listener for the Change Seat button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbChoosePassenger.SelectedIndex == -1)
                    return;

                //Disable buttons
                resetButtonUI();
                //Set the status and display text message
                Status = "Changing Seat";
                FlightStatusTxt.Text = "Please select a new seat for " + ((Passenger)cbChoosePassenger.SelectedItem)._FullName + ".";
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Look up the current list of passengers for a flight and rebind them
        /// </summary>
        private void rebindPassengers()
        {
            try
            {
                BoundPassenger = DB.SelectPassengersByFlight(((Flight)cbChooseFlight.SelectedItem)._Id);
                cbChoosePassenger.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = BoundPassenger });
                cbChoosePassenger.DisplayMemberPath = "_FullName";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
