using System;
using System.Collections.Generic;

namespace PasswordManager {
    class CLI {
        // Defines the CLI interface. An interface of which should be created and run
        // to provide a command line interface in the Main function.
        private Data data = null;
        private bool changesMade;
        private bool passSet;
        private List<string> options;
        private List<Action> funcs;
        
        public void Run () {
            // Call this function to run the interface.
            while (true) {
                this.GetActions();
                this.DisplayOptions();
            } // Main loop
        } // Run
        
        private void GetActions () {
            // Get the currently available actions based on the state of the interface,
            // and store them and their functions, ready to be run.
            this.options = new List<string>();
            this.funcs = new List<Action>();
            
            // Always available:
            this.options.Add("Exit (Lose any unsaved changes)");
            this.options.Add("Create new database (Lose any unsaved changes)");
            this.options.Add("Load old database (Lose any unsaved changes)");
            
            this.funcs.Add(this.Exit);
            this.funcs.Add(this.NewData);
            this.funcs.Add(this.LoadData);
            
            if (data != null) {
                // Something is loaded, more options available.
                this.options.Add("List services for which passwords are currently stored");
                this.options.Add("Add an entry to the current database");
                
                this.funcs.Add(this.ListEntries);
                this.funcs.Add(this.AddEntry);
                
                if (!this.passSet) {
                    this.options.Add("Enter master password (enable recalling)");
                    this.funcs.Add(this.AddMaster);
                } else {
                    this.options.Add("Recall a password");
                    this.funcs.Add(this.Show);
                }
                
                if (this.changesMade) {
                    this.options.Add("Save changes to file (overwrite without warning)");
                    this.funcs.Add(this.SaveData);
                }
            }
        } // GetActions
        
        private void DisplayOptions () {
            // Display the currently available options to the user and call their
            // chosen function.
            Console.WriteLine("\n\nEnter the number option you wish to choose: ");
            
            for (int i = 0; i < this.options.Count; i++)
                Console.WriteLine("{0}. {1}", i, this.options[i]);
            
            Console.WriteLine("\n");
            string answer = Console.ReadLine().Trim();
            
            try {
                this.funcs[Convert.ToInt32(answer)]();
            } catch (FormatException) { // Bad cast.
                Console.WriteLine("Oops! That wasn't a valid input. Enter only the number, nothing else.");
                this.DisplayOptions();
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Oops! That wasn't a valid input. Enter only the number, nothing else.");
                this.DisplayOptions();
            }
        } // DisplayOptions
        
        private void LoadData () {
            // Function to load data from a saved password database.
            Console.WriteLine("Enter the path to the password database relative to the current working directory: ");
            string path = Console.ReadLine();
            Data loadedData;
            
            try {
                loadedData = Data.Load(path);
            } catch {
                Console.WriteLine("\nFailed to load data.");
                return;
            }
            
            this.data = loadedData;
            this.passSet = false;
            this.changesMade = false;
        } // LoadData
        
        private void NewData () {
            // Function to create new password database and set it as the active database.
            string passwd = "";
            
            while (passwd == "") {
                Console.WriteLine("Enter the password you wish to set for this new database: ");
                passwd = Console.ReadLine();
            }
            
            this.data = new Data(passwd);
            this.passSet = true;
            this.changesMade = true;
        } // NewData
        
        private void ListEntries () {
            // List the currently stored services in the current password database.
            foreach (string entry in this.data.GetKeys())
                Console.WriteLine(entry);
        } // ListEntries
        
        private void AddMaster () {
            // Set the master password for the current database.
            string passwd = "";
            
            while (passwd == "") {
                Console.WriteLine("Enter the master password for this database: ");
                passwd = Console.ReadLine();
            }
            
            try {
                this.data.SetPassword(passwd);
            } catch (System.Security.Cryptography.CryptographicException) {
                Console.WriteLine("Password Incorrect.");
                return;
            }
            
            this.passSet = true;
        } // AddMaster
        
        private void AddEntry () {
            // Add an entry to the current database.
            string name = "";
            string passwd = "";
            
            while (name == "") {
                Console.WriteLine("Enter the name of the service for which this password is for: ");
                name = Console.ReadLine();
            }
            
            while (passwd == "") {
                Console.WriteLine("Enter the password your wish to store for this service: ");
                passwd = Console.ReadLine();
            }
            
            this.changesMade = true;
            this.data[name] = passwd;
        } // AddEntry
        
        private void SaveData () {
            // Save the current database to file, overwriting whatever data was
            // at that location previously.
            string path = "";
            
            while (path == "") {
                Console.WriteLine("Enter the path (including filename) to which you wish to save the current database: ");
                path = Console.ReadLine();
            }
            
            try {
                this.data.Save(path);
            } catch (System.UnauthorizedAccessException) {
                Console.WriteLine("Unable to write to that location.");
                return;
            } catch (System.ArgumentException) {
                Console.WriteLine("Unable to write to that location.");
                return;
            }
            
            this.changesMade = false;
        } // SaveData
        
        private void Exit () {
            // Exit the program.
            Environment.Exit(0);
        } // Exit
        
        private void Show () {
            // Show the password for a given stored service.
            string name = "";
            
            while (name == "") {
                Console.WriteLine("Enter the name of the service for which you wish to view the password: ");
                name = Console.ReadLine();
            }
            
            try {
                Console.WriteLine("Password is: {0}", this.data[name]);
            } catch (System.Collections.Generic.KeyNotFoundException) {
                Console.WriteLine("No password is stored for that service.");
                // If unrecognised service is entered.
            }
        } // Show
    } // CLI
} // PasswordManager
