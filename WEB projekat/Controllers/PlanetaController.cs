using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WEB_projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetaController : ControllerBase
    {
       public BorbaContext Context{ get; set;}

        public PlanetaController(BorbaContext context)
        {
            Context = context;
        }


       [Route("DodatiPlanetu")]
       [HttpPost]
       public async Task<ActionResult> DodajPlanetu([FromBody] Planeta planeta)
       {
           var planeta2 = Context.Planete.Where(p => p.ImePlanete==planeta.ImePlanete).FirstOrDefault();
           if(planeta2 !=null)
           {
               return BadRequest("Planeta vec postoji");
           }
           if(string.IsNullOrWhiteSpace(planeta.ImePlanete) )
           {
               return BadRequest("Niste uneli ime");
           }
           if( planeta.ImePlanete.Length >50)
           {
               return BadRequest("Uneli ste predugacko ime");
           }
           if(!(Regex.Match(planeta.ImePlanete,"^[a-zA-Z0-9]+$")).Success) 
           {
               return BadRequest("Uneli ste nedozvoljen karakter");
           }

           try 
           {
                 Context.Planete.Add(planeta);
                 await Context.SaveChangesAsync();
                 return Ok($"Sve ok! ID je: {planeta.ID}");
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
          
       }

        [Route("IzbrisatiPlanetu/{id}")]
        [HttpDelete]

        public async Task<ActionResult> Izbrisati(int id)
        {
           
            try
            {
                if(id<=0)
                {
                    return BadRequest("Pogresan id");
                }
           
                var planeta = await Context.Planete.FindAsync(id);
                if(planeta==null)
                {
                    return BadRequest("Ne postoji planeta");
                }
                string imeobrisane = planeta.ImePlanete;
                Context.Planete.Remove(planeta);
                await Context.SaveChangesAsync();                 
                return Ok($"Uspesno izbrisana planeta {imeobrisane}");
                }
            catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
        }

    }
}