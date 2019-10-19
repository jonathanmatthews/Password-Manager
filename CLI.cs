using System;
using System.Collections.Generic;

namespace PasswordManager {
    class CLI {
        //
        private Data data = null;
        private bool changesMade;
        private bool passSet;
        private List<string> options;
        private List<Action> funcs;
        
        
        public void Run () {
            //
            while (true) {
                this.GetActions();
                this.DisplayOptions();
            }
            
        } // Run
        
        
        private void GetActions () {
            //
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
            //
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
            //
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
            //
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
            //
            foreach (string entry in this.data.GetKeys())
                Console.WriteLine(entry);
        } // ListEntries
        
        private void AddMaster () {
            //
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
            //
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
            //
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
        }
        
        private void Exit () {
            //
            Environment.Exit(0);
        }
        
        private void Show () {
            //
            string name = "";
            
            while (name == "") {
                Console.WriteLine("Enter the name of the service for which you wish to view the password: ");
                name = Console.ReadLine();
            }
            
            try {
                Console.WriteLine("Password is: {0}", this.data[name]);
            } catch (System.Collections.Generic.KeyNotFoundException) {
                Console.WriteLine("No password is stored for that service.");
            }
        }
    
    
    
    } // CLI
} // PasswordManager
