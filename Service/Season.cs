using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public abstract class Season
    {
        public Show Show { get; set; }
        public int Index { get; set; }
        public IEnumerable<Episode> Episodes {get; set;}
    }
}
