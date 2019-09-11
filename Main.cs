using System;
using PasswordManager;

class Program {
    static void Main () {
        
        string password = "SuperSecurePassword";
        string path = "/home/jon/Desktop/Test.passwd";
        
        Data passman = new Data(password);
        
        Console.WriteLine("created");
        
        passman["website1"] = "bobbly";
        passman["website2"] = "bubbly";
        
        Console.WriteLine("stored");
        
        passman.Save("/home/jon/Desktop/Test.passwd");
        
        Console.WriteLine("saved");
        
        Data reassembled = Data.Load(path);
        
        Console.WriteLine("reassembled");
        
        reassembled.SetPassword(password);
        
        foreach (string key in reassembled.GetKeys())
            Console.WriteLine(reassembled[key]);
        
    }
}

// TODO: Look into converting ASCII to UNICODE.
// TODO: Look into RSA padding options.
// TODO: Look into RSA/AES key container.
