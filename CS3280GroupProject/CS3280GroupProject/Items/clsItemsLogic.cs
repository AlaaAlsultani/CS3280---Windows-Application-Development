﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// Logic class for the Items Window
    /// </summary>
    public class clsItemsLogic
    {
        /// <summary>
        /// Items Sql Object Declaration
        /// </summary>
        private clsItemsSQL SQL;

        /// <summary>
        /// Private Items Observable Collection Declaration
        /// </summary>
        private ObservableCollection<Item> _Items;

        /// <summary>
        /// Public getter/setter for the _Items collection
        /// </summary>
        public ObservableCollection<Item> Items
        {
            get
            {
                return this._Items;
            }
            set
            {
                if (value != this._Items)
                    this._Items = value;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                SQL = new clsItemsSQL();
                //Initialize the items collection to all the items
                _Items = SQL.GetAllItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checking the uniqueness of the Item Code
        /// </summary>
        /// <param name="Code">Item's Code</param>
        /// <returns>boolean representing uniqueness</returns>
        public bool CheckCodeValidity(string Code)
        {
            try
            {
                return SQL.CheckUniqueCode(Code);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new Item into the DB
        /// </summary>
        /// <param name="Code">Item's Code</param>
        /// <param name="Desc">Item's Description</param>
        /// <param name="Cost">Item's Cost</param>
        /// <returns>The inserted Item</returns>
        public Item InsertNewItem(string Code, string Desc, string Cost)
        {
            try
            {
                SQL.InsertNewItem(Code, Desc, Cost);
                Item newItem = new Item(Convert.ToChar(Code), Desc, Convert.ToInt32(Cost));
                //Position the newItem at the correct position in the list depending on Code
                for (int i = 0; i < _Items.Count - 1; i++)
                {
                    if (_Items.ElementAt(i)._Code < newItem._Code && _Items.ElementAt(i + 1)._Code > newItem._Code)
                    {
                        _Items.Insert(i + 1, newItem);
                        return newItem;
                    }
                }
                _Items.Add(newItem);

                return newItem;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the provided Item
        /// </summary>
        /// <param name="SelectedItem">Item To Delete</param>
        public void DeleteItem(object SelectedItem)
        {
            try
            {
                SQL.DeleteItem(((Item)SelectedItem)._Code.ToString());
                _Items.Remove((Item)SelectedItem);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update provided item
        /// </summary>
        /// <param name="SelectedItem">Item to be updated</param>
        /// <param name="Desc">Item's Description</param>
        /// <param name="Cost">Item's Cost</param>
        public void UpdateItem(object SelectedItem, string Desc, string Cost)
        {
            try
            {
                //If the Description or Cost is not changed pass in null
                SQL.UpdateItem(((Item)SelectedItem)._Code, ((Item)SelectedItem)._Desc != Desc ? Desc : null, ((Item)SelectedItem)._Cost.ToString() != Cost ? Cost : null);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the items in the Item Collection
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
        /// Checks that the provided text is a number
        /// </summary>
        /// <param name="InputText">string to be checked</param>
        /// <returns>boolean representing if the text is numeric</returns>
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
        /// Checks whether the item is included in an invoice
        /// </summary>
        /// <param name="SelectedItem">Item to check for</param>
        /// <returns>string of Invoices the item is included in</returns>
        public string CheckItemOnInvoice(object SelectedItem)
        {
            try
            {
                List<int> invoices = SQL.CheckItemOnInvoice((Item)SelectedItem);

                if (invoices.Count == 0)
                    return "";

                string message = "That item exists on the following invoices and cannot be deleted: \n\n";
                foreach(int i in invoices)
                {
                    message += "\t" + i + "\n";
                }

                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
