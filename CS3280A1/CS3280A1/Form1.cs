using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3280A1
{
    /// <summary>
    /// Partial class for the form Form1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor for Form1
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnClick handler for button1
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Result;

            Result = MessageBox.Show("You typed: " + textBox3.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            label1.Text = "You clicked the " + Result.ToString() + " button";
        }

        /// <summary>
        /// OnClick handler for button2
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Result;

            Result = MessageBox.Show("You typed: " + textBox2.Text, "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

            label1.Text = "You clicked the " + Result.ToString() + " button";
        }

        /// <summary>
        /// OnClick handler for button3
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Result;

            Result = MessageBox.Show("You typed: " + textBox1.Text, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            label1.Text = "You clicked the " + Result.ToString() + " button";
        }
    }
}
