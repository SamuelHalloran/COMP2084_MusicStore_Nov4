using COMP2084_MusicStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084_MusicStore.Controllers
{
    public class ShoppingCartService
    {
        private readonly MusicStoreContext _context;
        private readonly IHttpContextAccessor _http;

        public ShoppingCartService(MusicStoreContext context, IHttpContextAccessor http)
        {
            _http = http;
            _context = context;
        }


        public ShoppingCart GetCurrentCart()
        {
            return ShoppingCart.GetCart(_context, _http.HttpContext);
        }
    }
}
