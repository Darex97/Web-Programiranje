
export class Prodavnica{
    constructor(id,naziv,marke,modeli,boje){
        this.id=id;
        this.naziv=naziv;
        this.marke=marke;
        this.modeli=modeli;
        this.boje=boje;
        this.nizAutomobilaNaOsnovuPretrage=[];

    }

    iscrtajProdavnicu(host){
       
        let prodavnicaKontejner=document.createElement("div");
        prodavnicaKontejner.className="prodavnicaKontejner";
        host.appendChild(prodavnicaKontejner);

        let nazivKontejner = document.createElement("label");
        nazivKontejner.className="nazivKontejner";
        nazivKontejner.innerHTML=this.naziv;
        prodavnicaKontejner.appendChild(nazivKontejner);

        let donjiDeo=document.createElement("div");
        donjiDeo.className="donjiDeo";
        prodavnicaKontejner.appendChild(donjiDeo);

        let formaKontejner = document.createElement("div");
        formaKontejner.className="formaKontejner";
        donjiDeo.appendChild(formaKontejner);

        let prikazKontejner = document.createElement("div");
        prikazKontejner.className="prikazKontejner";
        donjiDeo.appendChild(prikazKontejner);

        this.iscrtajFormu(formaKontejner,prikazKontejner);






    }

    iscrtajFormu(host,prikaz){



        ///////////////////////////////
       

        let zasebneMarke = [];
        this.marke.forEach(p=>{
            if(!zasebneMarke.includes(p)){
                zasebneMarke.push(p);
            }
        })

        
    ////////////////////////////////

       let markaKontejner = document.createElement("div");
       markaKontejner.className="markaKontejner";
       host.appendChild(markaKontejner);

       let markaLabel = document.createElement("label");
       markaLabel.className="markaLabel";
       markaLabel.innerHTML="MARKA: "
       markaKontejner.appendChild(markaLabel);


       let markaSelect=document.createElement("select");
       markaKontejner.appendChild(markaSelect);
       zasebneMarke.forEach(p=>{
        let markaOption=document.createElement("option");
        markaOption.value=p;
        markaOption.innerHTML=p;
        markaSelect.appendChild(markaOption);
       })

       /////////////
       let modelKontejner = document.createElement("div");
       modelKontejner.className="modelKontejner";
       host.appendChild(modelKontejner);

       let bojaKontejner = document.createElement("div");
        bojaKontejner.className="bojaKontejner";
        host.appendChild(bojaKontejner);

        let buttonForma=document.createElement("button");
        buttonForma.className="buttonForma";
        buttonForma.innerHTML="PRONADJI";
        host.appendChild(buttonForma);


       this.iscrtajModele(host,modelKontejner,bojaKontejner,prikaz,markaSelect.value,buttonForma);
       markaSelect.onchange=(ev)=>this.iscrtajModele(host,modelKontejner,prikaz,markaSelect.value,buttonForma);


       
    }
    iscrtajModele(host,modelKontejner,bojaKontejner,prikaz,marka,buttonForma){

        modelKontejner.innerHTML="";
        let zasebniModeli = [];

        fetch("https://localhost:5001/Ispit/VratiSveModele/"+marka+"/"+this.id,{
            method:"GET"
        }).then(data=>{ data.json().then(info=>{
            info.forEach(p=>{
                p.modeli.forEach(q=>{
                    
                    
                        if(!zasebniModeli.includes(q)){
                            zasebniModeli.push(q);
                        }
                    
                })
            })

                 

       


        

       let modelLabel = document.createElement("label");
       modelLabel.className="modelLabel";
       modelLabel.innerHTML="MODEL: "
       modelKontejner.appendChild(modelLabel);


       let modelSelect=document.createElement("select");
       modelKontejner.appendChild(modelSelect);
       let model1Option=document.createElement("option");
       model1Option.value="nista";
       model1Option.innerHTML="";
        modelSelect.appendChild(model1Option);
       zasebniModeli.forEach(p=>{
        let modelOption=document.createElement("option");
        modelOption.value=p;
        modelOption.innerHTML=p;
        modelSelect.appendChild(modelOption);
       })

       ///////////////

       this.iscrtajBoje(host,bojaKontejner,prikaz,marka,modelSelect.value,buttonForma);
       modelSelect.onchange=(ev)=>this.iscrtajBoje(host,bojaKontejner,prikaz,marka,modelSelect.value,buttonForma);


      

        })})





        
   

    }

