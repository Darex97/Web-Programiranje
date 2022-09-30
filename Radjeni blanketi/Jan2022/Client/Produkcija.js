export class Produkcija{
    constructor(id,naziv,kategorije){

        this.id=id;
        this.naziv=naziv;
        this.kategorije=kategorije;
        this.filmoviZaSerch=[];
    }

    iscrtajProdukciju(host){
        
        let kategorijePoJednom=[];
        this.kategorije.forEach(k=>{
            if(!kategorijePoJednom.includes(k))
            kategorijePoJednom.push(k);
        })
        
        let produkcijaKontejner=document.createElement("div");
        produkcijaKontejner.className="produkcijaKontejner";
        host.appendChild(produkcijaKontejner);

        let nazivKontejner=document.createElement("div");
        nazivKontejner.className="nazivKontejner";
        
        let labelNaziv=document.createElement("label");
        labelNaziv.innerHTML=this.naziv;
        nazivKontejner.appendChild(labelNaziv);
        produkcijaKontejner.appendChild(nazivKontejner);

        let formaKontejner = document.createElement("div");
        formaKontejner.className="formaKontejner";
        produkcijaKontejner.appendChild(formaKontejner);

        let prikazKontejner = document.createElement("div");
        prikazKontejner.className="prikazKontejner";
        produkcijaKontejner.appendChild(prikazKontejner);

        this.iscrtajFormu(formaKontejner,prikazKontejner,kategorijePoJednom)

    }

    iscrtajFormu(formaKontejner,prikazKontejner,kategorije){

        let kategorijaKontejner= document.createElement("div");
        kategorijaKontejner.className="kategorijaKontejner";

        let kategorijaLabel=document.createElement("label");
        kategorijaLabel.innerHTML="KATEGORIJA: "

        kategorijaKontejner.appendChild(kategorijaLabel);

        let kategorijaSelect=document.createElement("select");

        kategorije.forEach(p=>{
            let kategorijaOption=document.createElement("option");
            kategorijaOption.value=p;
            kategorijaOption.innerHTML=p;
            kategorijaSelect.appendChild(kategorijaOption);
        })

        kategorijaKontejner.appendChild(kategorijaSelect)


        formaKontejner.appendChild(kategorijaKontejner);

        let donjiDeoForme=document.createElement("div");
        donjiDeoForme.className="donjiDeoForme";
        formaKontejner.appendChild(donjiDeoForme);

        this.nastaviCrtanje(donjiDeoForme,prikazKontejner,kategorijaSelect.value);
        kategorijaSelect.onchange=(ev)=>this.nastaviCrtanje(donjiDeoForme,prikazKontejner,kategorijaSelect.value);
    }
    nastaviCrtanje(donjiDeoForme,prikazKontejner,kategorije){
        this.filmoviZaSerch=[];
        donjiDeoForme.innerHTML=""
        fetch("https://localhost:5001/Ispit/VratiFilmoveZaKategorije/"+kategorije+"/"+this.id,{
            method:"GET"
        }).then(data=>{data.json().then(info=>{
            info.forEach(f=>{
                f.filmovi.forEach(k=>{
                    this.filmoviZaSerch.push(k);
                })
                
                let filmoviKontejner = document.createElement("div");
                filmoviKontejner.className="filmoviKontejner";
                

                let filmoviLable= document.createElement("label");
                filmoviLable.innerHTML="FILMOVI: "

                filmoviKontejner.appendChild(filmoviLable);
                
                let filmoviSelect= document.createElement("select");
                
                
                this.filmoviZaSerch.forEach(f=>{
                    
                    let filmoviOption = document.createElement("option");
                    filmoviOption.value=f.id;
                    filmoviOption.innerHTML=f.naziv;
                    filmoviSelect.appendChild(filmoviOption);
                })

                filmoviKontejner.appendChild(filmoviSelect);



                donjiDeoForme.appendChild(filmoviKontejner);

                let ocenaKontejner = document.createElement("div");
                ocenaKontejner.className="ocenaKontejner";

                let ocenaLabel= document.createElement("label");
                ocenaLabel.innerHTML="OCENA: "
                ocenaKontejner.appendChild(ocenaLabel);

                let ocenaInput=document.createElement("input")
                ocenaInput.type="number";
                ocenaKontejner.appendChild(ocenaInput);




                donjiDeoForme.appendChild(ocenaKontejner);

                let btnOceni = document.createElement("button");
                btnOceni.innerHTML="OCENI";
                donjiDeoForme.appendChild(btnOceni);
                
                btnOceni.onclick=(ev)=>this.oceni(filmoviSelect.value,ocenaInput.value,prikazKontejner)


                this.iscrtajPrikaz(prikazKontejner)


                    })

                
        })})

        
        
    }
    oceni(id,ocena,prikazKontejner){
        fetch("https://localhost:5001/Ispit/DodajOcenu/"+id+"/"+ocena,{
            method:"PUT"
        }).then(data=>{data.json().then(info=>{
            this.filmoviZaSerch.forEach(p=>{
                if(p.id==id)
                {
                    p.ukupnaOcena+=parseInt(ocena);
                    p.brOcena++;
                    
                }
            })
            alert("Uspesna ocena");
            this.iscrtajPrikaz(prikazKontejner)
        })})
    }
    iscrtajPrikaz(prikazKontejner){

        prikazKontejner.innerHTML="";
        
        let najgori=this.filmoviZaSerch[0];
        let srednji=this.filmoviZaSerch[0];
        let najbolji=this.filmoviZaSerch[0];
        let pozicija=0;

        this.filmoviZaSerch.forEach(p=>{
            if(p.ukupnaOcena/p.brOcena<najgori.ukupnaOcena/najgori.brOcena){
                najgori=p;
            }
            if(p.ukupnaOcena/p.brOcena>najgori.ukupnaOcena/najgori.brOcena){
                najbolji=p;
            }
             pozicija=parseInt(this.filmoviZaSerch.length/2);
             srednji=this.filmoviZaSerch[pozicija];
        })

        
        let niz = [najgori,srednji,najbolji];
        
        niz.forEach(f=>{

            let prosecnaOcena=((f.ukupnaOcena/f.brOcena)/10)*100;
            
            let filmPrikaz=document.createElement("div");
            filmPrikaz.className="filmPrikaz";

            let nazivFilma= document.createElement("label");
            nazivFilma.className="nazivFilma";
            nazivFilma.innerHTML=f.naziv;

            filmPrikaz.appendChild(nazivFilma);

            

            let skalaFilma = document.createElement("div");
            skalaFilma.className="skalaFilma";
            skalaFilma.style.height=`${prosecnaOcena}%`;

            filmPrikaz.appendChild(skalaFilma);

            let prosecnaLabel=document.createElement("label");
            prosecnaLabel.innerHTML="Prosecna ocena: "+ f.ukupnaOcena/f.brOcena

            filmPrikaz.appendChild(prosecnaLabel)




            prikazKontejner.appendChild(filmPrikaz);
        })

    }
}