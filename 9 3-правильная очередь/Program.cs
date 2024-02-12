using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Solve(int n)
    {
        string s = Console.ReadLine();
        int[] used = new int[n];
        int xx = 0, yy = 0, zz = 0;

        foreach (char c in s)
        {
            if (c == 'X')
                xx++;
            else if (c == 'Y')
                yy++;
            else if (c == 'Z')
                zz++;
        }

        int kx = (xx - yy + zz) / 2;
        int ky = (yy - xx + zz) / 2;
        List<int> x = new List<int>();
        Queue<int> y = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'X')
                x.Add(i);
            else if (s[i] == 'Y')
                y.Enqueue(i);
            else if (s[i] == 'Z')
            {
                used[i] = 1;
                if (y.Count > 0 && ky > 0)
                {
                    used[y.Peek()] = 1;
                    y.Dequeue();
                    ky--;
                }
                else if (y.Count == 0 && x.Count > 0)
                {
                    used[x[x.Count - 1]] = 1;
                    x.RemoveAt(x.Count - 1);
                }
                else if (x.Count > 0)
                {
                    used[x[x.Count - 1]] = 1;
                    x.RemoveAt(x.Count - 1);
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }

        int diff = 0;
        for (int i = 0; i < n; i++)
        {
            if (used[i] == 1)
                continue;

            if (s[i] == 'X')
                diff++;
            else if (s[i] == 'Y')
            {
                diff--;
                if (diff < 0)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }

        Console.WriteLine(diff == 0 ? "Yes" : "No");
    }

    static void Main()
    {
        int tt = int.Parse(Console.ReadLine());
        while (tt-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            Solve(n);
        }
    }
}
