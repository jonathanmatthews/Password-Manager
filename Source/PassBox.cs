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
    public partial class PassBox : Form
    { // Form exclusively used to get a password for database.
        public string result = "";
        // If result is an empty string, new database won't be created.
        public PassBox(bool warn)
        { // Warn, if true, will display top-right warning about unsaved changes. (when creating new DB)
            InitializeComponent();
            this.WarnLabel.Visible = warn;
        }

        private void GetString_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.OkButton.Enabled = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.result = textBox1.Text;

            if (textBox1.Text != "") // Only enable "OK" for non-empty password.
                this.OkButton.Enabled = true;
            else
                this.OkButton.Enabled = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.result = textBox1.Text;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        { // Clear result field if cancel. Caller should expect result to be empty if cancel.
            this.result = "";
            this.Close();
        }
    }
}
