import { Planeta } from "./Planeta.js";
import { Galaksija } from "./Galaksija.js";
import {GalaksijaBorbe} from "./GalaksijaBorbe.js";

export class BorbaSvetova{
    constructor(listaPlaneta,listaGalaksija){
        this.listaGalaksija=listaGalaksija;
        this.listaPlaneta=listaPlaneta;
        this.conteiner=null;
    }
    crtaj(host){
        this.conteiner=document.createElement("div");
        this.conteiner.className="glavniContainer";
        host.appendChild(this.conteiner);

        let gornjiDeo=document.createElement("div");
        gornjiDeo.className="gornjiDeo";
        this.conteiner.appendChild(gornjiDeo);

        let donjiDeo=document.createElement("div");
        donjiDeo.className="donjiDeo";
        this.conteiner.appendChild(donjiDeo);

        let slika=document.createElement("div");
        slika.className="slika";
        this.conteiner.appendChild(slika);

        var img = document.createElement("img");
        img.className="slikaPlaneta"
        img.src = "SlikaProjekat.jpg";
        slika.appendChild(img);

        let contForm=document.createElement("div");
        contForm.className="Form";
        gornjiDeo.appendChild(contForm);

        let contForm2=document.createElement("div");
        contForm2.className="Form2";
        donjiDeo.appendChild(contForm2);

        let contDisplay=document.createElement("div");
        contDisplay.className="Display2";
        donjiDeo.appendChild(contDisplay);

        

      
         this.crtajFormu(contForm);

        this.crtajDisplay(gornjiDeo);

          this.crtajFormu2(contForm2);

          this.crtajDisplay2(donjiDeo);

        
        
    };

    crtajRed(host){
        let red=document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;
    };
    crtajFormu(host){
        let red=this.crtajRed(host);
        let l=document.createElement("label");
        l.innerHTML="Planeta: ";
        red.appendChild(l);

        let sE=document.createElement("select");
        sE.className="selektorPlanete";
        red.appendChild(sE);

        let op;
        this.listaPlaneta.forEach(planeta=>{
            op=document.createElement("option");
            op.innerHTML=planeta.ime;
            op.value=planeta.id;
            sE.appendChild(op);
        });

        

        red=this.crtajRed(host);
        l=document.createElement("label");
        l.innerHTML="Ime ratnika";
        red.appendChild(l);
        var imeHeroja=document.createElement("input");
        imeHeroja.type="string";
        imeHeroja.className="ImeHeroja";
        red.appendChild(imeHeroja);

        red=this.crtajRed(host);
        l=document.createElement("label");
        l.innerHTML="Snaga ratnika";
        red.appendChild(l);
        var snagaHeroja=document.createElement("input");
        snagaHeroja.type="number";
        snagaHeroja.className="SnagaHeroja";
        red.appendChild(snagaHeroja);

        red=this.crtajRed(host);
        let btnDodaj=document.createElement("button");
        btnDodaj.innerHTML="Dodaj";
        btnDodaj.onclick=(ev)=>this.dodajRatnika(imeHeroja.value, snagaHeroja.value);
        red.appendChild(btnDodaj);

        let btnIzmeni=document.createElement("button");
        btnIzmeni.innerHTML="Izmeni";
        btnIzmeni.onclick=(ev)=>this.izmeniRatnika(imeHeroja.value, snagaHeroja.value);
        red.appendChild(btnIzmeni);

        let btnIzbrisi=document.createElement("button");
        btnIzbrisi.innerHTML="Izbrisi";
        btnIzbrisi.onclick=(ev)=>this.izbrisiRatnika(imeHeroja.value);
        red.appendChild(btnIzbrisi);
    }
    dodajRatnika(imeHeroja, snagaHeroja){
        
        if(imeHeroja===null||imeHeroja===undefined||imeHeroja==""){
            alert("Unesite ime ratnika");
            return;
        }
        if(snagaHeroja===""){
            alert("Unesite snagu!");
            return;
        }
        else{
            let snagaParse=parseInt(snagaHeroja);
            if(snagaParse<1||snagaParse>100){
                alert("Unesite snagu izmedju 1 i 100!");
                return;
            }
        }
        let optionEl=this.conteiner.querySelector("select")
        var planetID=optionEl.options[optionEl.selectedIndex].value;
        console.log("snaga: "+snagaHeroja); 
        console.log("ime: "+imeHeroja);
        console.log("idPlanete "+planetID);
       
        

        fetch("https://localhost:5001/Ratnik/DodatiRatnika",{
            method:"POST",
                headers:{
                    "Content-Type": "application/json"
                },
                body:JSON.stringify({
                "ime":imeHeroja,
                "snaga":snagaHeroja,
                "planetaId":planetID
               })      
        }).then(p=>{
            if(p.ok){  
                alert("Uspesno ste dodali ratnika!");
                document.location.reload()
                
            }
            else
            {
                 alert("Nastala je greska prilikom dodavanja ratnika!");
                document.location.reload();
            }
            })
        }

