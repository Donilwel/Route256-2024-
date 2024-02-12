using System;
using System.Collections.Generic;

class Program
{
    static void Solve(int n)
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        List<int> curr = new List<int>();
        for (int i = 0; i < n; i++)
        {
            curr.Add(i);
        }

        int[] ans = new int[n];

        for (int k = 1; k <= n; k++)
        {
            List<int> will = new List<int>();
            int cnt = 0;

            foreach (int i in curr)
            {
                if (i - k >= 0 && i + k < n && a[i - k] < a[i - k + 1] && a[i + k - 1] > a[i + k])
                {
                    if (cnt == 0)
                    {
                        cnt = 1;
                    }
                    else
                    {
                        if (will.Count > 0 && will[will.Count - 1] + 2 * k == i)
                        {
                            cnt++;
                        }
                        else
                        {
                            cnt = 1;
                        }
                    }

                    will.Add(i);
                    ans[k - 1] = Math.Max(ans[k - 1], cnt);
                }
            }

            curr = will;
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write(ans[i] + " ");
        }
        Console.WriteLine();
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
