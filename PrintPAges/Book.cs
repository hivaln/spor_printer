using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPAges
{
    internal class Book
    {
        List<int> pages;
        int start;
        int end;

        public Book()
        {
            pages = new List<int>();
        }
        
        public Book(int start, int end)
        {
            this.start = start;
            this.end = end;

            pages = new List<int>
            {
                end + 1
            };
        }

        public void CreateBook()
        {
            List<int> fPrint = new List<int>();
            List<int> sPrint = new List<int>();

            for (int i = start; i <= end; i++)
            {
                
            }
        }

        public void PrintBook()
        {

        }
    }
}
