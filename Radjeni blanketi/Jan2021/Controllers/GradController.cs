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
    public class GradController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public GradController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("NapraviGrad/{naziv}/{x}/{y}")]
        [HttpPost]
        public async Task<ActionResult> NapraviGrad(string naziv,int x,int y)
        {
            var gradPomocni = Context.Gradovi.Where(p=> p.NazivGrada==naziv).FirstOrDefault();
            if(gradPomocni!= null)
            return BadRequest("Grad vec posotiji");
            if(String.IsNullOrWhiteSpace(naziv))
            return BadRequest("Niste uneli naziv");
            //.....

            Grad g=new Grad();
            g.NazivGrada=naziv;
            g.X=x;
            g.Y=y;

            try{
                Context.Gradovi.Add(g);
                await Context.SaveChangesAsync();
                return Ok(g);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("UzmiGradove")]
        [HttpGet]
        public async Task<ActionResult> UzmiGradove()
        {
                var g = await Context.Gradovi
                .Include(p=> p.MeteoroloskiPodataci).ToListAsync();
            try{
                
                return  Ok(g);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}
