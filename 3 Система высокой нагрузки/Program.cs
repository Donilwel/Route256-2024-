using System;

class Program
{
    static void Checker(string s)
    {
        if (s[0] != 'M' || s[s.Length - 1] != 'D')
        {
            Console.WriteLine("NO");
            return;
        }

        int on = 1;
        for (int i = 1; i < s.Length; ++i)
        {
            if (s[i] == 'M')
            {
                if (on == 1)
                {
                    Console.WriteLine("NO");
                    return;
                }

                on = 1;
            }
            else if (s[i] == 'R')
            {
                if (on == 0 || s[i-1] == 'R')
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            else if (s[i] == 'C')
            {
                if (on == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                on = 0;
            }
            else if (s[i] == 'D')
            {
                if (on == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                on = 0;
            }
        }

        if (on == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    public static void Main()
    {
        int tt = int.Parse(Console.ReadLine());

        for (int t = 0; t < tt; t++)
        {
            string s = Console.ReadLine();
            Checker(s);
        }
    }
}
