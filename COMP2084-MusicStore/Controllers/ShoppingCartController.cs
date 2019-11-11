using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2084_MusicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP2084_MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MusicStoreContext _context;

        public ShoppingCartController(MusicStoreContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int SongId)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var song = _context.Song.SingleOrDefault(s => s.SongId == SongId);

            cart.AddToCart(_context, song);

            return RedirectToAction("Index");
        }

    }
}