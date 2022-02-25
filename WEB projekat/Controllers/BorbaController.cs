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
    public class BorbaController : ControllerBase
    {
       public BorbaContext Context{ get; set;}

        public BorbaController(BorbaContext context)
        {
            Context = context;
        }


       [Route("Borbe")]
       [HttpGet]
       public ActionResult Preuzmi()
       {
           var borbe = Context.Borbe;
           

           
               
                

           return Ok(borbe); 
       }


       [Route("DodajBorbu")]
       [HttpPost]
       public async Task<ActionResult> DodajBorbu ([FromBody] Borba borba)
       {
          try 
          { 
             
            borba.Vreme=DateTime.Now;
            var planeta1 = Context.Planete.Where(r => r.ID == borba.PlanetaId1).Select(p => p.GalaksijaID).FirstOrDefault();
            var planeta2 = Context.Planete.Where(r => r.ID == borba.PlanetaId2).Select(p => p.GalaksijaID).FirstOrDefault();
                
            if(!planeta1.Equals(planeta2))
            return BadRequest("Razlicite galaksije");

            
           var ratnici1 = Context.Ratnici.Where(r => r.PlanetaId == borba.PlanetaId1);
           var ratnici2 = Context.Ratnici.Where(r => r.PlanetaId == borba.PlanetaId2);

           var sumaSnaga1= ratnici1.Sum(r => r.Snaga);
           var sumaSnaga2= ratnici2.Sum(r => r.Snaga);
           

            if(sumaSnaga1>sumaSnaga2)
             {
                 borba.PlanetaPobedink=borba.PlanetaId1;
              Context.Borbe.Add(borba);
              await Context.SaveChangesAsync();
                return Ok($"Pobednik je: {borba.PlanetaId1}");
               }
              if(sumaSnaga1<sumaSnaga2)
            {    borba.PlanetaPobedink=borba.PlanetaId2;
                 Context.Borbe.Add(borba);
                   await Context.SaveChangesAsync();
                   return Ok($"Pobednik je: {borba.PlanetaId2}");
               }
                 return BadRequest("Snage su im jednake");
            
               }
          catch (Exception e)
          {
              return BadRequest(e.Message);
          }
          
       }

       [Route("IzbrisatiBorbu/{id}")]
        [HttpDelete]

        public async Task<ActionResult> Izbrisati(int id)
        {
           var borba1 = Context.Borbe.Where(p => p.ID==id).FirstOrDefault();
           if(borba1 ==null)
           {
               return BadRequest("Borba ne postoji");
           }
            try
            {
                var borba2 = await Context.Borbe.FindAsync(id);
                //ovde mora da uzmem ratnikove info za stampanje
                Context.Borbe.Remove(borba2);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izbrisana borba");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }

}