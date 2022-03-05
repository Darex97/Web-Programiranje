export class Planeta{
   
       constructor(id,ime,imenaRatnika){
        this.id=id;
        this.ime=ime;
        this.imenaRatnika=imenaRatnika;
        this.container=null;
    }

    crtajPlanete(host){
        // var tr=document.createElement("tr");
        // host.appendChild(tr);

         //var el=document.createElement("td");
        // el.innerHTML=this.ime;
        // tr.appendChild(el);
        
       //console.log(this);
       var el=document.createElement("td");
       var ratnici = "";
        this.imenaRatnika.forEach(ratnik =>
            {   
               // console.log(ratnik.ime);
                
                ratnici=ratnici+ratnik.ime+"<br>";
                 el.innerHTML=ratnici;
                
            })
            host.appendChild(el);
       
    }
}