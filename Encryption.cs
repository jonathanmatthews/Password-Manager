using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace PasswordManager {
    static class RSA {
        // Class to act as a simple interface to RSA encryption/decryption and key generation.
        
        public static string[] KeyGen () {
            // Generate a pair of RSA keys in XML format.
            string priv;
            string pub;
            
            //var parameters = new CspParameters(1); // RSA Full.
            //parameters.Flags = CspProviderFlags.UseMachineKeyStore;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                priv = rsa.ToXmlString(true);
                pub = rsa.ToXmlString(false);
            } // Using rsa
            
            return new string[] {pub, priv};
        } // RSA.KeyGen
        
        public static byte[] Encrypt(string pubKey, string data) {
            // Encrypt a string in XML format using XML format pubKey.
            byte[] encryptedDataBytes;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(pubKey);
                byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(data);
                encryptedDataBytes = rsa.Encrypt(dataBytes, true); // Not sure about padding bool.
            }
            
            return encryptedDataBytes;
        } // RSA.Encrypt
        
        public static string Decrypt (string privKey, byte[] encryptedDataBytes) {
            // Decrypt byte array of encrypted string using XML format privKey.
            string data;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(privKey);
                byte[] dataBytes = rsa.Decrypt(encryptedDataBytes, true);
                data = ASCIIEncoding.ASCII.GetString(dataBytes);
            }
            
            return data;
        } // RSA.Decrypt
    } // RSA
    
    
    
    
    
    
    
    
    
    
    static class AES {
        // Class to act as a simple interface to AES encryption/decryption.
        // Currently not functional. See AES.Encrypt().
        
        public static byte[] Encrypt (string key, string data) {
            // Encrypt an ASCII string with AES.
            
            byte[] encryptedDataBytes;
            
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(key);
                byte[] keyBytesHashed = md5.ComputeHash(keyBytes); // Obtain 128-bit key from any length password.
                aes.Key = keyBytesHashed;
                
                // Hashing is correct, I think.
                // Problem exists after this point, returned byte array is of length 0.
                
                ICryptoTransform encryptor = aes.CreateEncryptor();
                
                using (MemoryStream memStr = new MemoryStream()) { // This looks ridiculous.
                    using (CryptoStream cryptStr = new CryptoStream(memStr, encryptor, CryptoStreamMode.Write)) {
                        using (StreamWriter cryptStrWriter = new StreamWriter(cryptStr)) {
                            cryptStrWriter.Write(data); // Encrypt data by writing to crypto stream, store in memory stream.
                            encryptedDataBytes = memStr.ToArray(); // Create byte array from memory stream.
                        }
                    }
                }
            }
            return encryptedDataBytes;
        } // AES.Encrypt
        
        
        
        
        public static string Decrypt (string key, byte[] encryptedDataBytes) {
            // Decrypt an ASCII string with AES.
            string data;
            
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider()) {
                
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(key);
                byte[] keyBytesHashed = md5.ComputeHash(keyBytes); // Obtain 128-bit key from any length password.
                aes.Key = keyBytesHashed;
                
                ICryptoTransform decryptor = aes.CreateDecryptor();
                
                using (MemoryStream memStr = new MemoryStream(encryptedDataBytes)) {
                    using (CryptoStream cryptStr = new CryptoStream(memStr, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader cryptStrReader = new StreamReader(cryptStr)) {
                            data = cryptStrReader.ReadToEnd(); // Extract data from memory stream, deciphered through crypto stream.
                        }
                    }
                }
            }
            return data;
        } // AES.Decrypt
        
    } // AES
    
} // PasswordManager






















