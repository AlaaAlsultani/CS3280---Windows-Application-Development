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

namespace CS3280GroupProject.Main
{
    /// <summary>
    /// SQL Class for the Main Window
    /// </summary>
    class clsMainSQL
    {
        /// <summary>
        /// DataAccess Object Declaration
        /// </summary>
        DataAccess DA;
        
        /// <summary>
        /// OleDbCommand Object Declaration
        /// </summary>
        OleDbCommand cmd;

        /// <summary>
        /// DataSet Object Declaration
        /// </summary>
        DataSet ds;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainSQL()
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
        /// Retrieve all Items
        /// </summary>
        /// <returns>An ObservableCollection of all items</returns>
        public ObservableCollection<Item> GetAllItems()
        {
            try
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();

                cmd = new OleDbCommand("SELECT * FROM ItemDesc");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
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
        /// Get all items on an invoice
        /// </summary>
        /// <param name="InvoiceNum">Invoice's Number</param>
        /// <returns>An ObservableCollection of the Invoice's Items</returns>
        public ObservableCollection<Item> GetItemsByInvoiceId(int InvoiceNum)
        {
            try
            {
                ObservableCollection<Item> items = new ObservableCollection<Item>();

                cmd = new OleDbCommand("SELECT ID.ItemCode, ID.ItemDesc, ID.Cost FROM ItemDesc ID INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode WHERE LI.InvoiceNum = @InvoiceNum");
                cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = InvoiceNum;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
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
        /// Get an Invoice by its Number
        /// </summary>
        /// <param name="InvoiceNum">Invoice's Number</param>
        /// <returns>The Invoice with the provided Number</returns>
        public Invoice GetInvoiceById(int InvoiceNum)
        {
            try
            {
                cmd = new OleDbCommand("SELECT * FROM Invoices WHERE InvoiceNum = @InvoiceNum");
                cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = InvoiceNum;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    return new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                return new Invoice(4999, "12/12/12");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Insert a new Invoice
        /// </summary>
        /// <param name="NewInvoice">Invoice to insert</param>
        /// <returns>The inserted Invoice's Number</returns>
        public int InsertNewInvoice(Invoice NewInvoice)
        {
            try
            {
                cmd = new OleDbCommand("INSERT INTO Invoices(InvoiceDate) VALUES (@InvoiceDate)");
                cmd.Parameters.Add("@InvoiceDate", OleDbType.VarChar).Value = NewInvoice._Date;

                DA.ExecuteNonQuery(cmd);

                cmd = new OleDbCommand("SELECT TOP 1 InvoiceNum FROM Invoices ORDER BY InvoiceNum DESC");

                int retVal = 0;
                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                int invoiceNum = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                for (int i = 1; i <= NewInvoice._Items.Count; i++)
                {
                    cmd = new OleDbCommand("INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES (@InvoiceNum, @LineItemNum, @ItemCode)");
                    cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = invoiceNum;
                    cmd.Parameters.Add("@LineItemNum", OleDbType.Integer).Value = i;
                    cmd.Parameters.Add("@ItemCode", OleDbType.WChar).Value = NewInvoice._Items[i - 1]._Code;
                    DA.ExecuteNonQuery(cmd);
                }

                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete an Invoice
        /// </summary>
        /// <param name="Invoice">Invoice to delete</param>
        public void DeleteInvoice(Invoice Invoice)
        {
            try
            {
                cmd = new OleDbCommand("DELETE FROM LineItems WHERE InvoiceNum = @InvoiceNum");
                cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = Invoice._Num;
                DA.ExecuteNonQuery(cmd);

                cmd = new OleDbCommand("DELETE FROM Invoices WHERE InvoiceNum = @InvoiceNum");
                cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = Invoice._Num;
                DA.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates an Invoice's Date
        /// </summary>
        /// <param name="Invoice">Invoice's Date</param>
        public void UpdateInvoiceDate(Invoice Invoice)
        {
            try
            {
                cmd = new OleDbCommand("UPDATE Invoices SET InvoiceDate = " + Invoice._Date + " WHERE InvoiceNum = " + Invoice._Num);
                DA.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update an Invoice's Items
        /// </summary>
        /// <param name="Invoice">Updated Invoice</param>
        public void UpdateInvoiceItems(Invoice Invoice)
        {
            try
            {
                cmd = new OleDbCommand("DELETE FROM LineItems WHERE InvoiceNum = @InvoiceNum");
                cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = Invoice._Num;

                DA.ExecuteNonQuery(cmd);

                for (int i = 1; i <= Invoice._Items.Count; i++)
                {
                    cmd = new OleDbCommand("INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES (@InvoiceNum, @LineItemNum, @ItemCode)");
                    cmd.Parameters.Add("@InvoiceNum", OleDbType.Integer).Value = Invoice._Num;
                    cmd.Parameters.Add("@LineItemNum", OleDbType.Integer).Value = i;
                    cmd.Parameters.Add("@ItemCode", OleDbType.WChar).Value = Invoice._Items[i - 1]._Code;
                    DA.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
