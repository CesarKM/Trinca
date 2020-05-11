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
    public class ChurrascoesController : ControllerBase
    {
        private readonly ChurrascoContext _context;

        private readonly Churrasco_UsuarioContext _churrasco_UsuarioContext;

        public ChurrascoesController(ChurrascoContext context)
        {
            _context = context;
        }

        // GET: api/Churrascoes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Churrasco>>> GetChurrascos()
        public async Task<ActionResult<IEnumerable<ChurrascoDTO>>> GetChurrascos()
        {
            var lista = _churrasco_UsuarioContext.Churas_Usuarios.ToList();
            var teste = from _context in _context.Churrascos
                            //.Join(Churrascos => Churrasco_UsuarioContext)
                        select new ChurrascoDTO()
                        {
                            churrasco = new Churrasco()
                            {
                                Data = _context.Data,
                                Descricao = _context.Descricao,
                                Id = _context.Id,
                                Observacao = _context.Observacao
                            }
                            ,
                            QuantidadePessoas = 0// lista.Sum(x => x.ID_Churrasco = _context.Id)
                            ,
                            ValorComBebida = 0
                            ,
                            ValorSemBebida = 1
                        };

            return teste.ToArray(); //await _context.Churrascos.ToListAsync();
        }

        // GET: api/Churrascoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Churrasco>> GetChurrasco(long id)
        {
            var churrasco = await _context.Churrascos.FindAsync(id);

            if (churrasco == null)
            {
                return NotFound();
            }

            return churrasco;
        }

        // PUT: api/Churrascoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChurrasco(long id, Churrasco churrasco)
        {
            if (id != churrasco.Id)
            {
                return BadRequest();
            }

            _context.Entry(churrasco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChurrascoExists(id))
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

        // POST: api/Churrascoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Churrasco>> PostChurrasco(Churrasco churrasco)
        {
            _context.Churrascos.Add(churrasco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChurrasco), new { id = churrasco.Id }, churrasco);
        }

        // DELETE: api/Churrascoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Churrasco>> DeleteChurrasco(long id)
        {
            var churrasco = await _context.Churrascos.FindAsync(id);
            if (churrasco == null)
            {
                return NotFound();
            }

            _context.Churrascos.Remove(churrasco);
            await _context.SaveChangesAsync();

            return churrasco;
        }

        private bool ChurrascoExists(long id)
        {
            return _context.Churrascos.Any(e => e.Id == id);
        }
    }
}
