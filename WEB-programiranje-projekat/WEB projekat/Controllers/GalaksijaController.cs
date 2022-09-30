using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WEB_projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalaksijaController : ControllerBase
    {
        public BorbaContext Context { get; set; }

        public GalaksijaController(BorbaContext context)
        {
            Context = context;
        }

        [Route("DodatiGalaksiju")]
        [HttpPost]
        public async Task<ActionResult> DodajGalaksiju([FromBody] Galaksija galaksija)
        {
            var galaksija2 = Context.Galaksije.Where(p => p.ImeGalaksije == galaksija.ImeGalaksije).FirstOrDefault();
            if (galaksija2 != null)
            {
                return BadRequest("Galaksija vec postoji");
            }
            if (string.IsNullOrWhiteSpace(galaksija.ImeGalaksije))
            {
                return BadRequest("Niste uneli ime");
            }
            if (galaksija.ImeGalaksije.Length > 50)
            {
                return BadRequest("Uneli ste predugacko ime");
            }
            if (!(Regex.Match(galaksija.ImeGalaksije, "^[a-zA-Z0-9]+$")).Success)
            {
                return BadRequest("Uneli ste nedozvoljen karakter");
            }

            try
            {
                Context.Galaksije.Add(galaksija);
                await Context.SaveChangesAsync();
                return Ok($"Sve ok! ID je: {galaksija.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzbrisatiGalaksiju/{id}")]
        [HttpDelete]

        public async Task<ActionResult> Izbrisati(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogresan id");
            }
            try
            {
                var galaksija = await Context.Galaksije.FindAsync(id);
                if (galaksija == null)
                {
                    return BadRequest("Ne postoji galaksija");
                }
                Context.Galaksije.Remove(galaksija);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izbrisna galaksija");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("SamoNaziviGalaksija")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var galaksije = Context.Galaksije.ToList();







            return Ok(galaksije);
        }
        [Route("GalaksijaBorbe/{id}")]
        [HttpGet]
        public ActionResult Preuzmi(int id)
        {

            var borbe = Context.Planete
           .Where(q => q.GalaksijaID == id)
           .Include(p => p.PlanetineBorbe);
            var trazeneBorbe = borbe.Select(p =>
                        new
                        {
                            Ime = p.ImePlanete,
                            PlanetaDomacin = p.ID,
                            b = p.PlanetineBorbe.Select(q =>
                        new
                             {

                                 vreme = q.Vreme,
                                 prva = q.PlanetaId1,
                                 druga = q.PlanetaId2,
                                 pobednik = q.PlanetaPobedink
                             })

                        }).ToList();
            return Ok(trazeneBorbe);
        }
    }
}