export class Planeta{
   
       constructor(id,ime,imenaRatnika){
        this.id=id;
        this.ime=ime;
        this.imenaRatnika=imenaRatnika;
        this.container=null;
    }

    crtajPlanete(host){
        
       var el=document.createElement("td");
       var ratnici = "";
        this.imenaRatnika.forEach(ratnik =>
            {   
               
                
                ratnici=ratnici+ratnik.ime+"<br>";
                 el.innerHTML=ratnici;
                
            })
            host.appendChild(el);
       
    }
}