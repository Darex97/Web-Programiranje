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

        [Route("DodajProdavnicu/naziv")]
        [HttpPost]
        public async Task<ActionResult> dodajProdavnicu(string naziv)
        {
            var prod = Context.Prodavnice.Where(p=> p.Naziv == naziv).FirstOrDefault();
            if(prod!=null)
            {
                return BadRequest("Prodavnica vec postoji sa datim nazivom");
            }

            Prodavnica p = new Prodavnica();
            p.Naziv=naziv;
            try
            {
                Context.Prodavnice.Add(p);
                await Context.SaveChangesAsync();
                return Ok(p);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajAutomobil/marka/boja/model/idProdavnice")]
        [HttpPost]
        public async Task<ActionResult> dodajAutomobil(string marka,string boja,string model,int idProdavnice)
        {
            if(string.IsNullOrWhiteSpace(marka))
            {
                return BadRequest("Niste uneli marku");
            }
            //.....

           Automobil a = new Automobil();
           a.Marka=marka;
           a.Boja=boja;
           a.Model=model;
           a.DatumPoslednjeProdaje= "Nije kupljen nijedan automobil date marke";
           a.Prodavnica=Context.Prodavnice.Where(p=> p.ID==idProdavnice).FirstOrDefault();
            try
            {
                Context.Automobili.Add(a);
                await Context.SaveChangesAsync();
                return Ok(a);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("VratiSveProdavnice")]
        [HttpGet]
        public async Task<ActionResult> vratiSveProdavnice()
        {
            var prodavnice = await Context.Prodavnice.Include(q=> q.Automobili).Select(p=>new{
                    id=p.ID,
                    naziv=p.Naziv,
                    marke=p.Automobili.Select(b=> b.Marka),
                    modeli=p.Automobili.Select(g=> g.Model),
                    boje=p.Automobili.Select(v=> v.Boja)

            }).ToListAsync();

            return Ok(prodavnice);
        }


        [Route("VratiSveModele/{marka}/{idProdavnice}")]
        [HttpGet]
        public async Task<ActionResult> VratiSveMarke(string marka,int idProdavnice)
        {
            var modeli = await Context.Prodavnice.Include(q=> q.Automobili)
            .Where(w=> w.ID==idProdavnice)
            .Select(p=>new{
                    
                    modeli=p.Automobili.Where(r=>r.Marka==marka).Select(g=> g.Model)
                    

            }).ToListAsync();

            return Ok(modeli);
        }
        [Route("VratiSveBoje/{marka}/{model}/{idProdavnice}")]
        [HttpGet]
        public async Task<ActionResult> VratiSveBoje(string marka,string model, int idProdavnice)
        {
            var boje = await Context.Prodavnice.Include(q=> q.Automobili)
            .Where(w=> w.ID==idProdavnice)
            .Select(p=>new{
                    
                    boje=p.Automobili.Where(r=>r.Marka==marka && r.Model==model ).Select(g=> g.Boja)
                    

            }).ToListAsync();

            return Ok(boje);
        }
        [Route("VratiPoPretrazi/marka/model/boja/idProdavnice")]
        [HttpGet]
        public async Task<ActionResult> vratiSveProdavnice(string marka,string model,string boja,int idProdavnice)
        {
            if(model=="nista" && boja=="nista")
            {
            var prodavnice1 = await Context.Prodavnice
            .Include(p=> p.Automobili.Where(q=> q.Marka==marka)).Where(q=> q.ID==idProdavnice)
            .ToListAsync();
            return Ok(prodavnice1);
            }
            if(boja=="nista")
            {
            var prodavnice2 = await Context.Prodavnice
            .Include(p=> p.Automobili.Where(q=> q.Marka==marka && q.Model==model)).Where(q=> q.ID==idProdavnice)
            .ToListAsync();
            return Ok(prodavnice2);
            }
            if(model=="nista")
            {
            var prodavnice3 = await Context.Prodavnice
            .Include(p=> p.Automobili.Where(q=> q.Marka==marka && q.Boja==boja)).Where(q=> q.ID==idProdavnice)
            .ToListAsync();
            return Ok(prodavnice3);
            }
            var prodavnice = await Context.Prodavnice
            .Include(p=> p.Automobili.Where(q=> q.Marka==marka && q.Model==model && q.Boja==boja)).Where(q=> q.ID==idProdavnice)
            .ToListAsync();

            return Ok(prodavnice);
        }
        [Route("KupiAutomobil/idAutomobila")]
        [HttpPut]
        public async Task<ActionResult> kupiAutomobil(int idAutomobila)
        {
            var auto = Context.Automobili.Where(p=> p.ID==idAutomobila).FirstOrDefault();
            if(auto==null)
            {
                return BadRequest("Ne postoji auto");
            }
            auto.Kolicina--;
            auto.DatumPoslednjeProdaje= DateTime.Now.ToShortDateString();


            try
            {
                Context.Automobili.Update(auto);
                await Context.SaveChangesAsync();
                return Ok(auto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            

        }
    }
}
