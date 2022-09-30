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
    public class MecController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public MecController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("DodajMec/{lokacija}")]
        [HttpPost]  
        public async Task<ActionResult> DodajMec(string lokacija){

            //provereee

            Mec m = new Mec();
            m.Lokacija=lokacija;
            m.Datum=DateTime.Now.ToShortDateString();
                try{
                Context.Mecevi.Add(m);
                await Context.SaveChangesAsync();
                return Ok(m);
                }
                catch(Exception e){
                    return BadRequest(e.Message);
                }
        }

        [Route("VratiMeceve")]
        [HttpGet]

        public async Task<ActionResult> VratiMeceve(){

            var mecevi = await  Context.Mecevi
            .Include(p=> p.Igraci).ToListAsync();

            return Ok(mecevi);
        }

        [Route("DodajPoenPrviIgrac/{mecId}")]
        [HttpPut]

        public async Task<ActionResult> DodajPoenPrviIgrac(int mecId){
            var mec = Context.Mecevi.Where(p => p.ID==mecId).FirstOrDefault();

            if(mec.S1+mec.S2==2)
            return BadRequest("kraj meca");
            if(mec.S1==0 && mec.S2==0)
            {
                
                mec.PS11++;
               if(mec.PS11==6)
                mec.S1++;
            }else{
            
                mec.PS21++;
                if(mec.PS21==6)
                mec.S1++;
            
            }
            Context.Mecevi.Update(mec);
            await Context.SaveChangesAsync();
            return Ok(mec);
        }

        [Route("DodajPoenDrugiIgrac/{mecId}")]
        [HttpPut]

        public async Task<ActionResult> DodajPoenDrugiIgrac(int mecId){
            var mec = Context.Mecevi.Where(p => p.ID==mecId).FirstOrDefault();

            if(mec.S1+mec.S2==2)
            return BadRequest("kraj meca");
            if(mec.S2==0 && mec.S1==0)
            {
                
                mec.PS12++;
               if(mec.PS12==6)
                mec.S2++;
            }else{
            
                mec.PS22++;
                if(mec.PS22==6)
                mec.S2++;
            
            }
            Context.Mecevi.Update(mec);
            await Context.SaveChangesAsync();
            return Ok(mec);
        }
    }
}
