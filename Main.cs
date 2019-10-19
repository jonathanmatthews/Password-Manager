using System;
using PasswordManager;

class Program {
    static void Main () {
        var cli = new CLI();
        cli.Run();
    }
}

// TODO: Look into converting ASCII to UNICODE.
// TODO: Look into RSA padding options.
// TODO: Look into RSA/AES key container.
