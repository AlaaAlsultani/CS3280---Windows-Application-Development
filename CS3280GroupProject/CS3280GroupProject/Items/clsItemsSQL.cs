using CS3280A6.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// SQL class for the Items window
    /// </summary>
    public class clsItemsSQL
    {
        /// <summary>
        /// DataAccess Object Declaration
        /// </summary>
        private DataAccess DA;

        /// <summary>
        /// DataSet Object Declaration
        /// </summary>
        private DataSet DS;

        /// <summary>
        /// OleDbCommand Object Declaration
        /// </summary>
        private OleDbCommand Cmd;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                DA = new DataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all Items 
        /// </summary>
        /// <returns>An ObservableCollection of all Items</returns>
        public ObservableCollection<Item> GetAllItems()
        {
            try
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();
                Cmd = new OleDbCommand("SELECT * FROM ItemDesc ORDER BY ItemCode ASC");

                int retVal = 0;

                DS = DA.ExecuteSQLStatement(Cmd, ref retVal);

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    items.Add(new Item(Convert.ToChar(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2])));
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if the provided Item Code does not exist
        /// </summary>
        /// <param name="Code">Item's Code</param>
        /// <returns>boolean representing uniqueness of the code</returns>
        public bool CheckUniqueCode(string Code)
        {
            try
            {
                Cmd = new OleDbCommand("SELECT ItemCode FROM ItemDesc WHERE ItemCode = @Code");
                Cmd.Parameters.Add("@Code", OleDbType.WChar).Value = Code;

                return DA.ExecuteScalarSQL(Cmd) == "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new Item
        /// </summary>
        /// <param name="Code">Item's Code</param>
        /// <param name="Desc">Item's Description</param>
        /// <param name="Cost">Item's Cost</param>
        public void InsertNewItem(string Code, string Desc, string Cost)
        {
            try
            {
                Cmd = new OleDbCommand("INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES (@Code, @Desc, @Cost)");
                Cmd.Parameters.Add("@Code", OleDbType.WChar).Value = Code;
                Cmd.Parameters.Add("@Desc", OleDbType.WChar).Value = Desc;
                Cmd.Parameters.Add("@Cost", OleDbType.Integer).Value = Cost;

                DA.ExecuteNonQuery(Cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes an Item 
        /// </summary>
        /// <param name="Code">Item to delete's code</param>
        public void DeleteItem(string Code)
        {
            try
            {
                Cmd = new OleDbCommand("DELETE FROM ItemDesc WHERE ItemCode = @Code");
                Cmd.Parameters.Add("@Code", OleDbType.WChar).Value = Code;

                DA.ExecuteNonQuery(Cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates an Item
        /// </summary>
        /// <param name="Code">Item's Code</param>
        /// <param name="Desc">Item's Description</param>
        /// <param name="Cost">Item's Cost</param>
        public void UpdateItem(char Code, string Desc, string Cost)
        {
            try
            {
                Cmd = new OleDbCommand("UPDATE ItemDesc SET ");

                //If a new description is provided then add it to the SET clause
                if (Desc != null)
                {
                    Cmd.CommandText += "ItemDesc = '" + Desc + "'";
                }
                if (Cost != null)
                {
                    //If a new cost is provided as well as desc then add a comma, otherwise just add cost to SET clause
                    if (Desc != null)
                    {
                        Cmd.CommandText += ", Cost = '" + Cost + "'";
                    }
                    else
                    {
                        Cmd.CommandText += "Cost = '" + Cost + "'";
                    }
                }
                Cmd.CommandText += " WHERE ItemCode = '" + Code + "'";

                DA.ExecuteNonQuery(Cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if an Item exists on any Invoice
        /// </summary>
        /// <param name="SelectedItem">Item to check for</param>
        /// <returns>A List of Invoice Numbers on which the Item exists</returns>
        public List<int> CheckItemOnInvoice(Item SelectedItem)
        {
            try
            {
                List<int> invoiceNums = new List<int>();
                Cmd = new OleDbCommand("SELECT DISTINCT InvoiceNum FROM LineItems WHERE ItemCode = @ItemCode");
                Cmd.Parameters.Add("@ItemCode", OleDbType.WChar).Value = SelectedItem._Code;

                int retVal = 0;

                DS = DA.ExecuteSQLStatement(Cmd, ref retVal);

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    invoiceNums.Add(Convert.ToInt32(dr[0]));
                }

                return invoiceNums;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
