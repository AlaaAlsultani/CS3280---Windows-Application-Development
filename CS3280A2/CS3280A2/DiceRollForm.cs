using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3280A2
{
    public partial class DiceRollForm : Form
    {
        #region Attributes
        /// <summary>
        /// Holds the number of tiems a number has been rolled.
        /// </summary>
        private int[] RollCounter;
        /// <summary>
        /// Holds the number of times a user has guessed a number.
        /// </summary>
        private int[] Guesses;
        /// <summary>
        /// Holds the count of wins and losses.
        /// </summary>
        private int[] WinRatio;
        /// <summary>
        /// Random number generator
        /// </summary>
        Random r;
        #endregion

        #region Constructor/s
        /// <summary>
        /// Constructor for the DiceRollForm partial class. Initializes arrays to be all 0.
        /// </summary>
        public DiceRollForm()
        {
            InitializeComponent();
            //Zero out arrays
            RollCounter = new int[6] {0, 0, 0, 0, 0, 0};
            Guesses = new int[6] {0, 0, 0, 0, 0, 0};
            WinRatio = new int[2] {0, 0};
            r = new Random();
            //Initialise displayed values.
            UpdateScreenValues();
        }

        #endregion

        #region Methods
        #region EventHandlers
        /// <summary>
        /// Generates a new random integer and compares it to the user's guess. 
        /// Increments the RollCounter, Guesses, and WinRatio values. Then updates the values in the form.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void RollButton_Click(object sender, EventArgs e)
        {
            //Generate random number from 1-6
            int roll = r.Next(6) + 1;
            //Holds the last randomly generated roll in for loop so the "rolling" simulation does not show the same # twice in a row
            int prev = 0;
            //Simulate rollinng of the dice
            for(int i = 0; i < 5; i++)
            {
                int value = r.Next(6) + 1;
                while(value == prev)
                {
                    value = r.Next(6) + 1;
                }
                DiceImage.Image = DetermineDiceImage(r.Next(6) + 1);
                DiceImage.Refresh();
                DiceImage.Visible = true;
                Thread.Sleep(500);
                prev = value;
            }
            DiceImage.Image = DetermineDiceImage(roll);
            DiceImage.Refresh();
            DiceImage.Visible = true;
            //Increment the number rolled by 1 as well as what the user guessed by 1
            RollCounter[roll - 1]++;
            Guesses[Convert.ToInt32(GuessEntry.Text) - 1]++;
            //If they won increment 0 by 1 else increment 1 by 1
            WinRatio[Convert.ToInt32(GuessEntry.Text) == roll ? 0 : 1]++;
            ResultsMessage.Text = Convert.ToInt32(GuessEntry.Text) == roll ? "You Win!" : "You Lost!";
            //Update the screen
            UpdateScreenValues();
        }

        /// <summary>
        /// Zeros out the Arrays as well as emptying out the messages that start out blank on the screen.
        /// Updates the current values on the screen.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Zero out arrays
            Array.Clear(RollCounter, 0, RollCounter.Length);
            Array.Clear(Guesses, 0, Guesses.Length);
            Array.Clear(WinRatio, 0, WinRatio.Length);
            //Clear out the various messages as well as the input box.
            GuessEntry.Text = "";
            ResultsMessage.Text = "";
            ErrorMessage.Text = "";
            //Reset the dice picture
            DiceImage.Image = Properties.Resources.die1;
            DiceImage.Refresh();
            DiceImage.Visible = true;
            //Call the method to empty the counters and statistics.
            UpdateScreenValues();
        }

        /// <summary>
        /// Checks to make sure the value that is being inputted is between 1 and 6.
        /// Changes the TextBox BackColor as well as showing an error message if input is invalid.
        /// Changes the TextBox properties back to normal and hides the error message if input is going from invalid to valid.
        /// Enables/Disables the "Roll" button depending on validity of input.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event Object</param>
        private void GuessEntry_Change(object sender, EventArgs e)
        {
            int value;
            //Try to change the input to an Int. Returns True if successful else False.
            bool result = Int32.TryParse(GuessEntry.Text, out value);
            //If entered guess is not blank
            if (GuessEntry.Text != "")
            {
                //If guess is between 1 and 6 then enable the roll button.
                RollButton.Enabled = value >= 1 && value <= 6;
                //If guess is between 1 and 6 reset the BackColor else change it to an error indicating color.
                GuessEntry.BackColor = result && (value >= 1 && value <= 6) ? SystemColors.Window : Color.LightCoral;
                //If guess is between 1 and 6 set the error message to be blank else display an error message.
                ErrorMessage.Text = result && (value >= 1 && value <= 6) ? "" : "Invalid Input.";
            }
            else
            {
                //If input is blank change components to their defaults.
                RollButton.Enabled = false;
                GuessEntry.BackColor = SystemColors.Window;
                ErrorMessage.Text = "";
            }
        }

        #endregion
        /// <summary>
        /// Changes the displayed values on the screen to reflect their values in memory.
        /// </summary>
        private void UpdateScreenValues()
        {
            //Set the values in the Results box to their values in memory.
            WinCount.Text = WinRatio[0].ToString();
            LossCount.Text = WinRatio[1].ToString();
            PlayedCount.Text = (WinRatio[0] + WinRatio[1]).ToString();
            //Reset the StatBox's Text.
            StatBox.Text = "";
            //Populate the Labels giving them a black color.
            string StatString = "FACE\tFREQUENCY\tPERCENT\tTIMES GUESSED\n";
            StatBox.SelectionColor = Color.Black;
            StatBox.AppendText(StatString);
            //Change the text to dark gray.
            StatBox.SelectionColor = Color.DarkGray;
            //Loop through each face calculating the data and appending it to the StatBox
            for(int i = 0; i < 6; i++)
            {
                StatBox.AppendText("  " + (i + 1) + "\t          ");
                StatBox.AppendText(RollCounter[i].ToString() + "\t   ");
                StatBox.AppendText((WinRatio[0] + WinRatio[1] == 0 ? 
                    "0.00" : Math.Round(((double)RollCounter[i] / (WinRatio[0] + WinRatio[1])), 2).ToString("0.00")) + "%\t\t  ");
                StatBox.AppendText(Guesses[i].ToString() + "\n");
            }
        }

        /// <summary>
        /// Returns the Image corresponding to the die roll.
        /// </summary>
        /// <param name="roll">Number that was rolled</param>
        /// <returns>Bitmap of the image</returns>
        private System.Drawing.Bitmap DetermineDiceImage(int roll)
        {
            switch (roll)
            {
                case 2:
                    return Properties.Resources.die2;
                case 3:
                    return Properties.Resources.die3;
                case 4:
                    return Properties.Resources.die4;
                case 5:
                    return Properties.Resources.die5;
                case 6:
                    return Properties.Resources.die6;
                default:
                    return Properties.Resources.die1;
            }
        }

        #endregion

    }
}
