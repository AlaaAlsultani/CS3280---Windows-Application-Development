namespace CS3280A3
{
    partial class ScoreTracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountBox = new System.Windows.Forms.GroupBox();
            this.AssignmentsErrLabel = new System.Windows.Forms.Label();
            this.StudentErrLabel = new System.Windows.Forms.Label();
            this.SubCountBtn = new System.Windows.Forms.Button();
            this.NumAssignmentsBox = new System.Windows.Forms.TextBox();
            this.NumStudentsBox = new System.Windows.Forms.TextBox();
            this.NumAssignmentsLabel = new System.Windows.Forms.Label();
            this.NumStudentsLabel = new System.Windows.Forms.Label();
            this.NavBox = new System.Windows.Forms.GroupBox();
            this.LastStudentBtn = new System.Windows.Forms.Button();
            this.NextStudentBtn = new System.Windows.Forms.Button();
            this.PrevStudentBtn = new System.Windows.Forms.Button();
            this.FirstStudentBtn = new System.Windows.Forms.Button();
            this.StudentNameBox = new System.Windows.Forms.GroupBox();
            this.SaveNameBtn = new System.Windows.Forms.Button();
            this.StudentName = new System.Windows.Forms.TextBox();
            this.StudentNameLabel = new System.Windows.Forms.Label();
            this.ScoreInputBox = new System.Windows.Forms.GroupBox();
            this.AssignmentScoreErr = new System.Windows.Forms.Label();
            this.AssignmentNumErr = new System.Windows.Forms.Label();
            this.SaveScoreBtn = new System.Windows.Forms.Button();
            this.AssignmentScoreBox = new System.Windows.Forms.TextBox();
            this.AssignmentNumberBox = new System.Windows.Forms.TextBox();
            this.AssignmentScoreLabel = new System.Windows.Forms.Label();
            this.AssignmentLabel = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.AssignmentDetailBox = new System.Windows.Forms.RichTextBox();
            this.ShowScoresBtn = new System.Windows.Forms.Button();
            this.OutputFileBtn = new System.Windows.Forms.Button();
            this.FileWriteWorker = new System.ComponentModel.BackgroundWorker();
            this.FileNameLbl = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.FileWritingLbl = new System.Windows.Forms.Label();
            this.CountBox.SuspendLayout();
            this.NavBox.SuspendLayout();
            this.StudentNameBox.SuspendLayout();
            this.ScoreInputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CountBox
            // 
            this.CountBox.Controls.Add(this.AssignmentsErrLabel);
            this.CountBox.Controls.Add(this.StudentErrLabel);
            this.CountBox.Controls.Add(this.SubCountBtn);
            this.CountBox.Controls.Add(this.NumAssignmentsBox);
            this.CountBox.Controls.Add(this.NumStudentsBox);
            this.CountBox.Controls.Add(this.NumAssignmentsLabel);
            this.CountBox.Controls.Add(this.NumStudentsLabel);
            this.CountBox.Location = new System.Drawing.Point(12, 12);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(400, 98);
            this.CountBox.TabIndex = 0;
            this.CountBox.TabStop = false;
            this.CountBox.Text = "Counts";
            // 
            // AssignmentsErrLabel
            // 
            this.AssignmentsErrLabel.AutoSize = true;
            this.AssignmentsErrLabel.ForeColor = System.Drawing.Color.Red;
            this.AssignmentsErrLabel.Location = new System.Drawing.Point(181, 82);
            this.AssignmentsErrLabel.Name = "AssignmentsErrLabel";
            this.AssignmentsErrLabel.Size = new System.Drawing.Size(0, 13);
            this.AssignmentsErrLabel.TabIndex = 6;
            // 
            // StudentErrLabel
            // 
            this.StudentErrLabel.AutoSize = true;
            this.StudentErrLabel.ForeColor = System.Drawing.Color.Red;
            this.StudentErrLabel.Location = new System.Drawing.Point(191, 16);
            this.StudentErrLabel.Name = "StudentErrLabel";
            this.StudentErrLabel.Size = new System.Drawing.Size(0, 13);
            this.StudentErrLabel.TabIndex = 5;
            // 
            // SubCountBtn
            // 
            this.SubCountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubCountBtn.Enabled = false;
            this.SubCountBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubCountBtn.Location = new System.Drawing.Point(273, 41);
            this.SubCountBtn.Name = "SubCountBtn";
            this.SubCountBtn.Size = new System.Drawing.Size(101, 29);
            this.SubCountBtn.TabIndex = 4;
            this.SubCountBtn.Text = "Submit Counts";
            this.SubCountBtn.UseVisualStyleBackColor = true;
            this.SubCountBtn.Click += new System.EventHandler(this.SubCountBtn_Click);
            // 
            // NumAssignmentsBox
            // 
            this.NumAssignmentsBox.Location = new System.Drawing.Point(191, 61);
            this.NumAssignmentsBox.MaxLength = 2;
            this.NumAssignmentsBox.Name = "NumAssignmentsBox";
            this.NumAssignmentsBox.Size = new System.Drawing.Size(45, 20);
            this.NumAssignmentsBox.TabIndex = 3;
            this.NumAssignmentsBox.TextChanged += new System.EventHandler(this.NumAssignmentsBox_Change);
            // 
            // NumStudentsBox
            // 
            this.NumStudentsBox.Location = new System.Drawing.Point(191, 32);
            this.NumStudentsBox.MaxLength = 2;
            this.NumStudentsBox.Name = "NumStudentsBox";
            this.NumStudentsBox.Size = new System.Drawing.Size(45, 20);
            this.NumStudentsBox.TabIndex = 2;
            this.NumStudentsBox.TextChanged += new System.EventHandler(this.NumStudentsBox_Change);
            // 
            // NumAssignmentsLabel
            // 
            this.NumAssignmentsLabel.AutoSize = true;
            this.NumAssignmentsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAssignmentsLabel.Location = new System.Drawing.Point(10, 62);
            this.NumAssignmentsLabel.Name = "NumAssignmentsLabel";
            this.NumAssignmentsLabel.Size = new System.Drawing.Size(165, 17);
            this.NumAssignmentsLabel.TabIndex = 1;
            this.NumAssignmentsLabel.Text = "Number of assignments:";
            // 
            // NumStudentsLabel
            // 
            this.NumStudentsLabel.AutoSize = true;
            this.NumStudentsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumStudentsLabel.Location = new System.Drawing.Point(36, 32);
            this.NumStudentsLabel.Name = "NumStudentsLabel";
            this.NumStudentsLabel.Size = new System.Drawing.Size(139, 17);
            this.NumStudentsLabel.TabIndex = 0;
            this.NumStudentsLabel.Text = "Number of students:";
            // 
            // NavBox
            // 
            this.NavBox.Controls.Add(this.LastStudentBtn);
            this.NavBox.Controls.Add(this.NextStudentBtn);
            this.NavBox.Controls.Add(this.PrevStudentBtn);
            this.NavBox.Controls.Add(this.FirstStudentBtn);
            this.NavBox.Location = new System.Drawing.Point(12, 130);
            this.NavBox.Name = "NavBox";
            this.NavBox.Size = new System.Drawing.Size(591, 71);
            this.NavBox.TabIndex = 1;
            this.NavBox.TabStop = false;
            this.NavBox.Text = "Navigation";
            // 
            // LastStudentBtn
            // 
            this.LastStudentBtn.Enabled = false;
            this.LastStudentBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastStudentBtn.Location = new System.Drawing.Point(445, 29);
            this.LastStudentBtn.Name = "LastStudentBtn";
            this.LastStudentBtn.Size = new System.Drawing.Size(124, 26);
            this.LastStudentBtn.TabIndex = 3;
            this.LastStudentBtn.Text = "Last Student >>";
            this.LastStudentBtn.UseVisualStyleBackColor = true;
            this.LastStudentBtn.Click += new System.EventHandler(this.LastStudentBtn_Click);
            // 
            // NextStudentBtn
            // 
            this.NextStudentBtn.Enabled = false;
            this.NextStudentBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextStudentBtn.Location = new System.Drawing.Point(304, 29);
            this.NextStudentBtn.Name = "NextStudentBtn";
            this.NextStudentBtn.Size = new System.Drawing.Size(124, 26);
            this.NextStudentBtn.TabIndex = 2;
            this.NextStudentBtn.Text = "Next Student >";
            this.NextStudentBtn.UseVisualStyleBackColor = true;
            this.NextStudentBtn.Click += new System.EventHandler(this.NextStudentBtn_Click);
            // 
            // PrevStudentBtn
            // 
            this.PrevStudentBtn.Enabled = false;
            this.PrevStudentBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrevStudentBtn.Location = new System.Drawing.Point(165, 29);
            this.PrevStudentBtn.Name = "PrevStudentBtn";
            this.PrevStudentBtn.Size = new System.Drawing.Size(124, 26);
            this.PrevStudentBtn.TabIndex = 1;
            this.PrevStudentBtn.Text = "< Previous Student";
            this.PrevStudentBtn.UseVisualStyleBackColor = true;
            this.PrevStudentBtn.Click += new System.EventHandler(this.PrevStudentBtn_Click);
            // 
            // FirstStudentBtn
            // 
            this.FirstStudentBtn.Enabled = false;
            this.FirstStudentBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstStudentBtn.Location = new System.Drawing.Point(23, 29);
            this.FirstStudentBtn.Name = "FirstStudentBtn";
            this.FirstStudentBtn.Size = new System.Drawing.Size(124, 26);
            this.FirstStudentBtn.TabIndex = 0;
            this.FirstStudentBtn.Text = "<< First Student";
            this.FirstStudentBtn.UseVisualStyleBackColor = true;
            this.FirstStudentBtn.Click += new System.EventHandler(this.FirstStudentBtn_Click);
            // 
            // StudentNameBox
            // 
            this.StudentNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.StudentNameBox.Controls.Add(this.SaveNameBtn);
            this.StudentNameBox.Controls.Add(this.StudentName);
            this.StudentNameBox.Controls.Add(this.StudentNameLabel);
            this.StudentNameBox.Location = new System.Drawing.Point(12, 221);
            this.StudentNameBox.Name = "StudentNameBox";
            this.StudentNameBox.Size = new System.Drawing.Size(591, 70);
            this.StudentNameBox.TabIndex = 2;
            this.StudentNameBox.TabStop = false;
            this.StudentNameBox.Text = "Student Name";
            // 
            // SaveNameBtn
            // 
            this.SaveNameBtn.Enabled = false;
            this.SaveNameBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveNameBtn.Location = new System.Drawing.Point(445, 24);
            this.SaveNameBtn.Name = "SaveNameBtn";
            this.SaveNameBtn.Size = new System.Drawing.Size(105, 33);
            this.SaveNameBtn.TabIndex = 2;
            this.SaveNameBtn.Text = "Save Name";
            this.SaveNameBtn.UseVisualStyleBackColor = true;
            this.SaveNameBtn.Click += new System.EventHandler(this.SaveNameBtn_Click);
            // 
            // StudentName
            // 
            this.StudentName.Enabled = false;
            this.StudentName.Location = new System.Drawing.Point(139, 31);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(276, 20);
            this.StudentName.TabIndex = 1;
            this.StudentName.TextChanged += new System.EventHandler(this.StudentName_Change);
            // 
            // StudentNameLabel
            // 
            this.StudentNameLabel.AutoSize = true;
            this.StudentNameLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.StudentNameLabel.Location = new System.Drawing.Point(10, 32);
            this.StudentNameLabel.MaximumSize = new System.Drawing.Size(120, 38);
            this.StudentNameLabel.Name = "StudentNameLabel";
            this.StudentNameLabel.Size = new System.Drawing.Size(80, 17);
            this.StudentNameLabel.TabIndex = 0;
            this.StudentNameLabel.Text = "Student #1";
            // 
            // ScoreInputBox
            // 
            this.ScoreInputBox.Controls.Add(this.AssignmentScoreErr);
            this.ScoreInputBox.Controls.Add(this.AssignmentNumErr);
            this.ScoreInputBox.Controls.Add(this.SaveScoreBtn);
            this.ScoreInputBox.Controls.Add(this.AssignmentScoreBox);
            this.ScoreInputBox.Controls.Add(this.AssignmentNumberBox);
            this.ScoreInputBox.Controls.Add(this.AssignmentScoreLabel);
            this.ScoreInputBox.Controls.Add(this.AssignmentLabel);
            this.ScoreInputBox.Location = new System.Drawing.Point(12, 311);
            this.ScoreInputBox.Name = "ScoreInputBox";
            this.ScoreInputBox.Size = new System.Drawing.Size(415, 106);
            this.ScoreInputBox.TabIndex = 3;
            this.ScoreInputBox.TabStop = false;
            this.ScoreInputBox.Text = "Score Input";
            // 
            // AssignmentScoreErr
            // 
            this.AssignmentScoreErr.AutoSize = true;
            this.AssignmentScoreErr.ForeColor = System.Drawing.Color.Red;
            this.AssignmentScoreErr.Location = new System.Drawing.Point(204, 90);
            this.AssignmentScoreErr.Name = "AssignmentScoreErr";
            this.AssignmentScoreErr.Size = new System.Drawing.Size(0, 13);
            this.AssignmentScoreErr.TabIndex = 6;
            // 
            // AssignmentNumErr
            // 
            this.AssignmentNumErr.AutoSize = true;
            this.AssignmentNumErr.ForeColor = System.Drawing.Color.Red;
            this.AssignmentNumErr.Location = new System.Drawing.Point(204, 13);
            this.AssignmentNumErr.Name = "AssignmentNumErr";
            this.AssignmentNumErr.Size = new System.Drawing.Size(0, 13);
            this.AssignmentNumErr.TabIndex = 5;
            // 
            // SaveScoreBtn
            // 
            this.SaveScoreBtn.Enabled = false;
            this.SaveScoreBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveScoreBtn.Location = new System.Drawing.Point(304, 41);
            this.SaveScoreBtn.Name = "SaveScoreBtn";
            this.SaveScoreBtn.Size = new System.Drawing.Size(85, 32);
            this.SaveScoreBtn.TabIndex = 4;
            this.SaveScoreBtn.Text = "Save Score";
            this.SaveScoreBtn.UseVisualStyleBackColor = true;
            this.SaveScoreBtn.Click += new System.EventHandler(this.SaveScoreBtn_Click);
            // 
            // AssignmentScoreBox
            // 
            this.AssignmentScoreBox.Enabled = false;
            this.AssignmentScoreBox.Location = new System.Drawing.Point(219, 66);
            this.AssignmentScoreBox.Name = "AssignmentScoreBox";
            this.AssignmentScoreBox.Size = new System.Drawing.Size(43, 20);
            this.AssignmentScoreBox.TabIndex = 3;
            this.AssignmentScoreBox.TextChanged += new System.EventHandler(this.AssignmentScoreBox_Change);
            // 
            // AssignmentNumberBox
            // 
            this.AssignmentNumberBox.Enabled = false;
            this.AssignmentNumberBox.Location = new System.Drawing.Point(219, 29);
            this.AssignmentNumberBox.Name = "AssignmentNumberBox";
            this.AssignmentNumberBox.Size = new System.Drawing.Size(43, 20);
            this.AssignmentNumberBox.TabIndex = 2;
            this.AssignmentNumberBox.TextChanged += new System.EventHandler(this.AssignmentNumberBox_Change);
            // 
            // AssignmentScoreLabel
            // 
            this.AssignmentScoreLabel.AutoSize = true;
            this.AssignmentScoreLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignmentScoreLabel.Location = new System.Drawing.Point(76, 67);
            this.AssignmentScoreLabel.Name = "AssignmentScoreLabel";
            this.AssignmentScoreLabel.Size = new System.Drawing.Size(128, 17);
            this.AssignmentScoreLabel.TabIndex = 1;
            this.AssignmentScoreLabel.Text = "Assignment Score:";
            // 
            // AssignmentLabel
            // 
            this.AssignmentLabel.AutoSize = true;
            this.AssignmentLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignmentLabel.Location = new System.Drawing.Point(20, 30);
            this.AssignmentLabel.Name = "AssignmentLabel";
            this.AssignmentLabel.Size = new System.Drawing.Size(156, 17);
            this.AssignmentLabel.TabIndex = 0;
            this.AssignmentLabel.Text = "Assignment Number ():";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Enabled = false;
            this.ResetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.Location = new System.Drawing.Point(476, 40);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(79, 51);
            this.ResetBtn.TabIndex = 4;
            this.ResetBtn.Text = "Reset Scores";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // AssignmentDetailBox
            // 
            this.AssignmentDetailBox.Location = new System.Drawing.Point(12, 439);
            this.AssignmentDetailBox.Name = "AssignmentDetailBox";
            this.AssignmentDetailBox.ReadOnly = true;
            this.AssignmentDetailBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AssignmentDetailBox.Size = new System.Drawing.Size(587, 150);
            this.AssignmentDetailBox.TabIndex = 5;
            this.AssignmentDetailBox.Text = "";
            this.AssignmentDetailBox.WordWrap = false;
            // 
            // ShowScoresBtn
            // 
            this.ShowScoresBtn.Enabled = false;
            this.ShowScoresBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowScoresBtn.Location = new System.Drawing.Point(469, 299);
            this.ShowScoresBtn.Name = "ShowScoresBtn";
            this.ShowScoresBtn.Size = new System.Drawing.Size(93, 33);
            this.ShowScoresBtn.TabIndex = 6;
            this.ShowScoresBtn.Text = "Show Scores";
            this.ShowScoresBtn.UseVisualStyleBackColor = true;
            this.ShowScoresBtn.Click += new System.EventHandler(this.ShowScoresBtn_Click);
            // 
            // OutputFileBtn
            // 
            this.OutputFileBtn.Enabled = false;
            this.OutputFileBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFileBtn.Location = new System.Drawing.Point(469, 338);
            this.OutputFileBtn.Name = "OutputFileBtn";
            this.OutputFileBtn.Size = new System.Drawing.Size(93, 33);
            this.OutputFileBtn.TabIndex = 7;
            this.OutputFileBtn.Text = "Output To File";
            this.OutputFileBtn.UseVisualStyleBackColor = true;
            this.OutputFileBtn.Click += new System.EventHandler(this.OutputFileBtn_Click);
            // 
            // FileWriteWorker
            // 
            this.FileWriteWorker.WorkerReportsProgress = true;
            this.FileWriteWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileWriteWorker_DoWork);
            this.FileWriteWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileWriteWorker_RunWorkerCompleted);
            // 
            // FileNameLbl
            // 
            this.FileNameLbl.AutoSize = true;
            this.FileNameLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLbl.Location = new System.Drawing.Point(446, 384);
            this.FileNameLbl.Name = "FileNameLbl";
            this.FileNameLbl.Size = new System.Drawing.Size(77, 17);
            this.FileNameLbl.TabIndex = 8;
            this.FileNameLbl.Text = "File Name:";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Enabled = false;
            this.FileNameBox.Location = new System.Drawing.Point(521, 384);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(78, 20);
            this.FileNameBox.TabIndex = 9;
            // 
            // FileWritingLbl
            // 
            this.FileWritingLbl.AutoSize = true;
            this.FileWritingLbl.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileWritingLbl.Location = new System.Drawing.Point(446, 406);
            this.FileWritingLbl.MaximumSize = new System.Drawing.Size(150, 150);
            this.FileWritingLbl.Name = "FileWritingLbl";
            this.FileWritingLbl.Size = new System.Drawing.Size(0, 14);
            this.FileWritingLbl.TabIndex = 10;
            // 
            // ScoreTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(612, 601);
            this.Controls.Add(this.FileWritingLbl);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.FileNameLbl);
            this.Controls.Add(this.OutputFileBtn);
            this.Controls.Add(this.ShowScoresBtn);
            this.Controls.Add(this.AssignmentDetailBox);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.ScoreInputBox);
            this.Controls.Add(this.StudentNameBox);
            this.Controls.Add(this.NavBox);
            this.Controls.Add(this.CountBox);
            this.MaximumSize = new System.Drawing.Size(628, 640);
            this.Name = "ScoreTracker";
            this.Text = "Score Tracker";
            this.CountBox.ResumeLayout(false);
            this.CountBox.PerformLayout();
            this.NavBox.ResumeLayout(false);
            this.StudentNameBox.ResumeLayout(false);
            this.StudentNameBox.PerformLayout();
            this.ScoreInputBox.ResumeLayout(false);
            this.ScoreInputBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox CountBox;
        private System.Windows.Forms.Button SubCountBtn;
        private System.Windows.Forms.TextBox NumAssignmentsBox;
        private System.Windows.Forms.TextBox NumStudentsBox;
        private System.Windows.Forms.Label NumAssignmentsLabel;
        private System.Windows.Forms.Label NumStudentsLabel;
        private System.Windows.Forms.GroupBox NavBox;
        private System.Windows.Forms.Button LastStudentBtn;
        private System.Windows.Forms.Button NextStudentBtn;
        private System.Windows.Forms.Button PrevStudentBtn;
        private System.Windows.Forms.Button FirstStudentBtn;
        private System.Windows.Forms.GroupBox StudentNameBox;
        private System.Windows.Forms.Button SaveNameBtn;
        private System.Windows.Forms.TextBox StudentName;
        private System.Windows.Forms.Label StudentNameLabel;
        private System.Windows.Forms.GroupBox ScoreInputBox;
        private System.Windows.Forms.Button SaveScoreBtn;
        private System.Windows.Forms.TextBox AssignmentScoreBox;
        private System.Windows.Forms.TextBox AssignmentNumberBox;
        private System.Windows.Forms.Label AssignmentScoreLabel;
        private System.Windows.Forms.Label AssignmentLabel;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.RichTextBox AssignmentDetailBox;
        private System.Windows.Forms.Button ShowScoresBtn;
        private System.Windows.Forms.Label AssignmentsErrLabel;
        private System.Windows.Forms.Label StudentErrLabel;
        private System.Windows.Forms.Label AssignmentNumErr;
        private System.Windows.Forms.Label AssignmentScoreErr;
        private System.Windows.Forms.Button OutputFileBtn;
        private System.ComponentModel.BackgroundWorker FileWriteWorker;
        private System.Windows.Forms.Label FileNameLbl;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Label FileWritingLbl;
    }
}

