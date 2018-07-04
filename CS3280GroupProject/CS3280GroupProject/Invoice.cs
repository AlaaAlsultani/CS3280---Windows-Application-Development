using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject
{
    /// <summary>
    /// Invoice Model Class
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Invoice's Number
        /// </summary>
        private int Num;
        
        /// <summary>
        /// Invoice's Date
        /// </summary>
        private String Date;
        
        /// <summary>
        /// Invoice's Items
        /// </summary>
        private ObservableCollection<Item> Items;

        /// <summary>
        /// Getter/Setter for the Invoice Number
        /// </summary>
        public int _Num
        {
            get
            {
                return this.Num;
            }
            set
            {
                this.Num = value;
            }
        }
         
        /// <summary>
        /// Getter/Setter for the Invoice Number
        /// </summary>
        public String _Date
        {
            get
            {
                return this.Date;
            }
            set
            {
                this.Date = value;
            }
        }

        /// <summary>
        /// Getter/Setter for the Invoice Total
        /// </summary>
        public int _Total
        {
            get
            {
                int total = 0;
                foreach(Item i in Items)
                {
                    total += i._Cost;
                }

                return total;
            }
        }

        /// <summary>
        /// Getter/Setter for the Invoice Items
        /// </summary>
        public ObservableCollection<Item> _Items
        {
            get
            {
                return this.Items;
            }
            set
            {
                this.Items = value;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Invoice() {
            this.Items = new ObservableCollection<Item>();
        }

        /// <summary>
        /// Constructor with Invoice Number and Date
        /// </summary>
        /// <param name="num">Invoice Number</param>
        /// <param name="date">Invoice Date</param>
        public Invoice(int num, String date)
        {
            this.Num = num;
            this.Date = date;
            this.Items = new ObservableCollection<Item>();
        }
    }
}
