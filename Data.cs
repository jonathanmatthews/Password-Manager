using System;
using System.IO;
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
        private byte[] privIV;
        
        private const string test = "This string exists to be encrypted on creation of a new instance of this class. When loading an instance from file, the saved string can be decrypted, and if correct, the entered password can be assumed to be correct.";
        private byte[] testEncrypted; // Test string, to attempt to decrypt.
        private byte[] testEncryptedIV;
        
        private Dictionary<string, byte[]> passwords;
        private string userPassword = null; // NOT to be written to file.
        
        public Data (string userPassword) {
            // Constructor, create a blank password storage object.
            string[] rsaKeys = RSA.KeyGen();
            byte[][] aesResultPriv = AES.Encrypt(userPassword, rsaKeys[1]); // Encrypt private key.
            
            this.pub = rsaKeys[0];
            this.priv = aesResultPriv[0];
            this.privIV = aesResultPriv[1];
            
            byte[][] aesResultTest = AES.Encrypt(userPassword, Data.test);
            this.testEncrypted = aesResultTest[0];
            this.testEncryptedIV = aesResultTest[1];
            
            this.userPassword = userPassword;
            this.passwords = new Dictionary<string, byte[]>();
        } // Data (constructor)
        
        private Data (string pub, byte[] priv, byte[] privIV, byte[] testEncrypted, byte[] testEncryptedIV) {
            // Overloaded constructor intended for use with Data.Load(), in order to load
            // a database without knowing the AES key.
            this.pub = pub;
            this.priv = priv;
            this.privIV = privIV;
            this.testEncrypted = testEncrypted;
            this.testEncryptedIV = testEncryptedIV;
            this.passwords = new Dictionary<string, byte[]>();
        } // Data (second constructor)
        
        public string this[string index] {
            // Define the indexing operator, to access and create/change passwords
            // in the dictionary.
            
            get {
                if (this.userPassword != null)
                    return RSA.Decrypt(AES.Decrypt(this.userPassword, this.priv, this.privIV), passwords[index]); // AES not functional yet, untested.
                else
                    throw new Exception("AES password has not been given.");
            }
            
            set {
                try { this.passwords.Add(index, RSA.Encrypt(this.pub, value)); }
                catch (ArgumentException) { // Key already exists, so change entry rather than create.
                    this.passwords[index] = RSA.Encrypt(this.pub, value); }
            }
        } // this[]
        
        public void SetPassword (string userPassword) {
            // Set the user's AES key for the password dictionary, after
            // checking that the password is correct. Raise error if not correct.
            
            try {
                string testDecrypted = AES.Decrypt(userPassword, this.testEncrypted, this.testEncryptedIV);
                // I'm not sure if a wrong password could potentially still lead to the decryption succeeding,
                // but with a wrong result, so put this comparison here to prevent that.
                
                if (testDecrypted == Data.test)
                    this.userPassword = userPassword;
                else
                    throw new System.Security.Cryptography.CryptographicException("AES password is incorrect.");
            }
            
            catch (System.Security.Cryptography.CryptographicException) {
                // If bad padding detected, password is probably wrong.
                throw new System.Security.Cryptography.CryptographicException("AES password is incorrect.");   
            }
        } // SetPassword
        
        public List<string> GetKeys () {
            // Function to return a list of keys for the password database.
            return new List<string>(this.passwords.Keys);
        } // GetKeys
        
        public void Save (string filepath) {
            /* Create a large string containing all data in the object, with each entry separated
               by a new line, then store that string in a text file to later be read back.
               Will overwrite filepath without warning. Filepath must be relative to current
               working directory, and is the location to save the data to.*/
            List<string> lines = new List<string>();
            
            // Add known fields:
            lines.Add(this.pub);
            lines.Add(BitConverter.ToString(this.priv));
            lines.Add(BitConverter.ToString(this.privIV));
            lines.Add(BitConverter.ToString(this.testEncrypted));
            lines.Add(BitConverter.ToString(this.testEncryptedIV));
            
            // Add password dictionary:
            foreach (string key in this.passwords.Keys) {
                lines.Add(key);
                lines.Add(BitConverter.ToString(this.passwords[key]));
            }
            
            // Join strings.
            string result = "";
            foreach (string line in lines)
                result += (line + "\n");
            
            // Store data.
            File.WriteAllText(filepath, result);
        } // Save
        
        private static byte[] HexToByte (string hex) {
            // A function to convert a hexadecimal string into a byte array, such as that
            // produced by Data.Save().
            string[] splitted = hex.Split( new char[] {'-'} );
            List<byte> bytes = new List<byte>();
            
            foreach (string b in splitted)
                bytes.Add(Convert.ToByte(b, 16));
            
            return bytes.ToArray();
        } // HexToBytes
        
        public static Data Load (string filepath) {
            // Load a text file created by Data.Save and return the reproduced object to which
            // that data pertains.
            
            string fromFile = File.ReadAllText(filepath);
            string[] lines = fromFile.Split( new char[] {'\n'} );
            
            Data reconstructed = new Data(
                lines[0], // pub
                Data.HexToByte(lines[1]), // priv
                Data.HexToByte(lines[2]), // privIV
                Data.HexToByte(lines[3]), // testEncrypted
                Data.HexToByte(lines[4])  // testEncryptedIV
            );
            
            for (int i = 5; i < lines.Length - 1; i += 2) // -1 to ignore blank line at end.
                reconstructed.passwords.Add(lines[i], Data.HexToByte(lines[i+1])); // Lines alternate between key and value.
                
                //reconstructed[lines[i]] = Data.HexToByte(lines[i+1]);
            
            return reconstructed;
        } // Load
    } // Data
} // PasswordManager
