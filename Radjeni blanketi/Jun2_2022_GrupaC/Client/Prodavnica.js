export class Prodavnica{
    constructor(id,ime,podrucje,cvet,list,stablo){
        this.id=id;
        this.ime=ime;
        this.podrucje=podrucje;
        this.cvet=cvet;
        this.list=list;
        this.stablo=stablo;
        this.listaBiljaka=[];
    }

    iscrtajProdavnicu(host){
        let listaPodrucja=[];
        let listaCveta=[];
        let listaLista=[];
        let listaStabla=[];
        
        this.podrucje.forEach(p=>{
            if(!listaPodrucja.includes(p))
            {
                listaPodrucja.push(p);
            }
        })
        this.cvet.forEach(p=>{
            if(!listaCveta.includes(p))
            {
                listaCveta.push(p);
            }
        })
        this.list.forEach(p=>{
            if(!listaLista.includes(p))
            {
                listaLista.push(p);
            }
        })
        this.stablo.forEach(p=>{
            if(!listaStabla.includes(p))
            {
                listaStabla.push(p);
            }
        })

        let prodavnicaKontejner = document.createElement("div");
        prodavnicaKontejner.className="prodavnicaKontjner";
        host.appendChild(prodavnicaKontejner);

        let nazivKontejner = document.createElement("div");
        nazivKontejner.className="nazivKontejner";
        prodavnicaKontejner.appendChild(nazivKontejner);

        let nazivLabel= document.createElement("label");
        nazivLabel.innerHTML=this.ime;
        nazivKontejner.appendChild(nazivLabel);

        let formaKontejner = document.createElement("div");
        formaKontejner.className="formaKontejner";
        prodavnicaKontejner.appendChild(formaKontejner);

        let prikazKontejner = document.createElement("div");
        prikazKontejner.className="prikazKontejner";
        prodavnicaKontejner.appendChild(prikazKontejner);

        this.iscrtajFormu(formaKontejner,prikazKontejner,listaPodrucja,listaCveta,listaLista,listaStabla);

    }
    iscrtajFormu(formaKontejner,prikazKontejner,listaPodrucja,listaCveta,listaLista,listaStabla){

        let podrucjeKontjner = document.createElement("div");
        podrucjeKontjner.className="podrucjeKontjner";

        let podrucjeLabel = document.createElement("label");
        podrucjeLabel.innerHTML="PODRUCJE: "
        podrucjeKontjner.appendChild(podrucjeLabel);

        let podrucjeSelect= document.createElement("select");
        listaPodrucja.forEach(p=>{
            let podrucjeOption = document.createElement("option");
            podrucjeOption.value=p;
            podrucjeOption.innerHTML=p;
            podrucjeSelect.appendChild(podrucjeOption);
        })


        podrucjeKontjner.appendChild(podrucjeSelect);

        formaKontejner.appendChild(podrucjeKontjner);

        //////

        let cvetKontejner = document.createElement("div");
        cvetKontejner.className="cvetKontejner";

        let cvetLabel = document.createElement("label");
        cvetLabel.innerHTML="CVET: "
        cvetKontejner.appendChild(cvetLabel);

        let cvetSelect= document.createElement("select");
        listaCveta.forEach(p=>{
            let cvetOption = document.createElement("option");
            cvetOption.value=p;
            cvetOption.innerHTML=p;
            cvetSelect.appendChild(cvetOption);
        })


        cvetKontejner.appendChild(cvetSelect);

        formaKontejner.appendChild(cvetKontejner);
        /////

        let listKontjner = document.createElement("div");
        listKontjner.className="listKontjner";

        let listLabel = document.createElement("label");
        listLabel.innerHTML="LIST: "
        listKontjner.appendChild(listLabel);

        let listSelect= document.createElement("select");
        listaLista.forEach(p=>{
            let listOption = document.createElement("option");
            listOption.value=p;
            listOption.innerHTML=p;
            listSelect.appendChild(listOption);
        })


        listKontjner.appendChild(listSelect);

        formaKontejner.appendChild(listKontjner);

        //////

        let stabloKontejner = document.createElement("div");
        stabloKontejner.className="stabloKontejner";

        let stabloLabel = document.createElement("label");
        stabloLabel.innerHTML="STABLO: "
        stabloKontejner.appendChild(stabloLabel);

        let stabloSelect= document.createElement("select");
        listaStabla.forEach(p=>{
            let stabloOption = document.createElement("option");
            stabloOption.value=p;
            stabloOption.innerHTML=p;
            stabloSelect.appendChild(stabloOption);
        })


        stabloKontejner.appendChild(stabloSelect);

        formaKontejner.appendChild(stabloKontejner);

        let btnPretrazi= document.createElement("button");
        btnPretrazi.className="btnPretrazi";
        btnPretrazi.innerHTML="PRETRAZI"
        formaKontejner.appendChild(btnPretrazi);

        btnPretrazi.onclick=(ev)=> this.preuzmiBiljke(prikazKontejner,podrucjeSelect.value,cvetSelect.value,listSelect.value,stabloSelect.value);
    }
    preuzmiBiljke(prikazKontejner,podrucje,cvet,list,stablo){
        
        this.listaBiljaka=[];
        fetch("https://localhost:5001/Ispit/VratiBiljke/"+podrucje+"/"+cvet+"/"+list+"/"+stablo,{
            method:"GET"
        }).then(data=> { 
            if(data.status===400){
                alert("Cvet ne postoji ali ubaveno je u bazu")
            }
            data.json().then(info=>{
            
            info.forEach(i=>{
                this.listaBiljaka.push(i);
            })
            
            this.iscrtajPrikaz(prikazKontejner);
        })
    })
    }
    iscrtajPrikaz(prikazKontejner){
        
        
        prikazKontejner.innerHTML="";
       
        this.listaBiljaka.forEach(b=>{

            

            let biljkaKontejner= document.createElement("div");
            biljkaKontejner.className="biljkaKontejner";

            let biljkaSlika=document.createElement("img");
            biljkaSlika.className="biljkaSlika";
            biljkaSlika.src="";
            biljkaKontejner.appendChild(biljkaSlika);

            let biljkaIme=document.createElement("label")
            biljkaIme.innerHTML=b.naziv;
            biljkaKontejner.appendChild(biljkaIme);

            let biljkaBr=document.createElement("label");
            biljkaBr.innerHTML=b.brPronadjenih;
            biljkaKontejner.appendChild(biljkaBr);

            biljkaKontejner.onclick=(ev)=>this.povecajBroj(b.id,prikazKontejner)


            prikazKontejner.appendChild(biljkaKontejner);
        })

        
    }
    povecajBroj(id,prikazKontejner){
        fetch("https://localhost:5001/Ispit/PovecajUocavanje/"+id,{
            method:"PUT"
        }).then(data=> { data.json().then(info=>{

            this.listaBiljaka.forEach(p=>{
                if(p.id===id)
                {
                    p.brPronadjenih++;
                }
                this.iscrtajPrikaz(prikazKontejner);
            })
        })})
    }

}