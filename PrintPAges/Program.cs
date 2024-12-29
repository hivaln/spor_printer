using System;
using System.Collections.Generic;

namespace PrintPAges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start, end;

            Console.Write("Enter start page: ");
            while (!int.TryParse(Console.ReadLine(), out start) || start <= 0)
            {
                Console.Write("Enter start page: ");
            }

            Console.Write("Enter end page: ");
            while (!int.TryParse(Console.ReadLine(), out end) || end <= start)
            {
                Console.Write("Enter end page: ");
            }

            List<Page> pages = new List<Page>();

            int k = 0, j = 0, u = 0, p = 0;

            for (int i = start; i <= end; i++)
            {
                if ((i - start) % 32 == 0)
                {
                    pages.Add(new Page(end + 1));
                    pages.Add(new Page(end + 1));
                }

                if (i % 2 == 1)
                {
                    pages[pages.Count - 2][k, j] = i;
                    j++;
                }
                else
                {
                    pages[pages.Count - 1][u, 3 - p] = i;
                    p++;
                }

                if (p == 4)
                {
                    u++;
                    p = 0;
                }
                if (u == 4)
                {
                    u = 0;
                }
                if (j == 4)
                {
                    k++;
                    j = 0;
                }
                if (k == 4)
                {
                    k = 0;
                }
            }

            Console.Write("Print all miniPages or every page? 1/2: ");
            var key = Console.Read();

            if (key == '1')
            {
                string result1 = string.Empty;
                string result2 = string.Empty;

                for (int i = 0; i < pages.Count; i++)
                {
                    if ((i & 1) == 0)
                    {
                        result1 += pages[i].ToString() + ',';
                    }
                    else
                    {
                        result2 += pages[i].ToString() + ',';
                    }
                }

                Console.WriteLine("Font pages to print: " + result1.Remove(result1.Length - 1, 1));
                Console.WriteLine("Back pages to print: " + result2.Remove(result2.Length - 1, 1));
            }
            else if (key == '2')
            {
                int m = 1;
                foreach (var page in pages)
                {
                    Console.WriteLine($"page {m++}: {page.ToString()}");
                }
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

            }
        }
    }

    class Page
    {
        readonly int nullPage;
        public int[,] miniPages = new int[4, 4];

        public Page(int nullPage)
        {
            this.nullPage = nullPage;

            for (int i = 0; i < miniPages.GetLength(0); i++)
            {
                for (int j = 0; j < miniPages.GetLength(1); j++)
                {
                    miniPages[i, j] = nullPage;
                }
            }
        }

        public string ToString()
        {
            string result = string.Empty;

            foreach (int miniPage in miniPages)
            {
                result += miniPage + ",";
            }

            return result.Remove(result.Length - 1, 1);
        }

        public string ToStringViewPage()
        {
            string result = string.Empty;

            for (int i = 0; i < miniPages.GetLength(0); i++)
            {
                for (int j = 0; j < miniPages.GetLength(1); j++)
                {
                    result += miniPages[i, j] + ",";
                }

                result.Remove(result.Length - 1, 1);
                result += '\n';
            }

            return result;
        }

        public int this[int i, int j]
        {
            get { return miniPages[i, j]; }
            set { miniPages[i, j] = value; }
        }
    }
}
