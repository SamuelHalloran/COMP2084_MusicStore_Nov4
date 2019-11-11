using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
