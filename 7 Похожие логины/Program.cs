using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var have = new HashSet<string>();

        for (int i = 0; i < n; ++i)
        {
            string s = Console.ReadLine();
            have.Add(s);

            for (int j = 0; j + 1 < s.Length; ++j)
            {
                char[] charArray = s.ToCharArray();
                char temp = charArray[j];
                charArray[j] = charArray[j + 1];
                charArray[j + 1] = temp;
                string swappedString = new string(charArray);
                have.Add(swappedString);
            }
        }

        int q = int.Parse(Console.ReadLine());

        for (int i = 0; i < q; ++i)
        {
            string s = Console.ReadLine();
            if (have.Contains(s))
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
