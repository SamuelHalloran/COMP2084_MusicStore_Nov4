using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class ShoppingCartLineItem
    {
        public int ShoppingCartLineItemId { get; set; }
        [ForeignKey("Album")]
        public string ShoppingCartId { get; set; }
        public int SongId { get; set; }
        public int Count { get; set; }

    }
}
