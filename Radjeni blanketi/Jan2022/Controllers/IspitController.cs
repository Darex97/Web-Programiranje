using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }
        [Route("VratiSve")]
        [HttpGet]
        public async Task<ActionResult> VratiSve()
        {
            var sve = await Context.ProdukcijskeKuce.Include(p=> p.Filmovi).ToListAsync();
            return Ok(sve);
        }
        [Route("VratiProdukcijeSaKategorijama")]
        [HttpGet]
        public async Task<ActionResult> VratiProdukcijeSaKategorijama()
        {
            var sve = await Context.ProdukcijskeKuce
            .Include(p=> p.Filmovi)
            .Select(q=> new{
                id= q.ID,
                naziv=q.Naziv,
                kategorije=q.Filmovi.Select(r=> r.Kategorija)
            })
            .ToListAsync();
            return Ok(sve);
        }
        [Route("VratiFilmoveZaKategorije/{kategorija}/{idProdukcije}")]
        [HttpGet]
        public async Task<ActionResult> VratiFilmoveZaKategorije(string kategorija,int idProdukcije)
        {
            var filmovi = await Context.ProdukcijskeKuce.Include(q=> q.Filmovi.Where(r=> r.Kategorija==kategorija))
            .Where(p=> p.ID==idProdukcije).ToListAsync();
            return Ok(filmovi);
        }


        [Route("DodajFilm/{naziv}/{kategorija}/{idProdukcije}")]
        [HttpPost]
        public async Task<ActionResult> DodajFilm(string naziv,string kategorija,int idProdukcije)
        {
            //....Moze neki vid upita

            Film f = new Film();
            f.Naziv=naziv;
            f.Kategorija=kategorija;
            f.Produkcija=Context.ProdukcijskeKuce.Where(p=> p.ID==idProdukcije).FirstOrDefault();
            f.BrOcena=0;

            try
            {
                Context.Filmovi.Add(f);
                await Context.SaveChangesAsync();
                return Ok(f);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [Route("DodajOcenu/{idFilma}/{ocena}")]
        [HttpPut]
        public async Task<ActionResult> DodajOcenu(int idFilma,int ocena)
        {
            //

            var f = Context.Filmovi.Where(p=> p.ID == idFilma).FirstOrDefault();

            
            f.BrOcena++;
            f.UkupnaOcena+=ocena;
            

           

            try
            {
                Context.Filmovi.Update(f);
                await Context.SaveChangesAsync();
                return Ok(f);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);

            }


            
            
        }

    }

   
}
