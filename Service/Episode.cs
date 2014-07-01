using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public abstract class Episode
    {
        public Season Season { get; set; }
        public int Index { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public abstract void Download();
    }
}
