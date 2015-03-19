using MyTunes.Dominio;
using MyTunes.Models;
using MyTunes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTunes.Services
{
    public class TrackService : IDisposable
    {
        private TrackRepository _trackRepository;

        public TrackService()
        {
            _trackRepository = new TrackRepository();
        }
        public IEnumerable<TrackAutocompleteViewModel> GetAutofiltered(string name)
        {
            return _trackRepository.GetAutofiltered(name).Select(x => new TrackAutocompleteViewModel
                {
                    label = x.Name,
                    value = x.Id.ToString()
                });
        }

        public void Dispose()
        {
            _trackRepository = null;
        }
    }
}