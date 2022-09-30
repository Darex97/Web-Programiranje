using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeteoroloskiPodaciController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public MeteoroloskiPodaciController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("DodajMeteoroloskePodatke/{idGrada}/{nazivMeseca}/{prosecnaTemperatura}/{kolicinaPadavina}/{suncaniDani}")]
        [HttpPost]
        public async Task<ActionResult> DodajMeteoroloskePodatke(int idGrada,string nazivMeseca,int prosecnaTemperatura,int kolicinaPadavina,int suncaniDani)
        {
            //dal je sve vece od nulu dal je naziv neki od jan feb mart apr i to tako

            MeteoroloskiPodaci mp = new MeteoroloskiPodaci();
            mp.Gradovi=Context.Gradovi.Where(p=> p.ID==idGrada).FirstOrDefault();
            mp.NazivMeseca=nazivMeseca;
            mp.Temperatura=prosecnaTemperatura;
            mp.KolicinaPadavina=kolicinaPadavina;
            mp.SuncaniDani=suncaniDani;

             try{
                Context.MeteoroloskiPodaci.Add(mp);
                await Context.SaveChangesAsync();
                return Ok(mp);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        


        }

        [Route("IzmeniTemperaturu/{idMeseca}/{novaTemperatura}")]
        [HttpPost]
        public async Task<ActionResult> IzmeniTemperaturu(int idMeseca,int novaTemperatura)
        {
            var gradPomocni = Context.MeteoroloskiPodaci.Where(p=> p.ID==idMeseca).FirstOrDefault();
            if(gradPomocni== null)
            return BadRequest("Mesec ne postoji");
            
            //..... validna temp mora pude

            
            gradPomocni.Temperatura=novaTemperatura;

            try{
                Context.MeteoroloskiPodaci.Update(gradPomocni);
                await Context.SaveChangesAsync();
                return Ok(gradPomocni);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzmeniPadavine/{idMeseca}/{novePadavine}")]
        [HttpPost]
        public async Task<ActionResult> IzmeniPadavine(int idMeseca,int novePadavine)
        {
            var gradPomocni = Context.MeteoroloskiPodaci.Where(p=> p.ID==idMeseca).FirstOrDefault();
            if(gradPomocni== null)
            return BadRequest("Mesec ne postoji");
            
            //..... validna temp mora pude

            
            gradPomocni.KolicinaPadavina=novePadavine;

            try{
                Context.MeteoroloskiPodaci.Update(gradPomocni);
                await Context.SaveChangesAsync();
                return Ok(gradPomocni);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }

}