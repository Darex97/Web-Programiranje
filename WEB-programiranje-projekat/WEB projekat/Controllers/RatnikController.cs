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
    public class RatnikController : ControllerBase
    {
        public BorbaContext Context { get; set; }

        public RatnikController(BorbaContext context)
        {
            Context = context;
        }

        [Route("Ratnici")]
        [HttpGet]
        public ActionResult Preuzmi()
        {
            var ratnici = Context.Ratnici
            .Include(p => p.RatnikPlaneta)
            .ThenInclude(w => w.PlanetineBorbe);

            return Ok(ratnici);
        }

        [Route("DodatiRatnika")]
        [HttpPost]
        public async Task<ActionResult> DodajRatnika([FromBody] Ratnik ratnik)
        {
            try
            {

                var ratnik2 = Context.Ratnici.Where(p => p.Ime == ratnik.Ime).FirstOrDefault();
                if (ratnik2 != null)
                {
                    return BadRequest("Ratnik vec postoji");
                }
                if (ratnik.Snaga < 0 || ratnik.Snaga > 100)
                {
                    return BadRequest("Vrednost ratnikove snage moze biti u intervalu od 1 do 100");
                }
                if (string.IsNullOrWhiteSpace(ratnik.Ime))
                {
                    return BadRequest("Niste uneli ime");
                }
                if (ratnik.Ime.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko ime");
                }
                if (!(Regex.Match(ratnik.Ime, "^[a-zA-Z0-9]+$")).Success)
                {
                    return BadRequest("Uneli ste nedozvoljen karakter");
                }


                Context.Ratnici.Add(ratnik);
                await Context.SaveChangesAsync();
                return Ok($"Sve ok! ID je: {ratnik.ID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [Route("PromeniRatnika")]
        [HttpPut]
        public async Task<ActionResult> Promeni([FromBody] Ratnik ratnik)
        {
            var ratnik2 = Context.Ratnici.Where(p => p.Ime == ratnik.Ime).FirstOrDefault();
            if (ratnik2 == null)
            {
                return BadRequest("Ratnik ne postoji");
            }
            try
            {
                var ratnikZaPromenu = await Context.Ratnici.FindAsync(ratnik2.ID);
                ratnikZaPromenu.Ime = ratnik.Ime;
                ratnikZaPromenu.Snaga = ratnik.Snaga;
                ratnikZaPromenu.PlanetaId = ratnik.PlanetaId;

                await Context.SaveChangesAsync();
                return Ok("Ratnik je uspesno izmenjen");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisatiRatnika/{ime}")]
        [HttpDelete]

        public async Task<ActionResult> Izbrisati(string ime)
        {
            var ratnik2 = Context.Ratnici.Where(p => p.Ime == ime).FirstOrDefault();
            if (ratnik2 == null)
            {
                return BadRequest("Ratnik ne postoji");
            }
            try
            {
                var ratnik = await Context.Ratnici.FindAsync(ratnik2.ID);
                Context.Ratnici.Remove(ratnik);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izbrisn ratnik");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
