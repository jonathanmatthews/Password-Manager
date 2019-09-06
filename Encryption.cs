using System;
using System.Security.Cryptography;
using System.Text;

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
    

} // Encryption
