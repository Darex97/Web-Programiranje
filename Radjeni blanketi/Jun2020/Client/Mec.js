
export class Mec{
    constructor(id,lokacija,datum,set1,set2,ps11,ps12,ps21,ps22,igraci){
        this.id=id;
        this.lokacija=lokacija;
        this.datum=datum;
        this.set1=set1;
        this.set2=set2;
        this.ps11=ps11;
        this.ps12=ps12;
        this.ps21=ps21;
        this.ps22=ps22;
        this.igraci=igraci;

    }

    iscrtajMec(host){
        let ceoTurnir=document.createElement("div");
        ceoTurnir.className="ceoTurnir";
        host.appendChild(ceoTurnir);
        let turnirKontejner=document.createElement("div");
        turnirKontejner.className="turnirKontejner";
        ceoTurnir.appendChild(turnirKontejner);
        let turnirLabela=document.createElement("label");
        turnirLabela.className="turnirLabela";
        turnirLabela.innerHTML="Lokacija:"+this.lokacija+"<br>"+"Vreme: "+this.datum;
        turnirKontejner.appendChild(turnirLabela);

        let donjiDeo=document.createElement("div");
        donjiDeo.className="donjiDeo";
        ceoTurnir.appendChild(donjiDeo);

        let prviIgracKontejner=document.createElement("div");
        prviIgracKontejner.className="prviIgracKontejner";
        donjiDeo.appendChild(prviIgracKontejner);
        let prviSlika=document.createElement("img");
        prviSlika.className="slika";
        prviSlika.src="k.png";
        prviIgracKontejner.appendChild(prviSlika);
        let prviLabela=document.createElement("label");
        prviLabela.innerHTML="Ime: "+this.igraci[0].ime +"<br>Godine: "+ this.igraci[0].godine+"<br> ATPRank: "+this.igraci[0].rank;
        prviIgracKontejner.appendChild(prviLabela);
//////////////////////


        let rezultat=document.createElement("div");
        rezultat.className="rezultat";
        donjiDeo.appendChild(rezultat);
        this.iscrtajRezultat(rezultat);

        
//////////////////////////
        let drugiIgracKontejner=document.createElement("div");
        drugiIgracKontejner.className="drugiIgracKontejner";
        donjiDeo.appendChild(drugiIgracKontejner);
        let drugiSlika=document.createElement("img");
        drugiSlika.className="slika";
        drugiSlika.src="g.png";
        drugiIgracKontejner.appendChild(drugiSlika);
        let drugiLabela=document.createElement("label");
        drugiLabela.innerHTML="Ime: "+this.igraci[1].ime +"<br>Godine: "+ this.igraci[1].godine+"<br> ATPRank: "+this.igraci[1].rank;
        drugiIgracKontejner.appendChild(drugiLabela);
    }
    iscrtajRezultat(host){

        host.innerHTML="";
        let labelaRez=document.createElement("label");
        labelaRez.className="labelaRez";
        labelaRez.innerHTML="REZULTAT <br>";
        host.appendChild(labelaRez);

        let labelaSetovi=document.createElement("label");
        labelaSetovi.innerHTML=this.set1+"-"+this.set2;
        host.appendChild(labelaSetovi);

        let labelaRez2=document.createElement("label");
        labelaRez2.innerHTML="("+this.ps11+"-"+this.ps12+"),"+"("+this.ps21+"-"+this.ps22+")";
        host.appendChild(labelaRez2);

        let btnDiv=document.createElement("div");
        btnDiv.className="btnDiv";
        host.appendChild(btnDiv);
        let btn1=document.createElement("button");
        btn1.name=this.igraci[0];
        btn1.innerHTML="+";
        btnDiv.appendChild(btn1);
        let btn2=document.createElement("button");
        btn2.name=this.igraci[1];
        btn2.innerHTML="+";
        btnDiv.appendChild(btn2);

        btn1.onclick=(ev)=>this.prvi(host);
        btn2.onclick=(ev)=>this.drugi(host);
    }
    prvi(host){
        fetch("https://localhost:5001/Mec/DodajPoenPrviIgrac/"+this.id,{
            method:"PUT"
        }).then(data=>{
            
            if(data.status==400)
            alert("Kraj meca")
            data.json().then(info=>{
            

                if(this.set1+this.set2==2)
                alert("kraj meca")
                if(this.set1===0 && this.set2===0){
                    this.ps11++;
                    if(this.ps11===6)
                this.set1++;
                }
                else{
                    this.ps21++;
                    if(this.ps21===6)
                    this.set1++;
                }
                
                
                this.iscrtajRezultat(host);
            })
        })
    }
    drugi(host){
        fetch("https://localhost:5001/Mec/DodajPoenDrugiIgrac/"+this.id,{
            method:"PUT"
        }).then(data=>{
            if(data.status==400)
            alert("Kraj meca")
            data.json().then(info=>{
                if(this.set1+this.set2==2)
                alert("kraj meca")
                if(this.set1===0 && this.set2===0){
                    this.ps12++;
                    if(this.ps12===6)
                     this.set2++;
                }
                else{
                    this.ps22++;
                    if(this.ps22===6)
                    this.set2++;
                }
                
                this.iscrtajRezultat(host);
            })
        })
    }
}