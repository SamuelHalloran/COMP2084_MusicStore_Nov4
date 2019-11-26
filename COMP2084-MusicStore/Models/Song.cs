using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }


        private decimal _Price;
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (value <= 0) throw new InvalidOperationException();
                _Price = value;
            }
        }

        public Album Album { get; set; }


        public string Title { get; set; }

        public string Featuring { get; set; }

        public string ArtistName { get; set; }

        public int RunTimeSeconds { get; set; }
    }
}
