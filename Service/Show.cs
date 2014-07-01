using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class Show
    {
        public IService Service { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public Uri Url { get; set; }
        public abstract string GetDescription();
        public abstract string GetPoster();
        public abstract Task<IEnumerable<Season>> GetSeasons();

        public Show(IService service)
        {
            this.Service = service;
        }
    }
}
