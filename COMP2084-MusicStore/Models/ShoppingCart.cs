using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }

        public ICollection<ShoppingCartLineItem> ShoppingCartLineItems { get; set; }
        

        public static ShoppingCart GetCart(HttpContext http)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(http);
            return cart;
        }

        public void AddToCart(MusicStoreContext db, Song song)
        {
            var cartItem = db.ShoppingCartLineItem.SingleOrDefault(
                    c => c.ShoppingCartId == this.ShoppingCartId
                    && c.SongId == song.SongId
                );

            if (cartItem == null)
            {
                cartItem = new ShoppingCartLineItem {
                    SongId = song.SongId,
                    ShoppingCartId = this.ShoppingCartId,
                    Count = 1
                };

                db.ShoppingCartLineItem.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public string GetCartId(HttpContext http)
        {

            if (http.Session.GetString("CartId") == null)
            {
                if (!string.IsNullOrWhiteSpace(http.User.Identity.Name))
                {
                    http.Session.SetString("CartId", http.User.Identity.Name);
                }
                else
                {
                    Guid newCartId = Guid.NewGuid();
                    http.Session.SetString("CartId", newCartId.ToString());
                }

                
            }

            return http.Session.GetString("CartId");
        }
        
    }
}