    iscrtajBoje(host,bojaKontejner,prikaz,marka,model,buttonForma){

        bojaKontejner.innerHTML=""

        let zasebneBoje = [];

        fetch("https://localhost:5001/Ispit/VratiSveBoje/"+marka+"/"+model+"/"+this.id,{
            method:"GET"
        }).then(data=> data.json().then(info=>{
            info.forEach(p=>{
                p.boje.forEach(q=>{

                    
                        if(!zasebneBoje.includes(q)){
                            zasebneBoje.push(q);
                        }
                   

                })
            })

        
 
        let bojaLabel = document.createElement("label");
        bojaLabel.className="bojaLabel";
        bojaLabel.innerHTML="BOJA: "
        bojaKontejner.appendChild(bojaLabel);
 
 
        let bojaSelect=document.createElement("select");
        bojaKontejner.appendChild(bojaSelect);
        let boja1Option=document.createElement("option");
        boja1Option.value="nista";
        boja1Option.innerHTML="";
         bojaSelect.appendChild(boja1Option);
        zasebneBoje.forEach(p=>{
         let bojaOption=document.createElement("option");
         bojaOption.value=p;
         bojaOption.innerHTML=p;
         bojaSelect.appendChild(bojaOption);
        })
 
        ////////
 
        
 
     
 
 
        buttonForma.onclick=(ev)=>this.iscrtajPretragu(prikaz,marka,model,bojaSelect.value);

        }))


        


        
         

        
    }

    iscrtajPretragu(host,marka,model,boja){
        
        host.innerHTML="";

        //let nizAutomobilaNaOsnovuPretrage=[];

        fetch("https://localhost:5001/Ispit/VratiPoPretrazi/marka/model/boja/idProdavnice?marka="+marka+"&model="+model+"&boja="+boja+"&idProdavnice="+this.id,{
            method:"GET"
        }).then(data=> data.json().then(info=>{
            info.forEach(a=>{
                this.nizAutomobilaNaOsnovuPretrage.push(a);
            })
            this.Crtanje(host);
        }))


    }
    Crtanje(host){
        
        this.nizAutomobilaNaOsnovuPretrage.forEach(p=>{
            host.innerHTML="";
            p.automobili.forEach(a=>{
                
            if(a.kolicina!= 0){
                    
                    let automobilKontejner = document.createElement("div");
                    automobilKontejner.className="autmobilKontejner";
                    host.appendChild(automobilKontejner);

                    let automobilMarka = document.createElement("div");
                    automobilMarka.className="automobilMarka";
                    automobilKontejner.appendChild(automobilMarka);

                    let AMLabel=document.createElement("label");
                    AMLabel.className="AMLabel";
                    AMLabel.innerHTML="Marka: "+ a.marka;
                    automobilMarka.appendChild(AMLabel);

                    let automobilModel = document.createElement("div");
                    automobilModel.className="automobilModel";
                    automobilKontejner.appendChild(automobilModel);

                    let AModelLabel=document.createElement("label");
                    AModelLabel.className="AModelLabel";
                    AModelLabel.innerHTML="MODEL: "+ a.model;
                    automobilModel.appendChild(AModelLabel);

                    let autoSlika=document.createElement("img");
                    autoSlika.className="autoSlika";
                    autoSlika.src="gg.jpg";
                    automobilKontejner.appendChild(autoSlika);

                    let automobilKolicina = document.createElement("div");
                    automobilKolicina.className="automobilKolicina";
                    automobilKontejner.appendChild(automobilKolicina);

                    let KolicinaLabel=document.createElement("label");
                    KolicinaLabel.className="KolicinaLabel";
                    KolicinaLabel.innerHTML="KOLICINA: "+ a.kolicina;
                    automobilKolicina.appendChild(KolicinaLabel);

                    let automobilDatum = document.createElement("div");
                    automobilDatum.className="automobilDatum";
                    automobilKontejner.appendChild(automobilDatum);

                    let DatumLabel=document.createElement("label");
                    DatumLabel.className="DatumLabel";
                    DatumLabel.innerHTML="Datum: "+ a.datumPoslednjeProdaje;
                    automobilDatum.appendChild(DatumLabel);

                    let automobilCena = document.createElement("div");
                    automobilCena.className="automobilCena";
                    automobilKontejner.appendChild(automobilCena);

                    let CenaLabel=document.createElement("label");
                    CenaLabel.className="CenaLabel";
                    CenaLabel.innerHTML="Cena: "+ a.cena;
                    automobilCena.appendChild(CenaLabel);

                    let kupiButton=document.createElement("button");
                    kupiButton.className="kupiButton";
                    kupiButton.innerHTML="KUPI";
                    automobilKontejner.appendChild(kupiButton);

                    kupiButton.onclick=(ev)=> this.kupiVozilo(a.id,host)
                    
                    

                
            }


            


            })
            
            

            


        })

    


        
    }
    
    kupiVozilo(id,host){
        
        fetch("https://localhost:5001/Ispit/KupiAutomobil/idAutomobila?idAutomobila="+id,{
            method:"PUT"
        }).then(data=>{data.json().then(info=>{
            alert("Uspesna Kupovina");
           
            this.nizAutomobilaNaOsnovuPretrage.forEach(p=>{
                
                p.automobili.forEach(q=>{
                    if(q.id===id){
                    q.kolicina--;
                    q.datumPoslednjeProdaje=info.datumPoslednjeProdaje;
                    }
                    this.Crtanje(host)
                })
                
            })
        })})

            

           
    }
}