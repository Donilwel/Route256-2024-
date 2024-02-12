using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int tt = int.Parse(Console.ReadLine());
        
        while (tt-- > 0)
        {
            string[] nm = Console.ReadLine().Split();
            Solve(nm);
        }
    }

    static void Solve(string[] nm)
    {
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        List<string> table = new List<string>();
        for (int i = 0; i < n; ++i)
        {
            table.Add(Console.ReadLine());
        }

        int was = 0;
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                if (table[i][j] == 'A')
                {
                    if (was == 0)
                    {
                        was = 1;
                        int y = i, x = j;
                        while (!(y == 0 && x == 0))
                        {
                            if (y > 0 && table[y - 1][x] == '.')
                            {
                                y--;
                                table[y] = table[y].Substring(0, x) + 'a' + table[y].Substring(x + 1);
                            }
                            if (x > 0 && table[y][x - 1] == '.')
                            {
                                x--;
                                table[y] = table[y].Substring(0, x) + 'a' + table[y].Substring(x + 1);
                            }
                        }
                    }
                    else
                    {
                        int y = i, x = j;
                        while (!(y == n - 1 && x == m - 1))
                        {
                            if (y < n - 1 && table[y + 1][x] == '.')
                            {
                                y++;
                                table[y] = table[y].Substring(0, x) + 'a' + table[y].Substring(x + 1);
                            }
                            if (x < m - 1 && table[y][x + 1] == '.')
                            {
                                x++;
                                table[y] = table[y].Substring(0, x) + 'a' + table[y].Substring(x + 1);
                            }
                        }
                    }
                }
                if (table[i][j] == 'B')
                {
                    if (was == 0)
                    {
                        was = 1;
                        int y = i, x = j;
                        while (!(y == 0 && x == 0))
                        {
                            if (y > 0 && table[y - 1][x] == '.')
                            {
                                y--;
                                table[y] = table[y].Substring(0, x) + 'b' + table[y].Substring(x + 1);
                            }
                            if (x > 0 && table[y][x - 1] == '.')
                            {
                                x--;
                                table[y] = table[y].Substring(0, x) + 'b' + table[y].Substring(x + 1);
                            }
                        }
                    }
                    else
                    {
                        int y = i, x = j;
                        while (!(y == n - 1 && x == m - 1))
                        {
                            if (y < n - 1 && table[y + 1][x] == '.')
                            {
                                y++;
                                table[y] = table[y].Substring(0, x) + 'b' + table[y].Substring(x + 1);
                            }
                            if (x < m - 1 && table[y][x + 1] == '.')
                            {
                                x++;
                                table[y] = table[y].Substring(0, x) + 'b' + table[y].Substring(x + 1);
                            }
                        }
                    }
                }
            }
        }

        foreach (string row in table)
        {
            Console.WriteLine(row);
        }
    }
}
