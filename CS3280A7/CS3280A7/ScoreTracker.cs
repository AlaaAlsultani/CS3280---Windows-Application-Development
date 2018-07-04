using CS3280A7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3280A3
{
    /// <summary>
    /// Class for displaying a Student Score Tracking form.
    /// </summary>
    public partial class ScoreTracker : Form
    {

        #region Attributes
        /// <summary>
        /// String array to hold student names.
        /// </summary>
        string[] Students;
        /// <summary>
        /// int holding the current index into the array of students.
        /// </summary>
        int CurStudent;
        /// <summary>
        /// Multi-dimensional of ints to hold student scores.
        /// </summary>
        int[,] Scores;
        /// <summary>
        /// Object used to write to files
        /// </summary>
        FileWriter MyWriter;

        #endregion

        #region Constructor/s
        /// <summary>
        /// Constructor for the ScoreTracker class.
        /// </summary>
        public ScoreTracker()
        {
            InitializeComponent();
            MyWriter = new FileWriter();
        }
        #endregion

        #region EventHandlers

        #region ClickHandlers
        /// <summary>
        /// Handles the Submit Count button being clicked.
        /// Instantiates the Students and Scores arrays with entered parameters.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event object</param>
        private void SubCountBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Set the Students array to be as long as the user requested.
                Students = new string[Convert.ToInt32(NumStudentsBox.Text)];
                //Insert generic student names into array.
                for (int i = 1; i <= Students.Length; i++)
                {
                    Students[i - 1] = "Student #" + i;
                }
                //Set the Scores multi-dimensional array to have # of Student rows and # of Assignments columns.
                Scores = new int[Convert.ToInt32(NumStudentsBox.Text), Convert.ToInt32(NumAssignmentsBox.Text)];
                CurStudent = 0;
                //Set the Label for the number of the assignment they can enter.
                AssignmentLabel.Text = "Assignment Number (1-" + Scores.GetLength(1) + "):";

                //Enable all controls that were previously disabled.
                if (Students.Length != 1)
                {
                    NextStudentBtn.Enabled = true;
                    LastStudentBtn.Enabled = true;
                }
                ResetBtn.Enabled = true;
                ShowScoresBtn.Enabled = true;
                StudentName.Enabled = true;
                AssignmentNumberBox.Enabled = true;
                AssignmentScoreBox.Enabled = true;
                OutputFileBtn.Enabled = true;
                FileNameBox.Enabled = true;
                //Disable inputting a new # of students and assignments.
                SubCountBtn.Enabled = false;
                NumStudentsBox.Enabled = false;
                NumAssignmentsBox.Enabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Change the currently selected student to the first in the list.
        /// Change First and Prev student buttons to disabled and enable NNext and Last.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void FirstStudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurStudent = 0;
                StudentNameLabel.Text = Students[CurStudent];
                FirstStudentBtn.Enabled = false;
                PrevStudentBtn.Enabled = false;
                NextStudentBtn.Enabled = true;
                LastStudentBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Change the currently selected student to the student 1 index before the current one.
        /// If the new selected student is the first in the list then disable First and Prev student buttons.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void PrevStudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurStudent = CurStudent - 1;
                StudentNameLabel.Text = Students[CurStudent];
                FirstStudentBtn.Enabled = !(CurStudent == 0);
                PrevStudentBtn.Enabled = !(CurStudent == 0);
                NextStudentBtn.Enabled = true;
                LastStudentBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Change the currently selected student to the next one in the list.
        /// If the new selected student is the last in the list then disable Next and Last buttons.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void NextStudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurStudent = CurStudent + 1;
                StudentNameLabel.Text = Students[CurStudent];
                FirstStudentBtn.Enabled = true;
                PrevStudentBtn.Enabled = true;
                NextStudentBtn.Enabled = !(CurStudent == Students.Length - 1);
                LastStudentBtn.Enabled = !(CurStudent == Students.Length - 1);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Change the currently selected student to the last one in the list.
        /// Disable Next and Last student buttons and enable First and Prev.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void LastStudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CurStudent = Students.Length - 1;
                StudentNameLabel.Text = Students[CurStudent];
                FirstStudentBtn.Enabled = true;
                PrevStudentBtn.Enabled = true;
                NextStudentBtn.Enabled = false;
                LastStudentBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When a new name is input, changes the old name to the new name in the Students array.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void SaveNameBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Students[CurStudent] = StudentName.Text;
                StudentNameLabel.Text = Students[CurStudent];
                StudentName.Text = "";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Save the provided score to the provided assignment to the array in scores corresponding to the current student.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void SaveScoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Scores[CurStudent, Convert.ToInt32(AssignmentNumberBox.Text) - 1] = Convert.ToInt32(AssignmentScoreBox.Text);
                AssignmentNumberBox.Text = "";
                AssignmentScoreBox.Text = "";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Reset all buttons, text fields, labels to their original states.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                NumStudentsBox.Enabled = true;
                NumStudentsBox.Text = "";
                NumAssignmentsBox.Enabled = true;
                NumAssignmentsBox.Text = "";
                AssignmentLabel.Text = "Assignment Number ():";
                AssignmentNumberBox.Enabled = false;
                AssignmentNumberBox.Text = "";
                AssignmentScoreBox.Enabled = false;
                AssignmentScoreBox.Text = "";
                StudentNameLabel.Text = "Student #1";
                FirstStudentBtn.Enabled = false;
                PrevStudentBtn.Enabled = false;
                NextStudentBtn.Enabled = false;
                LastStudentBtn.Enabled = false;
                ResetBtn.Enabled = false;
                StudentName.Enabled = false;
                StudentName.Text = "";
                SaveNameBtn.Enabled = false;
                ShowScoresBtn.Enabled = false;
                SaveScoreBtn.Enabled = false;
                AssignmentDetailBox.Text = "";
                OutputFileBtn.Enabled = false;
                FileNameBox.Text = "";
                FileNameBox.Enabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Appends each students scores to the Assignment Detail Box. Also appends average and grade.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void ShowScoresBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Reset the RichTextBox
                AssignmentDetailBox.Text = "";
                //Append the main row
                AssignmentDetailBox.AppendText("STUDENT\t\t");
                for (int x = 0; x < Scores.GetLength(1); x++)
                {
                    AssignmentDetailBox.AppendText("#" + (x + 1) + "\t");
                }
                AssignmentDetailBox.AppendText("AVG\tGRADE\n");

                //Loop through the Score array appending each assignments score
                for (int i = 0; i < Students.Length; i++)
                {

                    AssignmentDetailBox.AppendText(Students[i] + "\t\t");

                    //Running total of scores to determine AVG
                    int total = 0;
                    for (int j = 0; j < Scores.GetLength(1); j++)
                    {
                        AssignmentDetailBox.AppendText(
                            Scores[i, j] <= 9 ? " " + Scores[i, j] : Scores[i, j].ToString());
                        AssignmentDetailBox.AppendText("%\t");
                        total += Scores[i, j];
                    }
                    AssignmentDetailBox.AppendText(((double)total / Scores.GetLength(1)).ToString("0.00") + "%\t" + DetermineGrade((double)total / Scores.GetLength(1)) + "\n");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion

        #region OnChangeHandlers
        /// <summary>
        /// Handles the text in the Number of Students input changing. 
        /// Validates the input and changes errors/colors accordingly.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event object</param>
        private void NumStudentsBox_Change(object sender, EventArgs e)
        {
            if (NumStudentsBox.Text != "")
            {
                int value;
                bool valid = Int32.TryParse(NumStudentsBox.Text, out value);
                StudentErrLabel.Text = valid && (value >= 1 && value <= 10) ? "" : "# of students must be between 1 and 10";
                NumStudentsBox.BackColor = valid && (value >= 1 && value <= 10) ? SystemColors.Window : Color.LightCoral;
                SubCountBtn.Enabled = StudentErrLabel.Text == "" && (AssignmentsErrLabel.Text == "" &&  NumAssignmentsBox.Text != "");
            }
            else
            {
                StudentErrLabel.Text = "";
                NumStudentsBox.BackColor = SystemColors.Window;
                SubCountBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the text in the Number of Assignments input changing. 
        /// Validates the input and changes errors/colors accordingly.
        /// </summary>
        /// <param name="sender">Event Sender</param>
        /// <param name="e">Event object</param>
        private void NumAssignmentsBox_Change(object sender, EventArgs e)
        {
            if (NumAssignmentsBox.Text != "")
            {
                int value;
                bool valid = Int32.TryParse(NumAssignmentsBox.Text, out value);
                AssignmentsErrLabel.Text = valid && (value >= 1 && value <= 99) ? "" : "# of assignments must be between 1 and 99";
                NumAssignmentsBox.BackColor = valid && (value >= 1 && value <= 99) ? SystemColors.Window : Color.LightCoral;
                SubCountBtn.Enabled = (StudentErrLabel.Text == "" && NumStudentsBox.Text != "") && AssignmentsErrLabel.Text == "";
            }
            else
            {
                AssignmentsErrLabel.Text = "";
                NumAssignmentsBox.BackColor = SystemColors.Window;
                SubCountBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Enables the Save Name button once the user enters something into the Student Name text box.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void StudentName_Change(object sender, EventArgs e)
        {
            SaveNameBtn.Enabled = StudentName.Text != "";
        }

        /// <summary>
        /// Validate that the assignment number provided is an int and is within the bounds provided by the user.
        /// If both Assignment # and score are valid then enable the Save Score button.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Object</param>
        private void AssignmentNumberBox_Change(object sender, EventArgs e)
        {
            if (AssignmentNumberBox.Text != "")
            {
                int value;
                bool valid = Int32.TryParse(AssignmentNumberBox.Text, out value);
                AssignmentNumberBox.BackColor = valid && (value >= 1 && value <= Scores.GetLength(1)) ? SystemColors.Window : Color.LightCoral;
                SaveScoreBtn.Enabled = ((AssignmentScoreBox.Text != "" && AssignmentScoreBox.BackColor == SystemColors.Window) &&
                    (AssignmentNumberBox.Text != "" && AssignmentScoreBox.BackColor == SystemColors.Window));
                AssignmentNumErr.Text = valid && (value >= 1 && value <= Scores.GetLength(1)) ? "" : "Assignment # must be between 1 and " + Scores.GetLength(1);
            }
            else
            {
                AssignmentNumErr.Text = "";
                AssignmentNumberBox.BackColor = SystemColors.Window;
                SaveScoreBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Validate that the score provided is an integer greater than 0.
        /// If both Assignment # and score are valid then enable the Save Score button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignmentScoreBox_Change(object sender, EventArgs e)
        {
            if(AssignmentScoreBox.Text != "") { 
                int value;
                bool valid = Int32.TryParse(AssignmentScoreBox.Text, out value);
                AssignmentScoreBox.BackColor = valid && value >= 0 ? SystemColors.Window : Color.LightCoral;
                SaveScoreBtn.Enabled = ((AssignmentScoreBox.Text != "" && AssignmentScoreBox.BackColor == SystemColors.Window) &&
                    (AssignmentNumberBox.Text != "" && AssignmentScoreBox.BackColor == SystemColors.Window));
                AssignmentScoreErr.Text = valid && value >= 0 ? "" : "Score must be greater than 0";
            }
            else
            {
                AssignmentScoreErr.Text = "";
                AssignmentScoreBox.BackColor = SystemColors.Window;
                SaveScoreBtn.Enabled = false;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Takes in a double representing a student's average graade and returns the corresponding letter grade.
        /// </summary>
        /// <param name="score">Average of a student's scores</param>
        /// <returns>Letter grade corresponding to the student's average</returns>
        private string DetermineGrade(double score)
        {
            try
            {
                if (score >= 93)
                    return "A";
                else if (score <= 92.9 && score >= 90)
                    return "A-";
                else if (score <= 89.9 && score >= 87)
                    return "B+";
                else if (score <= 86.9 && score >= 83)
                    return "B";
                else if (score <= 82.9 && score >= 80)
                    return "B-";
                else if (score <= 79.9 && score >= 77)
                    return "C+";
                else if (score <= 76.9 && score >= 73)
                    return "C";
                else if (score <= 72.9 && score >= 70)
                    return "C-";
                else if (score <= 69.9 && score >= 67)
                    return "D+";
                else if (score <= 66.9 && score >= 63)
                    return "D";
                else if (score <= 62.9 && score >= 60)
                    return "D-";
                else
                    return "E";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// OnClick Listener for the Output File Button
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void OutputFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Change file writing label
                FileWritingLbl.Text = "Writing To File";
                OutputFileBtn.Enabled = false;
                FileNameBox.Enabled = false;

                //Start the background worker
                FileWriteWorker.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// DoWork method for the FileWriteWorker background worker.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void FileWriteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Check that the file doesnt already exist
            if (!MyWriter.FileExists("C:\\Users\\Public\\" + FileNameBox.Text))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("STUDENT\t\t");
                for (int x = 0; x < Scores.GetLength(1); x++)
                {
                    stringBuilder.Append("#" + (x + 1) + "\t");
                }
                stringBuilder.Append("AVG\t\tGRADE\n");

                //Loop through the Score array appending each assignments score
                for (int i = 0; i < Students.Length; i++)
                {

                    stringBuilder.Append(Students[i] + "\t\t");

                    //Running total of scores to determine AVG
                    int total = 0;
                    for (int j = 0; j < Scores.GetLength(1); j++)
                    {
                        stringBuilder.Append(
                            Scores[i, j] <= 9 ? " " + Scores[i, j] : Scores[i, j].ToString());
                        stringBuilder.Append("%\t");
                        total += Scores[i, j];
                    }
                    stringBuilder.Append(((double)total / Scores.GetLength(1)).ToString("0.00") + "%\t" + DetermineGrade((double)total / Scores.GetLength(1)) + "\n");

                    //Write to the provided file
                    MyWriter.WriteToFile("C:\\Users\\Public\\" + FileNameBox.Text, stringBuilder.ToString());

                    //Simulate a process taking a long time to complete
                    Thread.Sleep(2000);
                }
            }
            //If the file exists, throw an error to be caught in the WorkerCompleted method
            else
            {
                throw new Exception("That file already exists. Please enter another.");
            }
        }

        /// <summary>
        /// WorkerCompleted method for the FileWriteWorker background worker
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event object</param>
        private void FileWriteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //Populate the file writing label with either an error message or the completed message
                if (e.Error != null)
                    FileWritingLbl.Text = e.Error.Message;
                else
                    FileWritingLbl.Text = "Completed Writing to File";

                OutputFileBtn.Enabled = true;
                FileNameBox.Enabled = true;
                FileNameBox.Text = "";
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles errors thrown
        /// </summary>
        /// <param name="Class">Class in which the exception was thrown</param>
        /// <param name="Method">Method in which the exception was thrown</param>
        /// <param name="Message">Pathway the exception took</param>
        private void HandleError(string Class, string Method, string Message)
        {
            try
            {
                MessageBox.Show(Class + "." + Method + " -> " + Message);
            }
            catch (Exception ex)
            {
                //Write to error file here
            }
        }

    }
}
