using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LostFilm
{
    class Program
    {
        static void Main(string[] args)
        {
            LFService s = new LFService();
            Console.WriteLine("Sync end");
            var t = s.GetShows();
            Console.WriteLine("Begin get shows");           
            var tt = t.Result;
            Console.WriteLine("Something");
        }
    }
}
