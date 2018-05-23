namespace CS3280A2
{
    partial class DiceRollForm
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
            this.DiceImage = new System.Windows.Forms.PictureBox();
            this.TimesPlayedLabel = new System.Windows.Forms.Label();
            this.NumberWonLabel = new System.Windows.Forms.Label();
            this.TimesLost = new System.Windows.Forms.Label();
            this.GuessEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RollButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ResultsBox = new System.Windows.Forms.GroupBox();
            this.LossCount = new System.Windows.Forms.Label();
            this.WinCount = new System.Windows.Forms.Label();
            this.PlayedCount = new System.Windows.Forms.Label();
            this.StatBox = new System.Windows.Forms.RichTextBox();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.ResultsMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DiceImage)).BeginInit();
            this.ResultsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiceImage
            // 
            this.DiceImage.Image = global::CS3280A2.Properties.Resources.die1;
            this.DiceImage.Location = new System.Drawing.Point(365, 40);
            this.DiceImage.Name = "DiceImage";
            this.DiceImage.Size = new System.Drawing.Size(102, 104);
            this.DiceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DiceImage.TabIndex = 1;
            this.DiceImage.TabStop = false;
            // 
            // TimesPlayedLabel
            // 
            this.TimesPlayedLabel.AutoSize = true;
            this.TimesPlayedLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TimesPlayedLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimesPlayedLabel.Location = new System.Drawing.Point(6, 26);
            this.TimesPlayedLabel.Name = "TimesPlayedLabel";
            this.TimesPlayedLabel.Size = new System.Drawing.Size(147, 22);
            this.TimesPlayedLabel.TabIndex = 2;
            this.TimesPlayedLabel.Text = "Times Played: ";
            // 
            // NumberWonLabel
            // 
            this.NumberWonLabel.AutoSize = true;
            this.NumberWonLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.NumberWonLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberWonLabel.Location = new System.Drawing.Point(23, 66);
            this.NumberWonLabel.Name = "NumberWonLabel";
            this.NumberWonLabel.Size = new System.Drawing.Size(130, 22);
            this.NumberWonLabel.TabIndex = 3;
            this.NumberWonLabel.Text = "Times Won:  ";
            // 
            // TimesLost
            // 
            this.TimesLost.AutoSize = true;
            this.TimesLost.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TimesLost.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimesLost.Location = new System.Drawing.Point(23, 106);
            this.TimesLost.Name = "TimesLost";
            this.TimesLost.Size = new System.Drawing.Size(125, 22);
            this.TimesLost.TabIndex = 4;
            this.TimesLost.Text = "Times Lost: ";
            // 
            // GuessEntry
            // 
            this.GuessEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuessEntry.Location = new System.Drawing.Point(263, 209);
            this.GuessEntry.MaxLength = 1;
            this.GuessEntry.Name = "GuessEntry";
            this.GuessEntry.Size = new System.Drawing.Size(32, 22);
            this.GuessEntry.TabIndex = 5;
            this.GuessEntry.TextChanged += new System.EventHandler(this.GuessEntry_Change);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter a Guess (1-6)";
            // 
            // RollButton
            // 
            this.RollButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.RollButton.Enabled = false;
            this.RollButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollButton.Location = new System.Drawing.Point(351, 198);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(73, 33);
            this.RollButton.TabIndex = 7;
            this.RollButton.Text = "Roll";
            this.RollButton.UseVisualStyleBackColor = false;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ResetButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(351, 248);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(73, 33);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ResultsBox
            // 
            this.ResultsBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ResultsBox.Controls.Add(this.LossCount);
            this.ResultsBox.Controls.Add(this.WinCount);
            this.ResultsBox.Controls.Add(this.PlayedCount);
            this.ResultsBox.Controls.Add(this.NumberWonLabel);
            this.ResultsBox.Controls.Add(this.TimesLost);
            this.ResultsBox.Controls.Add(this.TimesPlayedLabel);
            this.ResultsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ResultsBox.Location = new System.Drawing.Point(32, 40);
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.Size = new System.Drawing.Size(263, 139);
            this.ResultsBox.TabIndex = 9;
            this.ResultsBox.TabStop = false;
            this.ResultsBox.Text = "Results";
            // 
            // LossCount
            // 
            this.LossCount.AutoSize = true;
            this.LossCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LossCount.Location = new System.Drawing.Point(159, 108);
            this.LossCount.Name = "LossCount";
            this.LossCount.Size = new System.Drawing.Size(19, 20);
            this.LossCount.TabIndex = 7;
            this.LossCount.Text = "0";
            // 
            // WinCount
            // 
            this.WinCount.AutoSize = true;
            this.WinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinCount.Location = new System.Drawing.Point(159, 68);
            this.WinCount.Name = "WinCount";
            this.WinCount.Size = new System.Drawing.Size(19, 20);
            this.WinCount.TabIndex = 6;
            this.WinCount.Text = "0";
            // 
            // PlayedCount
            // 
            this.PlayedCount.AutoSize = true;
            this.PlayedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayedCount.Location = new System.Drawing.Point(159, 28);
            this.PlayedCount.Name = "PlayedCount";
            this.PlayedCount.Size = new System.Drawing.Size(19, 20);
            this.PlayedCount.TabIndex = 5;
            this.PlayedCount.Text = "0";
            // 
            // StatBox
            // 
            this.StatBox.Enabled = false;
            this.StatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatBox.Location = new System.Drawing.Point(70, 305);
            this.StatBox.Name = "StatBox";
            this.StatBox.ReadOnly = true;
            this.StatBox.Size = new System.Drawing.Size(397, 162);
            this.StatBox.TabIndex = 10;
            this.StatBox.Text = "";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(253, 238);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.ErrorMessage.TabIndex = 11;
            // 
            // ResultsMessage
            // 
            this.ResultsMessage.AutoSize = true;
            this.ResultsMessage.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsMessage.Location = new System.Drawing.Point(388, 152);
            this.ResultsMessage.Name = "ResultsMessage";
            this.ResultsMessage.Size = new System.Drawing.Size(0, 15);
            this.ResultsMessage.TabIndex = 12;
            // 
            // DiceRollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(545, 479);
            this.Controls.Add(this.ResultsMessage);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.StatBox);
            this.Controls.Add(this.ResultsBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GuessEntry);
            this.Controls.Add(this.DiceImage);
            this.Name = "DiceRollForm";
            this.Text = "Dice Roll";
            ((System.ComponentModel.ISupportInitialize)(this.DiceImage)).EndInit();
            this.ResultsBox.ResumeLayout(false);
            this.ResultsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox DiceImage;
        private System.Windows.Forms.Label TimesPlayedLabel;
        private System.Windows.Forms.Label NumberWonLabel;
        private System.Windows.Forms.Label TimesLost;
        private System.Windows.Forms.TextBox GuessEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.GroupBox ResultsBox;
        private System.Windows.Forms.RichTextBox StatBox;
        private System.Windows.Forms.Label LossCount;
        private System.Windows.Forms.Label WinCount;
        private System.Windows.Forms.Label PlayedCount;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label ResultsMessage;
    }
}

