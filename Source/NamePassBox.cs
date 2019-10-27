using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class NamePassBox : Form
    { // User to get password + name for an entry.
        public string nameResult = ""; // The results to be read after the form closes.
        public string passResult = "";

        public NamePassBox()
        { // Overloaded constructor, if name and pass are not known.
            InitializeComponent();
        }

        public NamePassBox(string name, string pass)
        { // Name and pass are the current parameters, if known, of the entry being edited.
            this.nameResult = name;
            this.passResult = pass;
            InitializeComponent();
        }

        private void NamePassBox_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.ControlBox = false;
            if (this.nameResult == "" && this.passResult == "")
                this.OKButton.Enabled = false;
            else
            {
                this.NameBox.Text = this.nameResult;
                this.PassBox.Text = this.passResult;
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        { // Only enable OK button if name and pass fields are empty.
            if (this.NameBox.Text != "" && this.PassBox.Text != "")
                this.OKButton.Enabled = true;
            else
                this.OKButton.Enabled = false;
        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        { // Only enable OK button if name and pass fields are empty.
            if (this.NameBox.Text != "" && this.PassBox.Text != "")
                this.OKButton.Enabled = true;
            else
                this.OKButton.Enabled = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        { // Close the application and set results to empty.
          // Empty results should imply to the caller that the cancel button was pressed.
            this.nameResult = "";
            this.passResult = "";
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        { // Store text in result fields.
            this.nameResult = this.NameBox.Text;
            this.passResult = this.PassBox.Text;
            this.Close();
        }
    }
}
