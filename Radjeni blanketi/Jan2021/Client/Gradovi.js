export class Gradovi{
    constructor(id,naziv,x,y,meteoroloskiPodaci){
        this.id=id;
        this.naziv=naziv;
        this.x=x;
        this.y=y;
        this.meteoroloskiPodaci=meteoroloskiPodaci;
        this.kontejner=null;
    }

    iscrtajGrad(host){

        
        let gradskiKontejner =document.createElement("div");
        gradskiKontejner.className="gradskiKontejner";
        host.appendChild(gradskiKontejner);

        let leviKontejner = document.createElement("div");
        leviKontejner.className="leviKontejner";
        gradskiKontejner.appendChild(leviKontejner);

        let desniKontejner = document.createElement("div");
        desniKontejner.className="desniKontejner";
        gradskiKontejner.appendChild(desniKontejner);
        ////////crtanje forme






        ////////

        

        let gradInfoKontejner = document.createElement("div");
        gradInfoKontejner.className="gradInfoKontejner";
        gradInfoKontejner.innerHTML="Naziv: "+this.naziv+" X kordinata: " +this.x+" Y kordinata: "+this.y;
        leviKontejner.appendChild(gradInfoKontejner);
////////////
        let gradSelectKontejner = document.createElement("div");
        gradSelectKontejner.className="gradSelectKontejner";
        leviKontejner.appendChild(gradSelectKontejner);
        let niz=["Temperatura", "Padavine", "Suncani dani"];
        niz.forEach(n=>{
            let btn=document.createElement("input");
            btn.className="izbor"
            btn.type="radio";
            btn.name=this.ime;
            btn.value=n;
           
            if(n==="Temperatura") 
            btn.checked=true;
            gradSelectKontejner.appendChild(btn);

            let labela=document.createElement("label");
            labela.innerHTML=n;
            gradSelectKontejner.appendChild(labela);
        })
////////////

        let prikaziBtn=document.createElement("button");
        prikaziBtn.innerHTML="Prikazi";
        leviKontejner.appendChild(prikaziBtn);
        prikaziBtn.style.width= "100px";
        prikaziBtn.style.alignSelf="center";

       

        

        //////
        let meseciKontejner = document.createElement("div");
        meseciKontejner.className="meseciKontejner";
        leviKontejner.appendChild(meseciKontejner);
        
       
        
        this.iscrtajMesece(meseciKontejner)
        prikaziBtn.onclick=(ev)=> this.iscrtajMesece(meseciKontejner);
        

    }
    
    iscrtajMesece(host){
        host.innerHTML="";
        let opcija=document.querySelector(".izbor:checked").value;
        

        this.meteoroloskiPodaci.forEach(e => {
            
            let mesecKontejner=document.createElement("div");
            mesecKontejner.className="mesecKontejner";
            host.appendChild(mesecKontejner);
            if(opcija==="Temperatura"){
            let mesecInfo=document.createElement("label");
            mesecInfo.className="mesecInfo";
            mesecInfo.innerHTML="Mesec: "+e.nazivMeseca+"<br> Temperatura: "+e.temperatura;
            mesecKontejner.appendChild(mesecInfo);

            let mesecSkala = document.createElement("div");
            mesecSkala.className="mesecSkala";
            mesecSkala.style.height=`${e.temperatura}%`;
            mesecKontejner.appendChild(mesecSkala);
            }
            if(opcija==="Padavine"){
                let mesecInfo=document.createElement("label");
                mesecInfo.className="mesecInfo";
                mesecInfo.innerHTML="Mesec: "+e.nazivMeseca+"<br> Padavine: "+e.kolicinaPadavina;
                mesecKontejner.appendChild(mesecInfo);
    
                let mesecSkala = document.createElement("div");
                mesecSkala.className="mesecSkala";
                mesecSkala.style.height=`${e.kolicinaPadavina/100}%`;
                mesecKontejner.appendChild(mesecSkala);
            }
            if(opcija==="Suncani dani"){
                let mesecInfo=document.createElement("label");
                mesecInfo.className="mesecInfo";
                mesecInfo.innerHTML="Mesec: "+e.nazivMeseca+"<br> Suncani Dani: "+e.suncaniDani;
                mesecKontejner.appendChild(mesecInfo);
    
                let mesecSkala = document.createElement("div");
                mesecSkala.className="mesecSkala";
                mesecSkala.style.height=`${e.suncaniDani}%`;
                mesecKontejner.appendChild(mesecSkala);

                
            }

            mesecKontejner.onclick=(ev)=>this.iscrtajMeni(e.id,e.nazivMeseca,opcija);
            
        });
    }
    iscrtajMeni(id,mesec,opcija){
        var desniKontejner = document.querySelector(".desniKontejner");
        desniKontejner.innerHTML="";
        var label=document.createElement("label");
            label.innerHTML=mesec;
            desniKontejner.appendChild(label);

            let tbx=document.createElement("input");
             tbx.type="number";
             desniKontejner.appendChild(tbx);
             
             let btn=document.createElement("button");
             btn.innerHTML="Sacuvaj izmene";
             btn.style.width="100px";
             desniKontejner.appendChild(btn);
             btn.onclick=(ev)=>this.izmeni(id, tbx.value,opcija);
       
    }
    izmeni(id,value,opcija){
        
        if(opcija==="Temperatura"){
            
            fetch("https://localhost:5001/MeteoroloskiPodaci/IzmeniTemperaturu/"+id+"/"+value,{
                method:"POST"
            }).then(data=>{data.json().then(infor=>{
                this.meteoroloskiPodaci.forEach(p=>{
                    if(p.id===id)
                    p.temperatura=value;
                    var meseciKontejner = document.querySelector(".meseciKontejner");
                    this.iscrtajMesece(meseciKontejner);
                })
            })})

            
        }
        if(opcija==="Padavine"){

            fetch("https://localhost:5001/MeteoroloskiPodaci/IzmeniPadavine/"+id+"/"+value,{
                method:"POST"
            }).then(data=>{data.json().then(infor=>{
                this.meteoroloskiPodaci.forEach(p=>{
                    if(p.id===id)
                    p.kolicinaPadavina=value;
                    var meseciKontejner = document.querySelector(".meseciKontejner");
                    this.iscrtajMesece(meseciKontejner);
                })
            })})

            
        }
        if(opcija==="Suncani dani"){
            ///za ovo nisam uradio jer me smaralo
            fetch("https://localhost:5001/MeteoroloskiPodaci/IzmeniTemperaturu/"+id+"/"+value,{
                method:"POST"
            }).then(data=>{data.json().then(infor=>{
                this.meteoroloskiPodaci.forEach(p=>{
                    if(p.id===id)
                    p.temperatura=value;
                    var meseciKontejner = document.querySelector(".meseciKontejner");
                    this.iscrtajMesece(meseciKontejner);
                })
            })})
            
        }

    }
}