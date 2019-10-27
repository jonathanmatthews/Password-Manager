using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager;

namespace Password_Manager // Annoyingly, an underscore was added at some point.
{
    public partial class Passman : Form
    {
        private Data data = null;
        private bool changesMade = false;
        private bool passSet = false; // Whether the master password has been set for this.Data.

        public Passman()
        {
            InitializeComponent();
        }

        private void Passman_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void Passman_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.changesMade && MessageBox.Show(
                "Are you sure you want to close? There are unsaved changes.",
                "Confirm close",
                MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void Populate ()
        { // Populate the listbox in the main window.
            listBox1.Items.Clear();
            foreach (string entry in this.data.GetKeys())
                listBox1.Items.Add(entry);
        }

        private void CheckState ()
        { // Function to be run after an event, to check which buttons should
          // be enabled/disabled.
            
            if (this.data == null)
                return; // Leave in default state.
            
            // Data exists in order to be editable.
            this.AddEntryButton.Enabled = true;
            this.SaveButton.Enabled = true;
            this.AddPassButton.Enabled = this.passSet ? false : true;

            if (this.listBox1.SelectedIndex != -1) // != -1 means something is selected.
            {
                this.RemoveEntryButton.Enabled = true;
                this.EditButton.Enabled = true;
                if (this.passSet == true)
                    this.ShowPassButton.Enabled = true;
            }
            else
            {
                this.RemoveEntryButton.Enabled = false;
                this.EditButton.Enabled = false;
                this.ShowPassButton.Enabled = false;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        { // Function to load passwords from file.
            if (this.changesMade)
            {
                var confirm = MessageBox.Show("Are you sure? You will lose unsaved changes.", "Confirm Load", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No)
                    return;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Data loaded;

                try
                {
                    loaded = Data.Load(openFileDialog.FileName);
                }
                catch // Bad load.
                {
                    MessageBox.Show("Unable to load this data.", "Bad load", MessageBoxButtons.OK);
                    return;
                }

                this.data = loaded;
                this.passSet = false;
                this.SaveButton.Enabled = true;
                this.changesMade = false;
                this.listBox1.SelectedIndex = -1;

                this.Populate();
                this.CheckState();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        { // Create new database and set as current.
            if (this.changesMade)
            {
                var confirm = MessageBox.Show("Are you sure? You will lose unsaved changes.", "Confirm New", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No)
                    return;
            }

            PassBox getPass = new PassBox(this.changesMade);
            getPass.ShowDialog();

            if (getPass.result != "")
            {
                string passwd = getPass.result;
                this.data = new Data(passwd);
                this.passSet = true;
                this.AddPassButton.Enabled = false;
                this.SaveButton.Enabled = true;
                this.changesMade = true;
                this.listBox1.SelectedIndex = -1;

                this.Populate();
                this.CheckState();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        { // Save current database to file.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.data.Save(saveFileDialog.FileName);
                }
                catch // Bad save.
                {
                    MessageBox.Show("Unable to save here.", "Bad save", MessageBoxButtons.OK);
                    return;
                }

                this.changesMade = false;
            }
        }

        private void AddPassButton_Click(object sender, EventArgs e)
        { // Add the master password for the current database.
            PassBox getPass = new PassBox(false);
            getPass.ShowDialog();

            if (getPass.result != "")
            {
                string passwd = getPass.result;
                try
                {
                    this.data.SetPassword(passwd);
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    MessageBox.Show("Password Incorrect.", "Password Incorrect", MessageBoxButtons.OK);
                    return;
                }
                this.AddPassButton.Enabled = false;
                this.passSet = true;

                this.CheckState();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { // index is -1 when nothing selected.
            this.CheckState();
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        { // Store a service and password in the database.
            NamePassBox entry = new NamePassBox();
            entry.ShowDialog();

            if (entry.passResult != "" && entry.nameResult != "")
            {
                if (this.data.GetKeys().Contains(entry.nameResult))
                    MessageBox.Show("A service with this name already exists.", "Name reuse", MessageBoxButtons.OK);
                else
                {
                    this.data[entry.nameResult] = entry.passResult;
                    this.changesMade = true;
                    this.Populate();
                }

                this.listBox1.SelectedIndex = -1;
                this.CheckState();
            }
        }

        private void RemoveEntryButton_Click(object sender, EventArgs e)
        { // Remove an entry from the database.
            var confirm = MessageBox.Show("Are you sure you wish to delete this item?", "Confirm remove", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                return;
            this.data.Remove(this.listBox1.SelectedItem.ToString());
            this.changesMade = true;
            this.listBox1.SelectedIndex = -1;
            this.Populate();
            this.CheckState();
        }

        private void EditButton_Click(object sender, EventArgs e)
        { // Edit the current entry. Display previous password in password field if master password
          // is added, otherwise blank.
            string curr = listBox1.SelectedItem.ToString();
            var entry = new NamePassBox(curr, this.passSet ? this.data[curr] : "");
            entry.ShowDialog();
            if (entry.passResult == "" || entry.nameResult == "")
                return; // If clicked cancel.
            this.data.Remove(listBox1.SelectedItem.ToString()); // Remove old item.
            this.data[entry.nameResult] = entry.passResult;
            this.changesMade = true;
            this.listBox1.SelectedIndex = -1;
            this.Populate();
            this.CheckState();
        }

        private void ShowPassButton_Click(object sender, EventArgs e)
        { // Show the password in a non-editable form for the currently selected entry.
            string selected = listBox1.SelectedItem.ToString();
            ShowPass entry = new ShowPass(selected, this.data[selected]);
            entry.ShowDialog();
        }
    }
}
