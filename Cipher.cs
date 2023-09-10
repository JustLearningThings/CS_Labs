using System.Text;

namespace lab_1;

public class Cipher
{
    private Dictionary<char, char> _cryptogram = new();
    private Dictionary<char, char> _reversed_cryptogram = new();
    private int _key { get; set; }
    private string? _key2 { get; set; }

    public Cipher(int key, string? key2 = null)
    {
        _key = key;
        _key2 = key2;

        _initCryptogram(key2 != null);
    }

    public string Encrypt(string text)
    {
        string result = "";
        text = text.ToUpper();
        text = text.Replace(" ", "");

        if (!_isValid(text))
            return "All characters must be between 'A' and 'Z', as well as between 'a' and 'z'!";

        // encryption
        for (int i = 0; i < text.Length; i++)
        {
            result += _cryptogram[text[i]];
        }
        
        return result;
    }

    public string Decrypt(string text)
    {
        string result = "";
        text = text.ToUpper();
        text = text.Replace(" ", "");

        if (!_isValid(text))
            return "All characters must be between 'A' and 'Z', as well as between 'a' and 'z'!";

        // decryption
        for (int i = 0; i < text.Length; i++)
        {
            result += _reversed_cryptogram[text[i]];
        }
        
        return result;
    }

    private void _initCryptogram(bool shouldCreateKey2 = false)
    {
        if (shouldCreateKey2)
        {
            char[] keys = new char[26];
            char[] values = new char[26];
            StringBuilder strBuilder = new();
            HashSet<char> seen = new();
            string duplicateFreeKey2 = "";
            int k = 0;

            foreach (char c in _key2)
            {
                if (!seen.Contains(c))
                {
                    duplicateFreeKey2 += Char.ToUpper(c);
                    seen.Add(c);
                }
            }

            seen = new();

            for (int i = 0; i < 26; i++)
            {
                char letter = Char.ToUpper((char)((int)'a' + i));

                _cryptogram[letter] = ' ';
            }

            keys = _cryptogram.Keys.ToArray();

            // insert key in the cryptogram
            for (int i = 0; i < duplicateFreeKey2.Length; i++)
            {
                _cryptogram[keys[i]] = duplicateFreeKey2[i];
                seen.Add(duplicateFreeKey2[i]);

                k = i;
            }

            k++;
            
            // insert the rest of the alphabet
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (!seen.Contains(c))
                {
                    _cryptogram[keys[k]] = c;
                    seen.Add(c);

                    k++;
                }
            }
            
            // create the reverse cryptogram
            values = _cryptogram.Values.ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                _reversed_cryptogram[values[i]] = keys[i];
            }
        }
        else
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                int newCharInt = ((((int)c - 'A') + _key) % 26 + 26) % 26 + 'A';
                char newChar = (char)newCharInt;

                _cryptogram[c] = newChar;
                _reversed_cryptogram[newChar] = c;
            }
        }
    }

    private bool _isValid(string text)
    {
        foreach (char c in text)
        {
            if (c < 'A' || c > 'Z')
                return false;
        }

        return true;
    }
    private char[]? Permute(char[] chars)
    {


        return chars;
    }
}