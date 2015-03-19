﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunes.Models
{
    public class PlayListViewModel
    {

        public PlayListViewModel() {
            Tracks = new List<Track>();
        }

        public PlayListViewModel(Dominio.Playlist playList)
        {
            
            this.Id= playList.Id;
            this.Nombre = playList.Name;
            
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Calificacion { get; set; }
        public List<Track> Tracks { get; set; }

        public class Track
        {
            public int Id { get; set; }
        }
    }
}
