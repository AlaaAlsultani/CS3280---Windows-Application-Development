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
using System.Windows.Shapes;

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Search Logic Object Declaration
        /// </summary>
        public clsSearchLogic SL;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="wndMain"></param>
        public wndSearch()
        {
            try
            {
                InitializeComponent();
                SL = new clsSearchLogic();
                InvoiceList.ItemsSource = SL.Invoices;
                InvoiceTotalCmb.ItemsSource = SL.Totals;
                InvoiceDateCmb.ItemsSource = SL.Dates;
                InvoiceNumCmb.ItemsSource = SL.Numbers;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// SelectionChanged handler for the Invoice ComboBox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void InvoiceCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //If the box is being reset just return
                if (((ComboBox)sender).SelectedIndex == -1)
                    return;

                if (!ClearFilterBtn.IsEnabled)
                    ClearFilterBtn.IsEnabled = true;

                //Retrieve the new list of filtered invoices
                SL.PopulateFilteredInvoices(InvoiceNumCmb, InvoiceDateCmb, InvoiceTotalCmb);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the ClearFilter Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void ClearFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Reset t he combo boxes and disable the filter button
                ClearFilterBtn.IsEnabled = false;
                InvoiceDateCmb.SelectedIndex = -1;
                InvoiceNumCmb.SelectedIndex = -1;
                InvoiceTotalCmb.SelectedValue = -1;

                //Retrieve the full list of invoices
                SL.ResetInvoices();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the SelectInvoice Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void SelectInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Set the selected Invoice to the SelectedItem in the InvoiceList and close the dialog
                SL.SelectedInvoice = (Invoice)InvoiceList.SelectedItem;
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// OnClick handler for the Cancel Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// SelectionChanged handler for the InvoiceList DataGrid
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void InvoiceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectInvoiceBtn.IsEnabled = ((DataGrid)sender).SelectedIndex != -1;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Error Handler for the SearchWindow
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
