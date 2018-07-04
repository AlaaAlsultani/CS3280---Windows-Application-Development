using CS3280A6.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// SQL class for the Search Window
    /// </summary>
    public class clsSearchSQL
    {
        /// <summary>
        /// DataAccess Object Declaration
        /// </summary>
        DataAccess DA;

        /// <summary>
        /// DataSet Object Declaration
        /// </summary>
        DataSet ds;

        /// <summary>
        /// OleDbCommand Object Declaration
        /// </summary>
        OleDbCommand cmd;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsSearchSQL()
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
        /// Get all Invoices
        /// </summary>
        /// <returns>An ObservableCollection of Invoices</returns>
        public ObservableCollection<Invoice> GetAllInvoices()
        {
            try
            {
                ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();
                cmd = new OleDbCommand("SELECT I.InvoiceNum, I.InvoiceDate, LI.ItemCode, ID.ItemDesc, ID.Cost FROM((Invoices I INNER JOIN LineItems LI ON I.InvoiceNum = LI.InvoiceNum) INNER JOIN ItemDesc ID ON ID.ItemCode = LI.ItemCode) ORDER BY I.InvoiceNum");


                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                int invoiceNum = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr[0]) != invoiceNum)
                    {
                        invoices.Add(new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString()));
                        invoiceNum = Convert.ToInt32(dr[0]);
                    }

                    invoices[invoices.Count - 1]._Items.Add(new Item(Convert.ToChar(dr[2]), dr[3].ToString(), Convert.ToInt32(dr[4])));
                }

                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get unique Invoice totals
        /// </summary>
        /// <returns>A BindingList of unique totals</returns>
        public BindingList<int> GetUniqueTotals()
        {
            try
            {
                BindingList<int> totals = new BindingList<int>();
                cmd = new OleDbCommand("SELECT DISTINCT SUM(ID.Cost) AS Total FROM(ItemDesc ID INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode) GROUP BY LI.InvoiceNum");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    totals.Add(Convert.ToInt32(dr[0]));
                }

                return totals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a unique list of Invoice Dates
        /// </summary>
        /// <returns>A BindingList of unique dates</returns>
        public BindingList<String> GetUniqueDates()
        {
            try
            {
                BindingList<String> dates = new BindingList<String>();
                cmd = new OleDbCommand("SELECT DISTINCT InvoiceDate FROM Invoices");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dates.Add(dr[0].ToString());
                }

                return dates;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a list of Invoice Numbers
        /// </summary>
        /// <returns>A BindingList of Invoice Numbers</returns>
        public BindingList<int> GetInvoiceNumbers()
        {
            try
            {
                BindingList<int> numbers = new BindingList<int>();
                cmd = new OleDbCommand("SELECT InvoiceNum FROM Invoices");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    numbers.Add(Convert.ToInt32(dr[0]));
                }

                return numbers;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a filtered list of Invoices
        /// </summary>
        /// <param name="InvoiceNum">Invoice's Number</param>
        /// <param name="InvoiceDate">Invoice's Date</param>
        /// <param name="InvoiceTotal">Invoice's Total</param>
        /// <returns>An ObservableCollection of Invoices</returns>
        public ObservableCollection<Invoice> GetFilteredInvoices(int InvoiceNum, String InvoiceDate, int InvoiceTotal)
        {
            try
            {
                ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();
                cmd = new OleDbCommand("SELECT * FROM (SELECT LI.InvoiceNum, I.InvoiceDate, SUM(ID.Cost) AS Total FROM((ItemDesc ID INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode) INNER JOIN Invoices I ON I.InvoiceNum = LI.InvoiceNum) ");
                //If more than 2 of InvoiceNum/Date/Total are provided
                if ((InvoiceNum == -1 ? -1 : 1) + (InvoiceDate == "" ? -1 : 1) + (InvoiceTotal == -1 ? -1 : 1) > -1)
                {
                    cmd.CommandText += "WHERE ";
                    //If Invoice Number is provided
                    if (InvoiceNum != -1)
                    {
                        cmd.CommandText += "LI.InvoiceNum = " + InvoiceNum;
                        //If Date is specified as well add it on
                        if (InvoiceDate != "")
                        {
                            cmd.CommandText += " AND I.InvoiceDate = @InvoiceDate";
                            cmd.Parameters.Add("@InvoiceDate", OleDbType.Date).Value = InvoiceDate;
                        }
                    }
                    //If Date is provided but not Number
                    else if (InvoiceDate != "")
                    {
                        cmd.CommandText += "I.InvoiceDate = @InvoiceDate";
                        cmd.Parameters.Add("@InvoiceDate", OleDbType.Date).Value = InvoiceDate;
                    }
                }
                else
                {
                    if (InvoiceNum != -1)
                        cmd.CommandText += "WHERE LI.InvoiceNum = " + InvoiceNum;
                    else if (InvoiceDate != "")
                    {
                        cmd.CommandText += "WHERE I.InvoiceDate = @InvoiceDate";
                        cmd.Parameters.Add("@InvoiceDate", OleDbType.Date).Value = InvoiceDate;
                    }
                }

                cmd.CommandText += " GROUP BY LI.InvoiceNum, I.InvoiceDate";

                //If Invoice Total is provided then add it to the outer WHERE clause, else just close the parenthesis
                cmd.CommandText += InvoiceTotal != -1 ? ") WHERE Total = " + InvoiceTotal : ")";

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                int invoiceNum = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(dr[0]) != invoiceNum)
                    {
                        invoices.Add(new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString()));
                        invoiceNum = Convert.ToInt32(dr[0]);
                    }

                    cmd = new OleDbCommand("SELECT LI.ItemCode, ID.ItemDesc, ID.Cost FROM ItemDesc ID INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode WHERE LI.InvoiceNum = @InvoiceNum");
                    cmd.Parameters.Add("@InvoiceNNum", OleDbType.Integer).Value = Convert.ToInt32(dr[0]);

                    int iRetVal = 0;

                    //Retrieve each of the Invoice's Items
                    DataSet itemDataSet = DA.ExecuteSQLStatement(cmd, ref iRetVal);
                    foreach (DataRow idr in itemDataSet.Tables[0].Rows)
                    {
                        invoices[invoices.Count - 1]._Items.Add(new Item(Convert.ToChar(idr[0]), idr[1].ToString(), Convert.ToInt32(idr[2])));
                    }
                }

                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
