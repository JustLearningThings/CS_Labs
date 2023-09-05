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

        // dencryption
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
            char[] alphabet = new char[26];

            for (int i = 0; i < 26; i++)
                alphabet[i] = (char)((int)'a' + i);

            // remove duplicate letters in _key2
            string duplicateFreeKey2 = _removeDuplicates();

            // input the rest of the characters
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (!_cryptogram.Keys.ToArray().Contains(c))
                {
                    _cryptogram[c] = ' ';
                }
            }
            
            // create the reversed alphabet (permute the original alphabet)
            char[] keys = _cryptogram.Keys.ToArray();
            char[] permutedKeys = _cryptogram.Keys.ToArray();
//            permutedKeys = Permute(permutedKeys, 0, permutedKeys.Length - 1);

            for (int i = 0; i < _cryptogram.Count; i++)
            {
                _cryptogram[keys[i]] = permutedKeys[i];
                _reversed_cryptogram[permutedKeys[i]] = keys[i];
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

    private string _removeDuplicates()
    {
        StringBuilder strBuilder = new();
        HashSet<char> seen = new();
        string duplicateFreeKey2 = "";

        foreach (char c in _key2)
        {
            if (!seen.Contains(c))
            {
                duplicateFreeKey2 += c;
                seen.Add(c);
            }
        }
        
        // input the key first in the alphabet
        for (int i = 0; i < duplicateFreeKey2.Length; i++)
        {
            _cryptogram[duplicateFreeKey2[i]] = ' ';
        }

        return duplicateFreeKey2;
    }

    private char[]? Permute(char[] chars, int l, int r)
    {
        if (l == r)
            return chars;

        for (int i = l; i <= r; i++)
        {
            (chars[l], chars[i]) = (chars[i], chars[l]);
            Permute(chars, l + 1, r);
            (chars[l], chars[i]) = (chars[i], chars[l]);
        }

        return null;
    }
}