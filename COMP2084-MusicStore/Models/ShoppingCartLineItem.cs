using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class ShoppingCartLineItem
    {
        [Key]
        public int ShoppingCartLineItemId { get; set; }

        [ForeignKey("ShoppingCart")]
        public string ShoppingCartId { get; set; }

        [ForeignKey("Song")]
        public int SongId { get; set; }

        public int Count { get; set; }

        public Song Song { get; set; }
    }
}
