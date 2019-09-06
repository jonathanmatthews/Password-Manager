using System;

class Program {
    static void Main () {
        string[] keys;
        keys = Encryption.KeyGen();
        
        Console.WriteLine(keys[0]);
        Console.Write("\n\n");
        Console.WriteLine(keys[1]);
    }
}
