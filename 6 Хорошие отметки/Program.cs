using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    public static void Solve_1(int n, int m, string[] journal, ref int max_x, ref  int max_y)
    {
        int k;
        for (k = 4; k >= 1; --k)
        {
            {
                int counter = 0;
                int id_counter = 0;
                int count_marks = 0;
                for (int i = 0; i < n; i++)
                {
                    int counterMarks = 0;
                    bool flag = false;
                    for (int j = 0; j < m; j++)
                    {
                        var charr = journal[i][j] - '0';
                        if (charr <= k)
                        {
                            ++counterMarks;
                            flag = true;
                        }
                    }
                    if (flag == true)
                    {
                        ++counter;
                    }
                    if (count_marks < counterMarks)
                    {
                        id_counter = i;
                        count_marks = counterMarks;
                    }
                    
                }

                int ColomnNum = 0;
                int ColomnCount = 0;
                for (int j = 0; j < m; ++j)
                {
                    bool flag = false;
                    for (int i = 0; i < n; ++i)
                    {
                        var charr = journal[i][j] - '0';
                        if (i == id_counter)
                        {
                            continue;
                        }
                        if (charr <= k)
                        {
                            flag = true;
                        }
                    }

                    if (flag == true)
                    {
                        ++ColomnCount;
                        ColomnNum = j;
                    }
                }

                if (ColomnCount <= 1)
                {
                    max_y = ColomnNum;
                    max_x = id_counter;
                    break;
                }
            }


            {
                int max_Mark = 0;
                int counters = 0;
                int Max_Count = 0;
                for (int j = 0; j < m; ++j)
                {
                    bool flag = false;
                    int cntMark = 0;
                    for (int i = 0; i < n; i++)
                    {
                        int charr = journal[i][j] - '0';
                        if (charr <= k)
                        {
                            ++cntMark;
                            flag = true;
                        }
                    }
                    if (flag == true)
                    {
                        ++counters;
                    }
                    if (max_Mark < cntMark)
                    {
                        Max_Count = j;
                        max_Mark = cntMark;
                    }
                }

                int indCol = 0;
                int CountColloms = 0;
                for (int i = 0; i < n; ++i)
                {
                    bool flag = false;
                    for (int j = 0; j < m; ++j)
                    {
                        if (j == Max_Count)
                        {
                            continue;
                        }
                        var charr = journal[i][j] - '0';
                        if (charr <= k)
                        {
                            flag = true;
                        }
                    }

                    if (flag == true)
                    {
                        ++CountColloms;
                        indCol = i;
                    }
                }

                if (CountColloms <= 1)
                {
                    max_y = Max_Count;
                    max_x = indCol;
                    break;
                }
            }
        }
    }
    public static void Solve(int n, int m)
    {
         string[] journal = new string[n];
            for (int j = 0; j < n; ++j)
            {
                journal[j] = Console.ReadLine();
            }

            int max_x = 0;
            int max_y = 0;
            Solve_1(n, m, journal, ref max_x, ref max_y);
            Console.WriteLine($"{max_x + 1} {max_y + 1}");
    }
    public static void Main(string[] args)
    {
        int tt = int.Parse(Console.ReadLine());
        while(tt-- > 0)
        {
            var strings = Console.ReadLine().Split();
            Solve(int.Parse(strings[0]), int.Parse(strings[1]));
        }
    }
}