        izmeniRatnika(imeHeroja, snagaHeroja){
        
            if(imeHeroja===null||imeHeroja===undefined||imeHeroja==""){
                alert("Unesite ime ratnika za promenu");
                return;
            }
            if(snagaHeroja===""){
                alert("Unesite snagu!");
                return;
            }
            else{
                let snagaParse=parseInt(snagaHeroja);
                if(snagaParse<1||snagaParse>100){
                    alert("Unesite snagu izmedju 1 i 100!");
                    return;
                }
            }
            let optionEl=this.conteiner.querySelector("select")
            var planetID=optionEl.options[optionEl.selectedIndex].value;
            console.log("snaga: "+snagaHeroja); 
            console.log("ime: "+imeHeroja);
            console.log("idPlanete "+planetID);
           
            
    
            fetch("https://localhost:5001/Ratnik/PromeniRatnika",{
                method:"PUT",
                    headers:{
                        "Content-Type": "application/json"
                    },
                    body:JSON.stringify({
                    "ime":imeHeroja,
                    "snaga":snagaHeroja,
                    "planetaId":planetID
                   })      
            }).then(p=>{
                if(p.ok){  
                    alert("Uspesno ste izmenili ratnika!");
                    document.location.reload()
                    
                }
                else
                {
                     alert("Nastala je greska prilikom izmene ratnika!");
                    document.location.reload();
                }
                })
            }

            izbrisiRatnika(imeHeroja){
        
                if(imeHeroja===null||imeHeroja===undefined||imeHeroja==""){
                    alert("Unesite ime ratnika za promenu");
                    return;
                }
                
               
                console.log("ime: "+imeHeroja);
                
               
                
        
                fetch("https://localhost:5001/Ratnik/IzbrisatiRatnika/"+imeHeroja+"/",{
                    method:"DELETE"
                      
                }).then(p=>{
                    if(p.ok){  
                        alert("Uspesno ste obrisali ratnika!");
                        document.location.reload()
                        
                    }
                    else
                    {
                         alert("Nastala je greska prilikom brisanja ratnika!");
                        document.location.reload();
                    }
                    })
                }

        obrisiPrethodniSadrzaj(){
            var bodyTable=document.querySelector(".TableData");
            var roditelj=bodyTable.parentNode;
            roditelj.removeChild(bodyTable);
    
            bodyTable=document.createElement("tbody");
            bodyTable.className="TableData";
            roditelj.appendChild(bodyTable);
            return bodyTable;
        }
        
           
        
    
        crtajDisplay(host){
    
            let contDisplay=document.createElement("div");
            contDisplay.className="Display";
            host.appendChild(contDisplay);
    
            var table=document.createElement("table");
            table.className="table";
            contDisplay.appendChild(table);
    
            var tableHead=document.createElement("thead");
            table.appendChild(tableHead);
    
            var tr=document.createElement("tr");
            tableHead.appendChild(tr);
    
            var tableBody=document.createElement("tbody");
            tableBody.className="TableData";
            table.appendChild(tableBody);
    
            let th;
            this.listaPlaneta.forEach(el=>{
                th=document.createElement("th")
                th.innerHTML=el.ime;
                tr.appendChild(th);
            })

             var bodyTable = this.obrisiPrethodniSadrzaj();
                var tr=document.createElement("tr");
                bodyTable.appendChild(tr);
            this.listaPlaneta.forEach(el=>{
                var a= new Planeta(el.id,el.ime,el.imenaRatnika);
                
                
                a.crtajPlanete(tr);
             })
        }
    
