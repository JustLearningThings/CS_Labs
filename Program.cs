using lab_1;

int key1 = 0;
int control = 1;
string key2 = "";
string text = "";

Console.WriteLine("Crearea cifrului:");
Console.Write("Cheia > ");
key1 = Int32.Parse(Console.ReadLine());
Console.Write("Cheia 2 (optional) > ");
key2 = Console.ReadLine();
Console.Write("Textul >: ");
text = Console.ReadLine();

Cipher Caesar = new Cipher(key1, key2 == "" ? null : key2);

Console.WriteLine("\n1. Criptare");
Console.WriteLine("2. Decriptare");
Console.Write(">: ");
control = Int32.Parse(Console.ReadLine());

if (control == 1)
    Console.WriteLine("Textul criptat: " + Caesar.Encrypt(text));
else
    Console.WriteLine("Textul decriptat: " + Caesar.Decrypt(text));