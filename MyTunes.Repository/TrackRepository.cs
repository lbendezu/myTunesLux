using MyTunes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunes.Repository
{
    public class TrackRepository : IDisposable
    {
        private ChinookContext _context;
        public TrackRepository()
        {
            _context = new ChinookContext();
        }

        public void Dispose()
        {
            _context = null;
        }

        public IEnumerable<Track> GetAutofiltered(string name)
        {
            var tracks = _context.Track.Where(x => x.Name.StartsWith(name)).Take(10).AsEnumerable();
            return tracks; 
        }
    }
}
