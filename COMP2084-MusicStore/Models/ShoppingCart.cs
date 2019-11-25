using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Models
{
    public class ShoppingCart
    {

        [Key]
        public string ShoppingCartId { get; set; }

        public MusicStoreContext dbContext { get; set; }

        public ICollection<ShoppingCartLineItem> ShoppingCartLineItems { get; set; }

        public List<ShoppingCartLineItem> GetCartItems()
        {
            List<ShoppingCartLineItem> lineItems = dbContext.ShoppingCartLineItem.Where(x => x.ShoppingCartId == ShoppingCartId).ToList();

            foreach (var li in lineItems)
            {
                li.Song = dbContext.Song.Where(x => x.SongId == li.SongId).SingleOrDefault();
                li.Song.Album = dbContext.Album.Where(x => x.AlbumId == li.Song.AlbumId).SingleOrDefault();
            }

            return lineItems;

        }

        public decimal GetTotal()
        {
            decimal? total = (from li in dbContext.ShoppingCartLineItem
                              where li.ShoppingCartId == ShoppingCartId
                              select (int?)li.Count * li.Song.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int GetTotalCount()
        {
            int? total = (from li in dbContext.ShoppingCartLineItem
                              where li.ShoppingCartId == ShoppingCartId
                              select (int?)li.Count).Sum();

            return total ?? 0;
        }

        public static ShoppingCart GetCart(MusicStoreContext db, HttpContext http)
        {
            var cart = new ShoppingCart();

            cart.dbContext = db;
            cart.ShoppingCartId = cart.GetCartId(http);

            var existingCart = (from c in db.ShoppingCart
                                where c.ShoppingCartId == cart.ShoppingCartId
                                select c).SingleOrDefault();

            if (existingCart == null)
            {

                db.ShoppingCart.Add(cart);
                db.SaveChanges();
            }

            return cart;
        }



        public void AddToCart(Song song)
        {
            var cartItem = dbContext.ShoppingCartLineItem.SingleOrDefault(
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

                dbContext.ShoppingCartLineItem.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            dbContext.SaveChanges();
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
