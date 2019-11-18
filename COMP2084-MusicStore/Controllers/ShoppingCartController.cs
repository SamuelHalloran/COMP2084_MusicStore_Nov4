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

        public IActionResult Index()
        {
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            return View(new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            });
        }

        public IActionResult AddToCart(int SongId)
        {
            var cart = ShoppingCart.GetCart(_context, this.HttpContext);
            var song = _context.Song.SingleOrDefault(s => s.SongId == SongId);

            cart.AddToCart(song);

            return RedirectToAction("Index");
        }

    }
}