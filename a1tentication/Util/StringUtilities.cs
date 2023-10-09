using System.Text;

namespace a1tentication.Util;

public class StringUtilities
{
    public static string Hash(string s)
    {
        byte[] secretKey = Encoding.ASCII.GetBytes("sidechain");
        byte[] data = Encoding.ASCII.GetBytes(s);
        var concat = secretKey.Concat(data).ToArray();
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(concat);
        string hash = Encoding.ASCII.GetString(data);
        return hash;
    }

    public static bool Compare(string a, string b)
    {
        return a.ToLower() == b.ToLower();
    }

    public static string PascalToWord(string pascalCase)
    {
        var words = new List<string>();
        var currentWord = new StringBuilder();

        foreach (char c in pascalCase)
        {
            if (char.IsUpper(c))
            {
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }

            currentWord.Append(c);
        }

        if (currentWord.Length > 0)
        {
            words.Add(currentWord.ToString());
        }

        return string.Join(" ", words);
    }
}