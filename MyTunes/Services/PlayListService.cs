using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTunes.Models;
using MyTunes.Repository;
using MyTunes.Dominio;

namespace MyTunes.Services
{
    public class PlayListService : IDisposable
    {
        private PlayListRepository _playListRepository;
        private CustomerRepository _customerRepository;

        public PlayListService()
        {
            _playListRepository = new PlayListRepository();
            _customerRepository = new CustomerRepository();
        }
        public IEnumerable<PlayListViewModel> GetPlayLists(string userName)
        {
            var customer = _customerRepository.GetByEmail(userName);
            if (customer == null) throw new InvalidOperationException(string.Format("Cliente no encontrado {0}", userName));
            var playLists = _playListRepository.Get(customer.Id); // PlayList
            // aqui se tiene que hacer un mapeo del dominio al viewmodel
            return playLists.Select(playList => new PlayListViewModel(playList)).ToList();
        }

        public int Create(PlayListViewModel playlistVM, int CustomerId) {

            var playlist = new Playlist();

            playlist.Name = playlistVM.Nombre;
            playlist.CustomerId = CustomerId;

            foreach (var track in playlistVM.Track)
            {
                playlist.Track.Add(track);                
            }

           
            
            return _playListRepository.Create(playlist);
        }
         
        public void Dispose()
        {
            _playListRepository = null;
            _customerRepository = null;
        }
    }
}
