# Password-Manager
A password manager that encrypts passwords using RSA, and then encrypts the RSA private key
with AES, with a user defined master password.This is such that passwords can be saved
without entering the master password, but can only be recalled after the master password
has been given.

This probably isn't a particularly useful feature on its own, for most people, but it sounded
like an interesting thing to implement, so I thought I'd give it a go.

#Compiling
I've tested it with Mono on Pop-OS, and so to compile it on a platform similar to mine
using Mono, use something similar to: 
`$ mcs Main.cs Data.cs Encryption.cs -out:passman.exe`

To run, simply use:
`& mono passman.exe`
