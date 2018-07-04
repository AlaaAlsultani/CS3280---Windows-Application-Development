using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS3280GroupProject.Main
{
    /// <summary>
    /// Logic class for the Main Window
    /// </summary>
    class clsMainLogic
    {
        /// <summary>
        /// Main Sql Object Declaration
        /// </summary>
        private clsMainSQL SQL;

        /// <summary>
        /// Private Observable Collection of Items
        /// </summary>
        private ObservableCollection<Item> _Items;

        /// <summary>
        /// Private Invoice Currently Selected
        /// </summary>
        private Invoice _CurrentInvoice;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                SQL = new clsMainSQL();
                _Items = SQL.GetAllItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Getter/Setter for the Items Collection
        /// </summary>
        public ObservableCollection<Item> Items
        {
            get
            {
                return this._Items; 
            }
            set
            {
                this._Items = value;
            }
        }

        /// <summary>
        /// Getter/Setter for the CurrentInvoice
        /// </summary>
        public Invoice CurrentInvoice
        {
            get
            {
                return this._CurrentInvoice;
            }
            set
            {
                this._CurrentInvoice = value;
            }
        }

        /// <summary>
        /// Creates a new invoice
        /// </summary>
        public void CreateNewInvoice()
        {
            try
            {
                //Set CurrentInvoice to a new invoice
                _CurrentInvoice = new Invoice();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete the Current Invoice
        /// </summary>
        public void DeleteInvoice()
        {
            try
            {
                SQL.DeleteInvoice(_CurrentInvoice);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Check if a string is numeric
        /// </summary>
        /// <param name="InputText">string to check</param>
        /// <returns>boolean representing whether the string is a number</returns>
        public bool IsNumericInput(string InputText)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                return regex.IsMatch(InputText);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add an item to the current invoice
        /// </summary>
        /// <param name="SelectedItem">Item to add</param>
        /// <param name="Quantity">Number of the item to add</param>
        public void AddItem(object SelectedItem, string Quantity)
        {
            try
            {
                //Loop Quantity # of times adding a new SelectedItem to the CurrentInvoice each time
                Item selectedItem = ((Item)SelectedItem);
                for (int i = 0; i < Convert.ToInt32(Quantity); i++)
                {
                    CurrentInvoice._Items.Add(new Item(selectedItem._Code, selectedItem._Desc, selectedItem._Cost));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Save/Update the Current Invoice
        /// </summary>
        /// <param name="Date"></param>
        public void SaveInvoice(string Date)
        {
            try
            {
                //If they didnt specify a date get the current one
                if (Date == "")
                {
                    CurrentInvoice._Date = DateTime.Now.ToString();
                    Date = CurrentInvoice._Date;
                }
                else
                {
                    CurrentInvoice._Date = Date;
                }
                //If the CurrentInvoice is assigned a number(is in DB)
                if (_CurrentInvoice._Num != 0)
                {
                    //If they changed the date update it
                    if (CurrentInvoice._Date != Date)
                    {
                        SQL.UpdateInvoiceDate(CurrentInvoice);
                    }
                    //Update the invoice's items
                    SQL.UpdateInvoiceItems(CurrentInvoice);
                }
                else
                {
                    //Add the invoice and retrieve the number
                    int invoiceNum = SQL.InsertNewInvoice(_CurrentInvoice);
                    CurrentInvoice._Num = invoiceNum;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Determines the new total given an item and a current total
        /// </summary>
        /// <param name="Current">current total</param>
        /// <param name="SelectedItem">selected item</param>
        /// <returns>The result of subtraction of the selected item from the current total</returns>
        public int DetermineTotal(string Current, object SelectedItem)
        {
            try
            {
                return Convert.ToInt32(Current) - Convert.ToInt32(((Item)SelectedItem)._Cost);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes an Item from the CurrentInvoice
        /// </summary>
        /// <param name="Item">Item to remove</param>
        public void RemoveItem(object Item)
        {
            try
            {
                CurrentInvoice._Items.Remove((Item)Item);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the Collection of Items
        /// </summary>
        public void RefreshItems()
        {
            try
            {
                _Items.Clear();
                foreach (Item i in SQL.GetAllItems())
                {
                    _Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the CurrentInvoice
        /// </summary>
        public void RefreshSelectedInvoice()
        {
            _CurrentInvoice._Items.Clear();
            foreach(Item i in SQL.GetItemsByInvoiceId(_CurrentInvoice._Num))
            {
                _CurrentInvoice._Items.Add(i);
            }
        }
    }
}
