using System;

namespace PasswordManager {
    class CLI {
        //
        private Data data = null;
        private bool changesMade = false;
        private bool passSet = null;
        
        
        public void Run () {
            //
            
            
            
            
        } // Run
        
        
        
    
        static private void DisplayOptions () {
            //
            
        } // DisplayOptions
    
    
    
        private void LoadData () {
            //
            Console.WriteLine("Enter the path to the password database relative to the current working directory: ");
            string path = Console.ReadLine();
            this.data = Data.Load(path);
            this.passSet = false;
        } // LoadData
        
        private void NewData () {
            //
            Console.WriteLine("Enter the password you wish to set for this new database: ");
            string passwd = Console.RealLine();
            this.data = new Data(passwd);
            this.passSet = true;
        } // NewData
        
        private void ListEntries () {
            //
            foreach (string entry in this.data.GetKeys())
                Console.WriteLine(entry);
        } // ListEntries
        
        private void AddMaster () {
            //
            Console.WriteLine("Enter the master password for this database: ");
            string passwd = Console.ReadLine();
            this.data.SetPassword(passwd);
            this.passSet = true;
        } // AddMaster
        
        private void AddEntry () {
            //
            Console.WriteLine("Enter the name of the service for which this password is for: ");
            string name = Console.ReadLine();
            Console.WriteLine(("Enter the password your wish to store for this service: ");
            string passwd = Console.ReadLine();
            
            this.data[name] = passwd;
        } // AddEntry
        
        private void SavaData () {
            //
            Console.WriteLine("Enter the path (including filename) to which you wish to save the current database: ");
            string path = Console.ReadLine();
            this.data.Save(path);
        }
        
        private void Exit () {
            //
            Environment.Exit(0);
        }
        
        private Show () {
            //
            Console.WriteLine("Enter the name of the service for which you wish to view the password: ");
            string name = Console.ReadLine();
            Console.WriteLine("Password is: {0}", this.data[name]);
        }
    
    
    
    } // CLI
} // PasswordManager
