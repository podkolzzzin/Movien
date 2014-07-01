using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IService
    {
        string Name { get; }
        Uri Url { get; }
        Task<IEnumerable<Show>> GetShows();
        Task<Show> GetShow();
    }
}
