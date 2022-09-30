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
    public class FabrikaController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public FabrikaController(IspitDbContext context)
        {
            Context = context;
        }

    
    
    [Route("DodajFabriku/{naziv}")]
    [HttpPost]
    public async Task<ActionResult> DodajFabriku(string naziv){

        var f = Context.Fabrike.Where(p=> p.Naziv==naziv).FirstOrDefault();

        if(f!=null)
        return BadRequest("PostojiFabrikejs");

        Fabrika fa=new Fabrika();
        fa.Naziv=naziv;

        try{
            Context.Fabrike.Add(fa);
            await Context.SaveChangesAsync();
            return Ok(fa);
        }
        catch(Exception e){
            return BadRequest(e.Message);
        }


    }
    [Route("DodajSilos/{oznaka}/{kapacitet}/{trKolicina}/{idFabrike}")]
    [HttpPost]
    public async Task<ActionResult> DodajSilos(string oznaka,int kapacitet,int trKolicina,int idFabrike){
        //ima li oznaka ima li kapacitet ima li trKolicina
        var fabrika=Context.Fabrike.Where(p=> p.ID==idFabrike).FirstOrDefault();
        //dal postoji fabrikica
        Silos s=new Silos();
        s.Oznaka=oznaka;
        s.Kapacitet=kapacitet;
        s.TrenutnaPopunjenost=trKolicina;
        s.Mojafabrika=fabrika;

         try{
            Context.Silosi.Add(s);
            await Context.SaveChangesAsync();
            return Ok(s);
        }
        catch(Exception e){
            return BadRequest(e.Message);
        }




    }

    
    [Route("VratiFabrike")]
    [HttpGet]
    public async Task<ActionResult> VratiFabrike(){

        var fabrike = await Context.Fabrike
        .Include(p=> p.silosi).ToListAsync();

        return Ok(fabrike);
    }

    [Route("SipajUSilos/{idSilosa}/{kolicina}")]
    [HttpPut]
    public async Task<ActionResult> SipajUSilos(int idSilosa,int kolicina){

        var s=Context.Silosi.Where(p=>p.ID==idSilosa).FirstOrDefault();
        if(s.TrenutnaPopunjenost+kolicina>s.Kapacitet)
        return BadRequest("nema dovoljno mesta");

        s.TrenutnaPopunjenost+=kolicina;

        try{
            Context.Silosi.Update(s);
            await Context.SaveChangesAsync();
            return Ok(s);
        }
        catch(Exception e){
            return BadRequest(e.Message);
        }

    }



    }

   
}
