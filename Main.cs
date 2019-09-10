using System;
using PasswordManager;
using System.Text; // Remove after testing.

class Program {
    static void Main () {

        
        string testword = "cat";
        string password = "beep2001";
        
        byte[][] result = AES.Encrypt(password, testword);
        byte[] encrypted = result[0];
        byte[] IV = result[1];
        
        Console.WriteLine("cipher text length {0}", encrypted.Length);
        
        string decrypted = AES.Decrypt(password, encrypted, IV);
        
        Console.WriteLine("testword: {0}", testword);
        //Console.WriteLine("encrypted: {0}", ASCIIEncoding.ASCII.GetString(encrypted));
        Console.WriteLine("decrypted: {0}", decrypted);
        
    }
}

// TODO: Look into converting ASCII to UNICODE.
// TODO: Look into RSA padding options.
// TODO: Look into RSA key container.
