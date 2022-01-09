
namespace SimpleExamples
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompanyCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.GetSelectedButton = new System.Windows.Forms.Button();
            this.CompanyListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CompanyCheckedListBox
            // 
            this.CompanyCheckedListBox.FormattingEnabled = true;
            this.CompanyCheckedListBox.Location = new System.Drawing.Point(25, 12);
            this.CompanyCheckedListBox.Name = "CompanyCheckedListBox";
            this.CompanyCheckedListBox.Size = new System.Drawing.Size(208, 274);
            this.CompanyCheckedListBox.TabIndex = 0;
            // 
            // GetSelectedButton
            // 
            this.GetSelectedButton.Location = new System.Drawing.Point(25, 292);
            this.GetSelectedButton.Name = "GetSelectedButton";
            this.GetSelectedButton.Size = new System.Drawing.Size(208, 23);
            this.GetSelectedButton.TabIndex = 1;
            this.GetSelectedButton.Text = "Get selected";
            this.GetSelectedButton.UseVisualStyleBackColor = true;
            this.GetSelectedButton.Click += new System.EventHandler(this.GetSelectedButton_Click);
            // 
            // CompanyListBox
            // 
            this.CompanyListBox.FormattingEnabled = true;
            this.CompanyListBox.ItemHeight = 15;
            this.CompanyListBox.Location = new System.Drawing.Point(239, 12);
            this.CompanyListBox.Name = "CompanyListBox";
            this.CompanyListBox.Size = new System.Drawing.Size(208, 274);
            this.CompanyListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompanyListBox);
            this.Controls.Add(this.GetSelectedButton);
            this.Controls.Add(this.CompanyCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code samples";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CompanyCheckedListBox;
        private System.Windows.Forms.Button GetSelectedButton;
        private System.Windows.Forms.ListBox CompanyListBox;
        private System.Windows.Forms.Label label1;
    }
}

