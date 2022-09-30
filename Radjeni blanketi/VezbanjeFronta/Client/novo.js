export class novo{
    constructor(){
        this.nizCb=["a","b","v"]
        this.cekirano="v";
    }

    iscrtaj2(host){


        host.innerHTML="";

        let gore = document.createElement("div");
        gore.className="gore";
        host.appendChild(gore);

        let dole = document.createElement("div");
        dole.className="dole";
        host.appendChild(dole);


        gore.innerHTML="";
        let cbKontejner= document.createElement("div");
        cbKontejner.className="cbKontejner"

        this.nizCb.forEach(p=>{
            let label = document.createElement("label");
            label.innerHTML=p;
            cbKontejner.appendChild(label);

            let cb=document.createElement("input");
            cb.type="radio";
            cb.innerHTML=p;
            cb.value=p;
            cbKontejner.appendChild(cb);

            if(cb.value===this.cekirano){
                cb.checked="true";
            }

            cb.onchange=(ev)=> {
                this.cekirano=cb.value;
                this.iscrtaj2(host)
            }

            

        })

        


        gore.appendChild(cbKontejner);

        

        this.d(dole);
    }
    d(dole){
        
       
        dole.innerHTML="";

        let dugme = document.createElement("button");
        dugme.innerHTML="DUGME";
        dole.appendChild(dugme);
        dugme.onclick=(ev)=>this.prikazi(dole);


    }
    prikazi(dole){
        console.log(this.cekirano)

        let datum = document.createElement("input");
        datum.type="date";
        dole.appendChild(datum);

        let datum2 = document.createElement("input");
        datum2.type="date";
        dole.appendChild(datum2);
        
        datum.onchange=(ev)=>{
            console.log(typeof datum.value)
        }


    }
}