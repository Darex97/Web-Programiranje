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
            var sve = await Context.Prodavnice.Include(p=> p.Cvece).ToListAsync();

            return Ok(sve);
        }

        [Route("Prodavnice")]
        [HttpGet]
        public async Task<ActionResult> Prodavnice()
        {
            var sve = await Context.Prodavnice.Include(p=> p.Cvece).Select(q=> new{
                    id=q.ID,
                    ime=q.Ime,
                    podrucje=q.Cvece.Select(w=> w.Podrucje),
                    cvet=q.Cvece.Select(e=> e.Cvet),
                    list=q.Cvece.Select(r=> r.List),
                    stablo=q.Cvece.Select(t=> t.Stablo)
            })
            .ToListAsync();

            return Ok(sve);
        }

        [Route("VratiBiljke/{podrucje}/{cvet}/{list}/{stablo}")]
        [HttpGet]
        public async Task<ActionResult> VratiBiljke(string podrucje,string cvet,string list,string stablo)
        {
            var cvece= await Context.Cvece
            .Where(q=> q.Podrucje== podrucje && q.Cvet==cvet && q.List==list && q.Stablo==stablo).ToListAsync();

            if(cvece.Count()==0)
            {
                Pretraga p = new Pretraga();
                p.Podrucje=podrucje;
                p.Cvet=cvet;
                p.List=list;
                p.Stablo=stablo;
                p.DatumPretrage= DateTime.Now.ToShortDateString();

                Context.Pretrage.Add(p);
                await Context.SaveChangesAsync();
                return BadRequest("Ne postoji cvet");
            }

            return Ok(cvece);
        }
        [Route("PovecajUocavanje/{idBiljke}")]
        [HttpPut]
        public async Task<ActionResult> PovePovecajUocavanje(int idBiljke)
        {
            var b = Context.Cvece.Where(p=> p.ID==idBiljke).FirstOrDefault();
            b.BrPronadjenih++;

            try
            {
                Context.Cvece.Update(b);
                await Context.SaveChangesAsync();
                return Ok(b);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
                
            }

        }
    }
}
