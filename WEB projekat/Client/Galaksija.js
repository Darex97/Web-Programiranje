export class Galaksija{
   
    constructor(id,ime){
     this.id=id;
     this.ime=ime;
     this.container=null;
 }
 crtajGalaksiju(host){
    
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