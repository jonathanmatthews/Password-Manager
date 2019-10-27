namespace Password_Manager
{
    partial class ShowPass
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
            this.EntryNameLabel = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntryNameLabel
            // 
            this.EntryNameLabel.AutoSize = true;
            this.EntryNameLabel.Location = new System.Drawing.Point(12, 14);
            this.EntryNameLabel.Name = "EntryNameLabel";
            this.EntryNameLabel.Size = new System.Drawing.Size(33, 13);
            this.EntryNameLabel.TabIndex = 0;
            this.EntryNameLabel.Text = "name";
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(12, 35);
            this.PassBox.Name = "PassBox";
            this.PassBox.ReadOnly = true;
            this.PassBox.Size = new System.Drawing.Size(346, 20);
            this.PassBox.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(283, 61);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ShowPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 96);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.EntryNameLabel);
            this.Name = "ShowPass";
            this.Text = "View Password";
            this.Load += new System.EventHandler(this.ShowPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EntryNameLabel;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Button OKButton;
    }
}