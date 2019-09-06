using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager {
    static class Encryption {
        
        public static string[] KeyGen () {
            // Generate a pair of RSA keys in XML format.
            string priv;
            string pub;
            
            //var parameters = new CspParameters(1); // RSA Full.
            //parameters.Flags = CspProviderFlags.UseMachineKeyStore;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                priv = rsa.ToXmlString(true);
                pub = rsa.ToXmlString(false);
            } // Using RSA
            
            return new string[] {pub, priv};
        } // KeyGen
        
        public static byte[] Encrypt(string pubKey, string data) {
            // Encrypt a string in XML format using XML format pubKey.
            byte[] encryptedDataBytes;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(pubKey);
                byte[] dataBytes = ASCIIEncoding.ASCII.GetBytes(data);
                encryptedDataBytes = rsa.Encrypt(dataBytes, true); // Not sure about padding bool.
            }
            
            return encryptedDataBytes;
        } // Encrypt
        
        public static string Decrypt (string privKey, byte[] encryptedDataBytes) {
            // Decrypt byte array of encrypted string using XML format privKey.
            string data;
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                rsa.FromXmlString(privKey);
                byte[] dataBytes = rsa.Decrypt(encryptedDataBytes, true);
                data = ASCIIEncoding.ASCII.GetString(dataBytes);
            }
            
            return data;
        } // Decrypt
        
    } // Encryption
} // PasswordManager
