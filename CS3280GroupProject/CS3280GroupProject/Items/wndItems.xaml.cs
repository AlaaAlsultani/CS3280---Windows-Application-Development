﻿using System;
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

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// Item Logic Object Declaration
        /// </summary>
        private clsItemsLogic IL;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();
                //Iniaialize ItemLogic object and set DataGrid's source
                IL = new clsItemsLogic();
                ItemDataGrid.ItemsSource = IL.Items;
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
                //When adding new Item enable the TextBoxes and make the save button visible
                AddItemBtn.IsEnabled = false;
                SaveItemBtn.Visibility = Visibility.Visible;
                ItemDataGrid.IsEnabled = false;
                ItemDataGrid.SelectedIndex = -1;
                ItemCodeBox.IsEnabled = true;
                ItemDescBox.IsEnabled = true;
                ItemCostBox.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// ONClick handler for the EditItem Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enable 2/3 textboxes excluding the item code, disable the datagrid, show the SaveItem button
                ItemDescBox.IsEnabled = true;
                ItemCostBox.IsEnabled = true;
                ItemDataGrid.IsEnabled = false;
                SaveItemBtn.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the DeleteItem Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>        
        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check for the Item on any invoices
                //If it exists then show the MessageBox
                string message = IL.CheckItemOnInvoice(ItemDataGrid.SelectedItem);
                if (message != "")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(message,
                "Delete Failed", System.Windows.MessageBoxButton.OK);
                }
                else
                {
                    //Delete the selected Item and set the SelectedIndex to -1
                    IL.DeleteItem(ItemDataGrid.SelectedItem);
                    ItemDataGrid.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// SelectionChanged handler for the ItemDataGrid
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ItemDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //If the selectedindex ever becomes -1 then disable the edit and delete options
                if (ItemDataGrid.SelectedIndex == -1)
                {
                    EditItemBtn.IsEnabled = false;
                    DeleteItemBtn.IsEnabled = false;
                    return;
                }

                //Enable the edit and delete buttons if not enabled
                if (!EditItemBtn.IsEnabled)
                    EditItemBtn.IsEnabled = true;

                if (!DeleteItemBtn.IsEnabled)
                    DeleteItemBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the SaveItem Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void SaveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check for empty input and alert the user
                if (ItemDescBox.Text == "" || ItemCostBox.Text == "" || ItemCodeBox.Text == "")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("The Item Code, Item Description, and Item Cost are all required.",
                "Missing Information", System.Windows.MessageBoxButton.OK);
                    return;
                }

                //Check to see if the SelectedIndex is -1 indicating whether they are saving a new Item or just updating an Item
                //Also check to see if either the cost or description was changed
                if (ItemDataGrid.SelectedIndex != -1 && (((Item)ItemDataGrid.SelectedItem)._Desc != ItemDescBox.Text || ((Item)ItemDataGrid.SelectedItem)._Cost != Convert.ToInt32(ItemCostBox.Text)))
                {
                        //Update the item
                        IL.UpdateItem(ItemDataGrid.SelectedItem, ItemDescBox.Text, ItemCostBox.Text);
                        //Remember the SelectedIndex
                        int index = ItemDataGrid.SelectedIndex;
                        //Refresh the list of Items to update the data grid with new values and reselect the updated Item
                        IL.RefreshItems();
                        ItemDataGrid.SelectedIndex = index;
                }
                else if(ItemDataGrid.SelectedIndex == -1)
                {
                    //Check that the code doesn't already exist
                    if (IL.CheckCodeValidity(ItemCodeBox.Text))
                    {
                        //Insert the new Item and return the inserted Item
                        Item insertedItem = IL.InsertNewItem(ItemCodeBox.Text, ItemDescBox.Text, ItemCostBox.Text);
                        ItemCodeBox.IsEnabled = false;
                        ItemDataGrid.SelectedItem = insertedItem;
                    }
                    else
                    {
                        //Display a MessageBox to the user saying the code already exists
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("That Item code already exists. Please enter a different one",
                    "Duplicate Code", System.Windows.MessageBoxButton.OK);
                        return;
                    }
                }
                //Disable, Enable, and Hide necessary elements
                ItemDescBox.IsEnabled = false;
                ItemCostBox.IsEnabled = false;
                SaveItemBtn.Visibility = Visibility.Hidden;
                AddItemBtn.IsEnabled = true;
                ItemDataGrid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// PreviewTextInput handler for the ItemCost textbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ItemCostBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = IL.IsNumericInput(e.Text);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Error Handler for the ItemsWindow
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
