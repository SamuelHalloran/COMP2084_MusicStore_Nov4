using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using COMP2084_MusicStore.Models;

namespace COMP2084_MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicStoreContext _context;

        public StoreController(MusicStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Browse(int genreId)
        {
            var query = from g in _context.Genre
                        join a in _context.Album on g.GenreId equals a.GenreId
                        join s in _context.Song on a.AlbumId equals s.AlbumId
                        where g.GenreId == genreId
                        select s;

            return View(query);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Albums()
        {
            var albums = new List<Album>();

            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Album " + i.ToString() });
            }

            return View(albums);
        }
    }
}