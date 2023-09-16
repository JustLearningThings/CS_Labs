using lab_1;

int key1 = 0;
string key2 = "", text = "", control = "";

Console.Write("Cheia 1: ");
key1 = Int32.Parse(Console.ReadLine());

if (key1 < 0 || key1 > 25)
{
    Console.WriteLine("Cheia 1 trebuie sa fie intre 0 si 25!");
    
    Environment.Exit(0);
}

Console.Write("Cheia 2 (optional): ");
key2 = Console.ReadLine();

if (key2.Length < 7)
{
    Console.WriteLine("Cheia 2 trebuie sa aiba o lungime nu mai mica de 7!");
    
    Environment.Exit(0);
}

Console.Write("Textul: ");
text = Console.ReadLine();

Cipher Caesar = new Cipher(key1, key2 == "" ? null : key2);
Caesar.printAlphabet();

Console.WriteLine("1. Criptare");
Console.WriteLine("2. Decriptare");
Console.Write("> ");
control = Console.ReadLine();

if (control == "1")
    Console.WriteLine("Criptare\n" + text + " --> " + Caesar.Encrypt(text));
else
    Console.WriteLine("Decriptare\n" + text + " --> " + Caesar.Decrypt(text));