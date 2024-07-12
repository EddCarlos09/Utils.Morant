using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Utils.Morant.Context;
using Utils.Morant.Mappers;
using Utils.Morant.Models.Tiny;
using Utils.Morant.ViewModels;

namespace Utils.Morant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUriController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShortUriController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ShortUri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UriResponse>>> GetShortUri()
        {
            List<UriResponse> response = new List<UriResponse>();
            await _context.ShortUri.ForEachAsync(x => response.Add(ShortUriMapper.Map(x)));
            return response;
        }

        // GET: api/ShortUri/5
        [HttpGet("{KeyUri}")]
        public async Task<ActionResult<UriResponse>> GetShortUri(string KeyUri)
        {
            //Buscar el registro
            var shortUri = await _context.ShortUri.FirstOrDefaultAsync(x => x.Short_url.Equals(KeyUri));
            //Si no existe, responder NotFound()
            if (shortUri == null)
            {
                return NotFound();
            }
            //Si existe, mapear el modelo a response
            var response = ShortUriMapper.Map(shortUri);
            //Retornar el elemento
            return response;
        }

        // PUT: api/ShortUri/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShortUri(int id, ShortUri shortUri)
        //{
        //    if (id != shortUri.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shortUri).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShortUriExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ShortUri
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UriResponse>> PostShortUri(UriRequest data)
        {
            if (!ShortUriExists(data.Url))
            {
                //Mapear el request al modelo
                var shortUri = ShortUriMapper.Map(data);
                //Generar la keyUrl
                shortUri.Short_url = GetUriKey();
                //Agregar el registro
                _context.ShortUri.Add(shortUri);
                await _context.SaveChangesAsync();
                //Mapear modelo al response
                var response = ShortUriMapper.Map(shortUri);            
                //Enviar la respuesta
                return CreatedAtAction("GetShortUri", new { id = shortUri.Id }, response);
            }
            //Si la url ya existe en la db, se responde con BadRequest
            else
                return BadRequest();
        }

        // DELETE: api/ShortUri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShortUri(int id)
        {
            var shortUri = await _context.ShortUri.FindAsync(id);
            if (shortUri == null)
            {
                return NotFound();
            }

            _context.ShortUri.Remove(shortUri);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        #region Métodos auxiliares
        private bool ShortUriExists(int id)
        {
            return _context.ShortUri.Any(e => e.Id == id);
        }

        private bool ShortUriExists(string url)
        {
            return _context.ShortUri.Any(e => e.Url == url);
        }

        private string GetUriKey()
        {
            string keyUri = CreatePassword(10);
            return keyUri; 
        }

        private readonly string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private string CreatePassword(int length)
        {
            Random rnd = new Random();
            StringBuilder res = new StringBuilder();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        #endregion
    }
}
