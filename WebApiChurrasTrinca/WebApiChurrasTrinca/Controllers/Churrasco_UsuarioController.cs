using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiChurrasTrinca.Models;
using WebApiChurrasTrinca.Context;

namespace WebApiChurrasTrinca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Churrasco_UsuarioController : ControllerBase
    {
        private readonly Churrasco_UsuarioContext _context;

        public Churrasco_UsuarioController(Churrasco_UsuarioContext context)
        {
            _context = context;
        }

        // GET: api/Churrasco_Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Churrasco_Usuario>>> GetChuras_Usuarios()
        {
            return await _context.Churas_Usuarios.ToListAsync();
        }

        // GET: api/Churrasco_Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Churrasco_Usuario>> GetChurrasco_Usuario(long id)
        {
            var churrasco_Usuario = await _context.Churas_Usuarios.FindAsync(id);

            if (churrasco_Usuario == null)
            {
                return NotFound();
            }

            return churrasco_Usuario;
        }

        // PUT: api/Churrasco_Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChurrasco_Usuario(long id, Churrasco_Usuario churrasco_Usuario)
        {
            if (id != churrasco_Usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(churrasco_Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Churrasco_UsuarioExists(id))
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

        // POST: api/Churrasco_Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Churrasco_Usuario>> PostChurrasco_Usuario(Churrasco_Usuario churrasco_Usuario)
        {
            _context.Churas_Usuarios.Add(churrasco_Usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChurrasco_Usuario", new { id = churrasco_Usuario.Id }, churrasco_Usuario);
        }

        // DELETE: api/Churrasco_Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Churrasco_Usuario>> DeleteChurrasco_Usuario(long id)
        {
            var churrasco_Usuario = await _context.Churas_Usuarios.FindAsync(id);
            if (churrasco_Usuario == null)
            {
                return NotFound();
            }

            _context.Churas_Usuarios.Remove(churrasco_Usuario);
            await _context.SaveChangesAsync();

            return churrasco_Usuario;
        }

        private bool Churrasco_UsuarioExists(long id)
        {
            return _context.Churas_Usuarios.Any(e => e.Id == id);
        }
    }
}
