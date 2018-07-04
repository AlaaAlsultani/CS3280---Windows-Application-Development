using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// Logic class for the Search Window
    /// </summary>
    public class clsSearchLogic
    {

        /// <summary>
        /// Private ObservableCollection of Invoices
        /// </summary>
        private ObservableCollection<Invoice> _Invoices;

        /// <summary>
        /// Private BindingList of Totals
        /// </summary>
        private BindingList<int> _Totals;

        /// <summary>
        /// Private BindingList of Dates
        /// </summary>
        private BindingList<string> _Dates;

        /// <summary>
        /// Private BindingList of Numbers
        /// </summary>
        private BindingList<int> _Numbers;

        /// <summary>
        /// Private Invoice holding the SelectedInvoice
        /// </summary>
        private Invoice _SelectedInvoice;

        /// <summary>
        /// Getter/Setter for the ObservableCollection of Invoices
        /// </summary>
        public ObservableCollection<Invoice> Invoices
        {
            get
            {
                return this._Invoices;
            }
            set
            {
                if (this._Invoices != value)
                {
                    this._Invoices = value;
                }
            }
        }

        /// <summary>
        /// Getter/Setter for the BindingList of Totals
        /// </summary>
        public BindingList<int> Totals
        {
            get
            {
                return this._Totals;
            }
            set
            {
                if(this._Totals != value)
                {
                    this._Totals = value;
                }
            }
        }

        /// <summary>
        /// Getter/Setter for the BindingList of Dates
        /// </summary>
        public BindingList<string> Dates
        {
            get
            {
                return this._Dates;
            }
            set
            {
                if(this._Dates != value)
                {
                    this._Dates = value;
                }
            }
        }

        /// <summary>
        /// Getter/Setter for the BindingList of Numbers
        /// </summary>
        public BindingList<int> Numbers
        {
            get
            {
                return this._Numbers;
            }
            set
            {
                if(this._Numbers != value)
                {
                    this._Numbers = value;
                }
            }
        }

        /// <summary>
        /// Search Sql Object Declaration
        /// </summary>
        public clsSearchSQL SQL;

        /// <summary>
        /// Getter/Setter for the SelectedInvoice
        /// </summary>
        public Invoice SelectedInvoice
        {
            get
            {
                return this._SelectedInvoice;
            }
            set
            {
                if(this._SelectedInvoice != value)
                {
                    this._SelectedInvoice = value;
                }
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsSearchLogic()
        {
            try
            {
                SQL = new clsSearchSQL();
                //Populate Collections for the DataGrid annd ComboBoxes
                Invoices = SQL.GetAllInvoices();
                Totals = SQL.GetUniqueTotals();
                Dates = SQL.GetUniqueDates();
                Numbers = SQL.GetInvoiceNumbers();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Populates the Collection for the DataGrid depending on input parameters
        /// </summary>
        /// <param name="InvoiceNum">Invoice Number to filter</param>
        /// <param name="InvoiceDate">Invoice Date to filter</param>
        /// <param name="InvoiceTotal">Invoice Total to filter</param>
        public void PopulateFilteredInvoices(object InvoiceNum, object InvoiceDate, object InvoiceTotal)
        {
            try
            {
                ComboBox InvoiceNumCmb = (ComboBox)InvoiceNum;
                ComboBox InvoiceDateCmb = (ComboBox)InvoiceDate;
                ComboBox InvoiceTotalCmb = (ComboBox)InvoiceTotal;

                _Invoices.Clear();
                foreach (Invoice i in SQL.GetFilteredInvoices(InvoiceNumCmb.SelectedIndex == -1 ? -1 : Convert.ToInt32(InvoiceNumCmb.SelectedItem),
                InvoiceDateCmb.SelectedIndex == -1 ? "" : InvoiceDateCmb.SelectedItem.ToString(),
                InvoiceTotalCmb.SelectedIndex == -1 ? -1 : Convert.ToInt32(InvoiceTotalCmb.SelectedItem)))
                {
                    _Invoices.Add(i);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Reset the list of Invoices 
        /// </summary>
        public void ResetInvoices()
        {
            try
            {
                _Invoices.Clear();
                foreach (Invoice i in SQL.GetAllInvoices())
                {
                    _Invoices.Add(i);
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
