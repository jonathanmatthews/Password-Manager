namespace Password_Manager
{
    partial class PassBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.DescLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.WarnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(202, 51);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(9, 9);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(121, 13);
            this.DescLabel.TabIndex = 3;
            this.DescLabel.Text = "Password for database: ";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(283, 51);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // WarnLabel
            // 
            this.WarnLabel.AutoSize = true;
            this.WarnLabel.Location = new System.Drawing.Point(210, 9);
            this.WarnLabel.Name = "WarnLabel";
            this.WarnLabel.Size = new System.Drawing.Size(148, 13);
            this.WarnLabel.TabIndex = 5;
            this.WarnLabel.Text = "Unsaved changes will be lost.";
            // 
            // GetString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 81);
            this.Controls.Add(this.WarnLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.textBox1);
            this.Name = "GetString";
            this.Text = "Password";
            this.Load += new System.EventHandler(this.GetString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label WarnLabel;
    }
}