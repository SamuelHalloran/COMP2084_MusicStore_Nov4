using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartLineItem> CartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}
