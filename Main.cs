using System;
using PasswordManager;
using System.Text; // Remove after testing.

class Program {
    static void Main () {
        
        string testword = "cactus";
        string password = "beep2001";
        
        Console.WriteLine("started");
        
        byte[] encrypted = AES.Encrypt(password, testword);
        
        Console.WriteLine("encrypt successful");
        Console.WriteLine("cipher text length {0}", encrypted.Length);
        
        //string decrypted = AES.Decrypt(password, encrypted);
        
        //Console.WriteLine("decrypt successful");
        
        //Console.WriteLine("testword: {0}", testword);
        //Console.WriteLine("encrypted: {0}", encrypted);
        //Console.WriteLine("decrypted: {0}", decrypted);
        
    }
}

// TODO: Look into converting ASCII to UNICODE.
// TODO: Look into RSA padding options.
// TODO: Look into RSA key container.
