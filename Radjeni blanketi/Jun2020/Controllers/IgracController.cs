using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IgracController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IgracController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("DodajIgraca/{ime}/{god}/{rank}/{idMeca}")]
        [HttpPost]  
        public async Task<ActionResult> DodajIgraca(string ime,int god,int rank,int idMeca){
            var mec = Context.Mecevi.Where(p => p.ID==idMeca).FirstOrDefault();
            Igrac i = new Igrac();
            i.Ime=ime;
            i.Rank=rank;
            i.Godine=god;
            i.MecNaKojiUcestvuju=mec;
            
            try{
                Context.Igraci.Add(i);
                await Context.SaveChangesAsync();
                return Ok(i);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }


        }
    }
}
