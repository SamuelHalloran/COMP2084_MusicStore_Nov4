using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2084_MusicStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP2084_MusicStore.API
{
    [Route("api/songs")]
    [ApiController]
    public class V1Controller : Controller
    {
        private readonly MusicStoreContext _context;

        public V1Controller(MusicStoreContext context)
        {
            _context = context;
        }

        // GET: api/V1
        [HttpGet]
        public IActionResult Get()
        {
            var theSongs = _context.Song.ToList();
            return Json(theSongs);
        }

        // GET: api/V1/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var theSong = _context.Song.Where(s => s.SongId == id).SingleOrDefault();
            return Json(theSong);
        }

        // POST: api/V1
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/V1/5
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
