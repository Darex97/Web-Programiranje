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

        [Route("DodajMerac/{naziv}/{donjaGranica}/{gornjaGranica}/{boja}/{trenutna}/{podeok}")]
        [HttpPost]
        public async Task<ActionResult> DodajMerac(string naziv,int donjaGranica, int gornjaGranica,string boja,int trenutna, int podeok)
        {
            if(donjaGranica<0 || gornjaGranica<0)
            return BadRequest("Pogresne granice");
            if(podeok<0)
            return BadRequest("Pogresan podeok");
            if(trenutna<donjaGranica || trenutna>gornjaGranica)
            return BadRequest("Pogresan podeok");
            if(boja!="red" && boja!="blue" && boja!="green")
            return BadRequest("Pogresna boja");

            Merac m=new Merac();
            m.Naziv=naziv;
            m.GranicaOd=donjaGranica;
            m.GranicaDo=gornjaGranica;
            m.Boja=boja;
            m.TrenutnaVrednost=trenutna;
            m.MaxVrednost=trenutna;
            m.MinVrednost=trenutna;
            m.Podeok=podeok;
            try{
                Context.Meraci.Add(m);
                await Context.SaveChangesAsync();
                return Ok(m);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }

        }

        [Route("PreuzmiMerace")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiMerace(){
            try{
                return Ok(await Context.Meraci.Select(p=> new{
                    id=p.ID,
                    naziv=p.Naziv,
                    max=p.MaxVrednost,
                    min=p.MinVrednost,
                    dg=p.GranicaOd,
                    gg=p.GranicaDo,
                    boja=p.Boja,
                    podeok=p.Podeok,
                    trenutna=p.TrenutnaVrednost,
                    srednja=(double)p.ZbirIzmerenih/p.BrojMerenja
                }).ToListAsync());

                
            }
             catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajVrednost/{id}/{vredonst}")]
        [HttpPut]
        public async Task<ActionResult> DodajVrednost(int id, int vredonst){

        var Merac = Context.Meraci.Where(p => p.ID== id).FirstOrDefault();
        if(Merac == null)
        return BadRequest("ne postoji");

        if(Merac.GranicaOd > vredonst || Merac.GranicaDo < vredonst)
        return BadRequest("Pogresna vrednost");

        Merac.TrenutnaVrednost=vredonst;
        Merac.BrojMerenja++;
        Merac.ZbirIzmerenih+=vredonst;

        if(vredonst>Merac.MaxVrednost)
        Merac.MaxVrednost=vredonst;
        if(vredonst<Merac.MinVrednost)
        Merac.MinVrednost=vredonst;

        try{
            Context.Meraci.Update(Merac);
            await Context.SaveChangesAsync();
            return Ok(Merac);
        }
        catch(Exception e){
            return BadRequest(e.Message);
        }

        }


    }
}