        crtajFormu2(host){
            let red2=this.crtajRed(host);
            let l2=document.createElement("label");
            l2.innerHTML="Borbe u galaksiji: ";
            red2.appendChild(l2);
    
            let sE2=document.createElement("select");
            sE2.className="selektorZaGalaksije";
            red2.appendChild(sE2);
            
            let op2;
            this.listaGalaksija.forEach(planeta=>{
                op2=document.createElement("option");
                op2.innerHTML=planeta.ime;
                op2.value=planeta.id;
                sE2.appendChild(op2);
            });

            //red2=this.crtajRed(host);
        let btnPrikazi=document.createElement("button");
        btnPrikazi.innerHTML="Prikazi";
        btnPrikazi.onclick=(ev)=>this.crtajDisplay2();
        red2.appendChild(btnPrikazi);

        
           
            red2=this.crtajRed(host);
            l2=document.createElement("label");
            l2.innerHTML="Napad: ";
            red2.appendChild(l2);
            
            let sEP1=document.createElement("select");
            sEP1.className="selektorNapada";
            red2.appendChild(sEP1);
    
             let opP1;
            this.listaPlaneta.forEach(planeta=>{
                opP1=document.createElement("option");
                opP1.innerHTML=planeta.ime;
                opP1.value=planeta.id;
                sEP1.appendChild(opP1);
            });



            red2=this.crtajRed(host);
            l2=document.createElement("label");
            l2.innerHTML="Odbrana: ";
            red2.appendChild(l2);

            let sEP2=document.createElement("select");
            sEP2.className="selektorOdbrane";
            red2.appendChild(sEP2);
            
             let opP2;
            this.listaPlaneta.forEach(planeta=>{
                opP2=document.createElement("option");
                opP2.innerHTML=planeta.ime;
                opP2.value=planeta.id;
                sEP2.appendChild(opP2);
            });

            
           

        
        

             red2=this.crtajRed(host);
        let btnBitka=document.createElement("button");
        btnBitka.innerHTML="Bitka";
        btnBitka.onclick=(ev)=>this.zapocniNapad();
        red2.appendChild(btnBitka);

        red2=this.crtajRed(host);
            l2=document.createElement("label");
            l2.innerHTML="Mogu da ratuju samo <br> planete iz iste galaksije!";
            red2.appendChild(l2);
           
        }
        

        zapocniNapad(){
            var opcioniEl1=this.conteiner.querySelector(".selektorNapada");
            var napad=opcioniEl1.options[opcioniEl1.selectedIndex].value;
            var opcioniEl2=this.conteiner.querySelector(".selektorOdbrane");
            var odbrana=opcioniEl2.options[opcioniEl2.selectedIndex].value;
            

            if(napad==odbrana)
               { alert("Izaberite razlicite planete");
                return;
            }
            
            fetch("https://localhost:5001/Borba/DodajBorbu",{
                method:"POST",
                    headers:{
                        "Content-Type": "application/json"
                    },
                    body:JSON.stringify({
                    "planetaId1":napad,
                    "planetaId2":odbrana,
                    
                   })      
            }).then(p=>{
                if(p.ok){  
                    alert("Uspesno ste dodali borbu!");
                    document.location.reload()
                    
                }
                else
                {
                     alert("Nastala je greska prilikom dodavanja ratnika!");
                    document.location.reload();
                }
                })
            }
        
    
        
    crtajDisplay2(host){
    
        
        var Displey2=this.obrisiPrethodniSadrzaj2()
        
        var table=document.createElement("table");
        table.className="table2";
        Displey2.appendChild(table);

        var tableHead=document.createElement("thead");
        tableHead.className="glavaDonjeTabele"; // ovde je bilo veliko G
        
        

        // var tr=document.createElement("tr");
        // tableHead.appendChild(tr);

        var tableBody=document.createElement("tbody");
        tableBody.className="TableData2";
        table.appendChild(tableBody);

       // var listaBorbi=[];
        var optionEl=this.conteiner.querySelector(".selektorZaGalaksije");
         var galaksijaID=optionEl.options[optionEl.selectedIndex].value;
         
      
      
        //let th;
        this.listaGalaksija.forEach(el=>{
            //th=document.createElement("th")
            if(el.id==galaksijaID)
            tableHead.innerHTML=el.ime;
            //th.innerHTML=el.ime;
            //tableHead.appendChild(th);
        })
        table.appendChild(tableHead);
        
            var tr=document.createElement("tr");
            tableBody.appendChild(tr);

            fetch("https://localhost:5001/Galaksija/GalaksijaBorbe/"+galaksijaID+"/")
            .then(p=>{
               p.json().then(galaksije=>{
                    galaksije.forEach(galaksija=>{
                        var g=new GalaksijaBorbe(galaksija.ime,galaksija.planetaDomacin,galaksija.b);
                       
                       
                       g.crtajBorbe(tr,this.listaPlaneta);
                       
                        });
               });
            });
            
          

      

         
    }

    
    obrisiPrethodniSadrzaj2(){

        var bodyTable=document.querySelector(".Display2");
        var roditelj=bodyTable.parentNode;
        roditelj.removeChild(bodyTable);
        

        let contDisplay=document.createElement("div");
        contDisplay.className="Display2";
        roditelj.appendChild(contDisplay);

        return contDisplay;
    }
    
    
    


}






    

