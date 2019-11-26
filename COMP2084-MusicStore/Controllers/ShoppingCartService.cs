using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2084_MusicStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP2084_MusicStore.Controllers
{
    public class ShoppingCartService : Controller
    {
        private readonly MusicStoreContext _context;
        private readonly IHttpContextAccessor _http;

        public ShoppingCartService(MusicStoreContext context, IHttpContextAccessor http)
        {
            _http = http;
            _context = context;
        }

        public string GetTestInfo()
        {
            return "This is just a test";
        }

        public ShoppingCart GetCurrentCart()
        {
            return ShoppingCart.GetCart(_context, _http.HttpContext);
        }
    }
}
