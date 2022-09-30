export class Fabrika{
    constructor(id,naziv,silosi){
        this.id=id;
        this.naziv=naziv;
        this.silosi=silosi;

    }
    iscrtajFabriku(host){

        let fabrikaKontejner=document.createElement("div");
        fabrikaKontejner.className="fabrikaKontejner";
        host.appendChild(fabrikaKontejner);

        let leviDeo=document.createElement("div");
        leviDeo.className="leviDeo";
        fabrikaKontejner.appendChild(leviDeo);

        let nazivLabel=document.createElement("label");
        nazivLabel.className="nazivLabel";
        nazivLabel.innerHTML=this.naziv;
        leviDeo.appendChild(nazivLabel);

        let silosiKontejner=document.createElement("div");
        silosiKontejner.className="silosiKontejner";
        leviDeo.appendChild(silosiKontejner);

        
        this.iscrtajSilose(silosiKontejner);

        let formaKontejner=document.createElement("div");
        formaKontejner.className="formaKontejner";
        fabrikaKontejner.appendChild(formaKontejner);
        this.iscrtajForme(formaKontejner,this.silosi,silosiKontejner);



    }
    iscrtajSilose(host){

        host.innerHTML="";
        this.silosi.forEach(s=>{

            let silosKontejner=document.createElement("div");
            silosKontejner.className="silosKontejner";
            host.appendChild(silosKontejner);
            
            let infoKontejner=document.createElement("div");
            infoKontejner.className="infoKontejner";
            silosKontejner.appendChild(infoKontejner);
    
            let podaciLabel=document.createElement("label");
            podaciLabel.className="podaciLabel";
            podaciLabel.innerHTML=s.oznaka + "<br>" +s.trenutnaPopunjenost+"/"+s.kapacitet;
    
            
    
            let skalaKontejner=document.createElement("div");
            skalaKontejner.className="skalaKontejner";
            silosKontejner.appendChild(skalaKontejner);
            let procenat=s.trenutnaPopunjenost/s.kapacitet*100;
            skalaKontejner.style.height=`${procenat}%`;

            silosKontejner.appendChild(podaciLabel);

        })
        


    }
    iscrtajForme(host,silosi,silosiKontejner){

        let izborKontejner=document.createElement("div");
        izborKontejner.className="izborKontejner";
        host.appendChild(izborKontejner);

        let izborLabel=document.createElement("label");
        izborLabel.className="izborLabel";
        izborLabel.innerHTML="SILOS: "
        izborKontejner.appendChild(izborLabel);

        let izborSelect=document.createElement("select");
        izborSelect.className="izborSelect";
        izborKontejner.appendChild(izborSelect);
        silosi.forEach(p=> {
            let izborOpcija=document.createElement("option");
            izborOpcija.className="izborOpcija";
            izborOpcija.innerHTML=p.oznaka;
            izborOpcija.value=p.id;
            izborSelect.appendChild(izborOpcija);
        })




        let dodajKontejner=document.createElement("div");
        dodajKontejner.className="dodajKontejner";
        host.appendChild(dodajKontejner);

        let dodajLabel=document.createElement("label");
        dodajLabel.className="dodajLabel";
        dodajLabel.innerHTML="Kolicina:  "
        dodajKontejner.appendChild(dodajLabel);

        let dodajInput=document.createElement("input");
        dodajInput.className="dodajInput";
        dodajInput.type="number"
        dodajKontejner.appendChild(dodajInput);



        let buttonDodaj=document.createElement("button");
        buttonDodaj.className="buttonDodaj";
        buttonDodaj.innerHTML="DODAJ U SILOSE"
        host.appendChild(buttonDodaj);

        

        buttonDodaj.onclick=(ev)=>this.dodaj(izborSelect.value,dodajInput.value,silosiKontejner)
        



    }
    dodaj(izbor,kolicina,kontejnerZaCrtanje){
        this.silosi.forEach(p=>{
                
            if(p.id==izbor){
                
                if(p.trenutnaPopunjenost+parseInt(kolicina)>p.kapacitet)
                alert("Prevelika kolicina")
            }
        })
        fetch("https://localhost:5001/Fabrika/SipajUSilos/"+izbor+"/"+kolicina,{
            method:"PUT"
        }).then(data=>{data.json().then(info=>{

            this.silosi.forEach(p=>{
                
                if(p.id==izbor){
                    
                    p.trenutnaPopunjenost+=parseInt(kolicina);
                }
            })
            
            this.iscrtajSilose(kontejnerZaCrtanje);
            

        })
    })
    }
}