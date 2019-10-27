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
    public partial class ShowPass : Form
    { // Used to show the password for the currently selected entry.
        public ShowPass(string name, string pass)
        {
            InitializeComponent();
            EntryNameLabel.Text = name;
            PassBox.Text = pass;
        }

        private void ShowPass_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
