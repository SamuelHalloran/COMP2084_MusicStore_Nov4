using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2084_MusicStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP2084_MusicStore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : Controller
    {
        private readonly MusicStoreContext _context;

        public NewController(MusicStoreContext context)
        {
            _context = context;
        }


        // GET: api/New
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Song.ToList();

            return Json(songs);
        }

        // GET: api/New/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var song = _context.Song.Where(x => x.SongId == id).SingleOrDefault();

            return Json(song);
        }

        // POST: api/New
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/New/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
