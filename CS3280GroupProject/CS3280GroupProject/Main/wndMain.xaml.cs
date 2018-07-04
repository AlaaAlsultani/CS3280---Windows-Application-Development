using CS3280GroupProject.Items;
using CS3280GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CS3280GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {

        /// <summary>
        /// Main Logic Object Declaration
        /// </summary>
        private clsMainLogic ML;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                ML = new clsMainLogic();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler of the AddInvoice Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void AddInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Make the NewInvoice and InvoiceDetail grids visible
                InvoiceDetailGrid.Visibility = Visibility.Visible;
                NewInvoiceGrid.Visibility = Visibility.Visible;

                //Retrieve the active StackPanel style and apply it to the button stack panel
                Style st = (Style)this.FindResource("StackPanelActive");

                InvoiceBtnStack.Style = st;

                AddInvoiceBtn.IsEnabled = false;
                EditInvoiceBtn.IsEnabled = false;
                DeleteInvoiceBtn.IsEnabled = false;
                SaveInvoiceBtn.IsEnabled = false;
                ItemListMenu.IsEnabled = false;

                //Initialise ui elements
                ItemCmb.SelectedIndex = -1;
                QuantityBox.Text = "1";
                DateBox.Text = "";

                //Make sure the Item combobox is populated
                if (ItemCmb.ItemsSource == null)
                    ItemCmb.ItemsSource = ML.Items;

                //Create a new empty invoice
                ML.CreateNewInvoice();

                //Set up the itemsource for the listbox and initialise invoice # and total
                InvoiceNumLbl.Content = "TBD";
                ItemList.ItemsSource = ML.CurrentInvoice._Items;
                TotalLbl.Content = "0";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the EditInvoice Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void EditInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Toggle disabled status of various ui elements
                NewInvoiceGrid.Visibility = Visibility.Visible;
                ItemListMenu.IsEnabled = false;
                DateBox.IsEnabled = true;
                QuantityBox.IsEnabled = true;
                AddInvoiceBtn.IsEnabled = false;
                EditInvoiceBtn.IsEnabled = false;
                DeleteInvoiceBtn.IsEnabled = false;
                SaveInvoiceBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the DeleteInvoice Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void DeleteInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show a messagebox confirming deletion
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete Invoice #" + InvoiceNumLbl.Content + "?",
                    "Deletion Confirmation", System.Windows.MessageBoxButton.YesNo);
                //If they answered yes then delete the invoice and reset the ui to be the same as startup
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ML.DeleteInvoice();
                    Style st = (Style)this.FindResource("StackPanelInactive");

                    InvoiceBtnStack.Style = st;

                    InvoiceDetailGrid.Visibility = Visibility.Hidden;
                    NewInvoiceGrid.Visibility = Visibility.Hidden;
                    
                    ML.CurrentInvoice = null;
                    EditInvoiceBtn.IsEnabled = false;
                    DeleteInvoiceBtn.IsEnabled = false;
                    AddInvoiceBtn.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// PreviewTextInput handler for the Quantity textbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void QuantityBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = ML.IsNumericInput(e.Text);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// SelectionChanged handler for the Item ComboBox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ItemCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //if the selected index is -1 then toggle disabled status and reset the quantity
                if (((ComboBox)sender).SelectedIndex == -1)
                {
                    QuantityBox.IsEnabled = false;
                    AddItemBtn.IsEnabled = false;
                    QuantityBox.Text = "1";
                }
                else
                {
                    if (!QuantityBox.IsEnabled)
                        QuantityBox.IsEnabled = true;
                    if (!AddItemBtn.IsEnabled)
                        AddItemBtn.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the AddItem Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!SaveInvoiceBtn.IsEnabled)
                    SaveInvoiceBtn.IsEnabled = true;

                //Add the quantity of items to the Invoice's list
                ML.AddItem(ItemCmb.SelectedItem, QuantityBox.Text);
                //Reset quantity and update total
                QuantityBox.Text = "1";
                TotalLbl.Content = ML.CurrentInvoice._Total.ToString();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the SaveInvoice Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void SaveInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Saving the changed Invoice
                ML.SaveInvoice(DateBox.Text);

                //Toggling the disabled status of ui controls
                AddInvoiceBtn.IsEnabled = true;
                DeleteInvoiceBtn.IsEnabled = true;
                EditInvoiceBtn.IsEnabled = true;
                ItemListMenu.IsEnabled = true;
                ItemCmb.SelectedIndex = -1;

                DateBox.IsEnabled = false;
                //Update the DateBox to the Invoice's date in case of auto generated date
                DateBox.Text = ML.CurrentInvoice._Date;
                //Update the Invoice Number label with the number of the inserted Invoice
                InvoiceNumLbl.Content = ML.CurrentInvoice._Num;

                NewInvoiceGrid.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the RemoveItem Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //If they have nothing selected dont remove anything
                if (ItemList.SelectedIndex == -1)
                    return;

                //Refresh total and remove the item
                TotalLbl.Content = ML.DetermineTotal(TotalLbl.Content.ToString(), ItemList.SelectedItem);
                ML.RemoveItem(ItemList.SelectedItem);

                RemoveItemBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// SelectionChanged handler for the ItemList
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListBox ItemList = (ListBox)sender;
                RemoveItemBtn.IsEnabled = ItemList.SelectedIndex != -1;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// LostFocus handler for the Quantity TextBox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void QuantityBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //If they leave the quantity textbox empty after losing focus set it to 1
                if (QuantityBox.Text == "")
                    QuantityBox.Text = "1";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the MenuItem
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show the search window as a dialog
                wndSearch wndSearch = new wndSearch();
                wndSearch.ShowDialog();

                //If they hit cancel then just return
                if (wndSearch.SL.SelectedInvoice == null)
                    return;

                //Alter the stack panel to be styled as active
                Style st = (Style)this.FindResource("StackPanelActive");
                InvoiceBtnStack.Style = st;

                //Toggle disabled status of ui elements
                ItemListMenu.IsEnabled = true;

                if (DateBox.IsEnabled)
                    DateBox.IsEnabled = false;

                if (NewInvoiceGrid.Visibility == Visibility.Visible)
                    NewInvoiceGrid.Visibility = Visibility.Hidden;

                DeleteInvoiceBtn.IsEnabled = true;
                EditInvoiceBtn.IsEnabled = true;

                //Set the current invoice to be the selected invoice
                ML.CurrentInvoice = wndSearch.SL.SelectedInvoice;

                InvoiceDetailGrid.Visibility = Visibility.Visible;

                //If the item combobox's itemsource is not set, set it
                if (ItemCmb.ItemsSource == null)
                    ItemCmb.ItemsSource = ML.Items;

                //Set the itemsource for itemlist to be the selected invoice's items
                ItemList.ItemsSource = ML.CurrentInvoice._Items;

                //Set the labels to contain the selected invoice's information
                TotalLbl.Content = ML.CurrentInvoice._Total.ToString();
                InvoiceNumLbl.Content = ML.CurrentInvoice._Num;
                DateBox.Text = ML.CurrentInvoice._Date;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the ItemList MenuItem
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ItemListMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Show the item screen as a dialog
                wndItems wndItems = new wndItems();
                wndItems.ShowDialog();

                //After returning from the item screen refresh the items
                ML.RefreshItems();

                if (ML.CurrentInvoice != null)
                {
                    ML.RefreshSelectedInvoice();
                    TotalLbl.Content = ML.CurrentInvoice._Total;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
    }
}
