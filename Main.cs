using System;
using PasswordManager;
using System.Text;

class Program {
    static void Main () {
        string[] keys;
        keys = Encryption.KeyGen(); // {pub, priv}
        
        string testWord = "cactus";
        
        byte[] encrypted = Encryption.Encrypt(keys[0], testWord);
        string decrypted = Encryption.Decrypt(keys[1], encrypted);
        
        
        /*
        Console.WriteLine(keys[0]);
        Console.Write("\n\n");
        Console.WriteLine(keys[1]);
        */
        
        Console.WriteLine("unencrypted: {0}", testWord);
        Console.WriteLine("encrypted: {0}", ASCIIEncoding.ASCII.GetString(encrypted));
        Console.WriteLine("decrypted: {0}", decrypted);
    }
}
