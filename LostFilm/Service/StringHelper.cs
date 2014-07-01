using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LostFilm
{
    static class StringHelper
    {
        public static string UnWrapBrackets(this string str)
        {
            int i1 = str.IndexOf('(') + 1;
            int i2 = str.IndexOf(')');
            if (i2 == -1) return str;
            return str.Substring(i1, i2 - i1);
        }

        public static string Clean(this string str)
        {
            return str.Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }
    }
}
