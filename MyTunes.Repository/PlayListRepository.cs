﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTunes.Dominio;
using System.Data.Entity.Validation;

namespace MyTunes.Repository
{
    public class PlayListRepository : IDisposable
    {
        private ChinookContext _context;

        public PlayListRepository()
        {
            _context = new ChinookContext();
        }
        //Change Signature - Refactoring
        public IEnumerable<Playlist> Get(int customerId)
        {
            return _context.Playlist.Where(x => x.CustomerId == customerId).AsEnumerable();
        }

        public Playlist GetById(int playlistId)
        {
            return _context.Playlist.Where(x => x.Id == playlistId).SingleOrDefault();
        }

        public int Create(Playlist playlist)
        {

            int i;

            playlist.Track.ToList().ForEach(t => _context.Track.Attach(t));

            _context.Playlist.Add(playlist);
            i = _context.SaveChanges();

            return i;
        }

        public int Delete(int id)
        {
            int i;
            var playlist = _context.Playlist.Where(x => x.Id == id).SingleOrDefault();
            playlist.Track.ToList().ForEach(t => playlist.Track.Remove(t));
            _context.Playlist.Remove(playlist);
            i = _context.SaveChanges();
            return i;
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
