using lab_1;

Cipher caesar = new Cipher(3);
Console.WriteLine(caesar.Encrypt("hello!)")); // shouldn't return
Console.WriteLine(caesar.Encrypt("cifrul cezar")); // FLIUXOFHCDU

caesar = new Cipher(17);
Console.WriteLine(caesar.Decrypt("SILKVWFITVRKKRTB"));

Cipher caesarWithSecondKey = new Cipher(3, "cryptography");
Console.WriteLine(caesarWithSecondKey.Encrypt("cifrul cezar")); // FLIUXOFHCDU