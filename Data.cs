using System;
using System.Collections.Generic;

namespace PasswordManager {
    class Data {
        /* Provide a class to store the user's passwords in. Passwords will be encrypted
           with RSA public key, generated when a new instance is created. Private key is
           AES encrypted with a password set by user. To decrypt passwords, AES password
           used to obtain the RSA private key, which will then be used to decrypt the
           stored passwords. */
        
        private string pub; // Public RSA key.
        private byte[] priv; // AES encrypted private key.
        private Dictionary<string, byte[]> passwords;
        private byte[] testEncrypted; // Test string, to attempt to decrypt.
        private const string test = "This string exists to be encrypted on creation of a new instance of this class. When loading an instance from file, the saved string can be decrypted, and if correct, the entered password can be assumed to be correct.";
        private string userPassword = null; // NOT to be written to file.
        
        public Data (string userPassword) {
            // Constructor, create a blank password storage object.
            string[] rsaKeys = RSA.KeyGen();
            this.pub = rsaKeys[0];
            this.priv = AES.Encrypt(userPassword, rsaKeys[1]); // Encrypt and store private key.
            this.testEncrypted = AES.Encrypt(userPassword, Data.test);
            this.userPassword = userPassword;
            this.passwords = new Dictionary<string, byte[]>();
        } // Data (constructor)
        
        public string this[string index] {
            // Define the indexing operator, to access and create/change passwords
            // in the dictionary.
            
            get {
                if (this.userPassword != null)
                    return RSA.Decrypt(AES.Decrypt(this.userPassword, this.priv), passwords[index]); // AES not functional yet, untested.
                else
                    throw new Exception("AES password has not been given.");
            } // get
            
            set {
                try { this.passwords.Add(index, RSA.Encrypt(this.pub, value)); }
                catch (ArgumentException) { // Key already exists, so change entry rather than create.
                    this.passwords[index] = RSA.Encrypt(this.pub, value); }
            } // set
        } // this[]
        
        public void SetPassword (string userPassword) {
            // Set the user's AES key for the password dictionary, after
            // checking that the password is correct. Raise error if not correct.
            
            string testDecrypted = AES.Decrypt(userPassword, this.testEncrypted);
            if (testDecrypted == Data.test)
                this.userPassword = userPassword;
            
            else
                throw new Exception("AES password is incorrect.");
        } // SetPassword
        
        // TODO: save/load functions, after correcting AES encryption fault.
        // Can potentially be done with serialisation.
        
        public void Save () {
            // DoStuff()
        } // Save
        
        public void Load () {
            // Change return type to Data, after completing function.
            // DoStuff()
        } // Load
        
        
    } // Data
} // PasswordManager
