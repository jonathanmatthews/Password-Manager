namespace Password_Manager
{
    partial class Passman
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AddEntryButton = new System.Windows.Forms.Button();
            this.RemoveEntryButton = new System.Windows.Forms.Button();
            this.AddPassButton = new System.Windows.Forms.Button();
            this.ShowPassButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(95, 230);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.AllowDrop = true;
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(176, 230);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save As";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(12, 230);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 212);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // AddEntryButton
            // 
            this.AddEntryButton.Enabled = false;
            this.AddEntryButton.Location = new System.Drawing.Point(176, 81);
            this.AddEntryButton.Name = "AddEntryButton";
            this.AddEntryButton.Size = new System.Drawing.Size(84, 23);
            this.AddEntryButton.TabIndex = 5;
            this.AddEntryButton.Text = "Add Entry";
            this.AddEntryButton.UseVisualStyleBackColor = true;
            this.AddEntryButton.Click += new System.EventHandler(this.AddEntryButton_Click);
            // 
            // RemoveEntryButton
            // 
            this.RemoveEntryButton.Enabled = false;
            this.RemoveEntryButton.Location = new System.Drawing.Point(176, 110);
            this.RemoveEntryButton.Name = "RemoveEntryButton";
            this.RemoveEntryButton.Size = new System.Drawing.Size(84, 23);
            this.RemoveEntryButton.TabIndex = 6;
            this.RemoveEntryButton.Text = "Remove Entry";
            this.RemoveEntryButton.UseVisualStyleBackColor = true;
            this.RemoveEntryButton.Click += new System.EventHandler(this.RemoveEntryButton_Click);
            // 
            // AddPassButton
            // 
            this.AddPassButton.Enabled = false;
            this.AddPassButton.Location = new System.Drawing.Point(176, 12);
            this.AddPassButton.Name = "AddPassButton";
            this.AddPassButton.Size = new System.Drawing.Size(84, 35);
            this.AddPassButton.TabIndex = 7;
            this.AddPassButton.Text = "Add Master Password";
            this.AddPassButton.UseVisualStyleBackColor = true;
            this.AddPassButton.Click += new System.EventHandler(this.AddPassButton_Click);
            // 
            // ShowPassButton
            // 
            this.ShowPassButton.Enabled = false;
            this.ShowPassButton.Location = new System.Drawing.Point(176, 168);
            this.ShowPassButton.Name = "ShowPassButton";
            this.ShowPassButton.Size = new System.Drawing.Size(84, 23);
            this.ShowPassButton.TabIndex = 8;
            this.ShowPassButton.Text = "Show Entry";
            this.ShowPassButton.UseVisualStyleBackColor = true;
            this.ShowPassButton.Click += new System.EventHandler(this.ShowPassButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(176, 139);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(84, 23);
            this.EditButton.TabIndex = 9;
            this.EditButton.Text = "Edit Entry";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // Passman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 263);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ShowPassButton);
            this.Controls.Add(this.AddPassButton);
            this.Controls.Add(this.RemoveEntryButton);
            this.Controls.Add(this.AddEntryButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Name = "Passman";
            this.Text = "Passman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Passman_FormClosing);
            this.Load += new System.EventHandler(this.Passman_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button AddEntryButton;
        private System.Windows.Forms.Button RemoveEntryButton;
        private System.Windows.Forms.Button AddPassButton;
        private System.Windows.Forms.Button ShowPassButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}