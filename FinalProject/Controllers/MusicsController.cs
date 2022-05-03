#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly CopyrightFreeMusicDBContext _context;

        public MusicsController(CopyrightFreeMusicDBContext context)
        {
            _context = context;
        }

        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<Response>> GetMusics()
        {
            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Succesfully fetched all music tracks";

            var listOfMusics = await _context.Musics.Include(i => i.Artists).Include(i => i.Genres)
             .ToListAsync();

            response.Musics = listOfMusics;

            if (listOfMusics.Count == 0)
            {
                response.statusCode = 404;
                response.statusDescription = "No data for music available";
            }

            return response;
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetMusics(int id)
        {
            var music = await _context.Musics.Include(i => i.Artists).Include(i => i.Genres).Where(i => i.MusicsId == id)
             .ToListAsync();

            var response = new Response();
            response.statusCode = 200;

            if (music.Count == 0)
            {
                response.statusCode = 404;
                response.statusDescription = "The specified id doesn't exist";
                return NotFound(response);
            }

            response.Musics = music;
            response.statusDescription = "Successfully fetched music track of specified id ";

            return response;
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusics(int id, Musics musics)
        {
            if (id != musics.MusicsId)
            {
                return BadRequest();
            }

            _context.Entry(musics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Musics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostMusics(Musics musics)
        {
            var response = new Response();
            response.statusCode = 201;

            if (musics.Genres.Popularity < 0 || musics.Genres.Popularity > 10)
            {
                response.statusCode = 400;
                response.statusDescription = "Genre popularity must be an integer within 0-10";
                return BadRequest(response);
            }

            try
            {
                _context.Musics.Add(musics);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                response.statusCode = 500;
                response.statusDescription = "The requested music track failed to upload into database";
                return response;
            }

            response.statusDescription = "Successfully created music track" + musics.MusicsId;

            var newMusic = await _context.Musics.Include(i => i.Artists).Include(i => i.Genres).Where(i => i.MusicsId == musics.MusicsId).ToListAsync();
            response.Musics = newMusic;

            return Ok(response);
        }

        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteMusics(int id)
        {
            var musics = await _context.Musics.FindAsync(id);

            var response = new Response();
            response.statusCode = 200;

            if (musics == null)
            {
                response.statusCode = 404;
                response.statusDescription = "The specified id doesn't exist";
                return NotFound(response);
            }

            _context.Musics.Remove(musics);
            await _context.SaveChangesAsync();

            response.statusDescription = "The specified music track had been successfully deleted";

            return response;
        }

        private bool MusicsExists(int id)
        {
            return _context.Musics.Any(e => e.MusicsId == id);
        }
    }
}
