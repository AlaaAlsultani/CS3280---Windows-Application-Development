using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject
{
    /// <summary>
    /// Item Model Class
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Item's Code
        /// </summary>
        private char Code;

        /// <summary>
        /// Item's Description
        /// </summary>
        private String Desc;

        /// <summary>
        /// Item's Cost
        /// </summary>
        private int Cost;

        /// <summary>
        /// Getter/Setter for the Item's Code
        /// </summary>
        public char _Code
        {
            get
            {
                return this.Code;
            }
            set
            {
                this.Code = value;
            }
        }

        /// <summary>
        /// Getter/Setter for the Item's Description
        /// </summary>
        public String _Desc
        {
            get
            {
                return this.Desc;
            }
            set
            {
                this.Desc = value;
            }
        }

        /// <summary>
        /// Getter/Setter for the Item's Cost
        /// </summary>
        public int _Cost
        {
            get
            {
                return this.Cost;
            }
            set
            {
                this.Cost = value;
            }
        }
        
        /// <summary>
        /// Item constructor with Item Code, Description, and Cost
        /// </summary>
        /// <param name="code">Item's Code</param>
        /// <param name="desc">Item's Description</param>
        /// <param name="cost">Item's Cost</param>
        public Item(char code, String desc, int cost)
        {
            this.Code = code;
            this.Desc = desc;
            this.Cost = cost;
        }

    }
}
