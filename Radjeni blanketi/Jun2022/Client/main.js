import { Prodavnica } from "./Prodavnica.js";

let nizProdavnica=[];

let glavniKontejner=document.createElement("div");
glavniKontejner.className="glavniKontejner";
document.body.appendChild(glavniKontejner);

function iscrtajProdavnice(){
    
    nizProdavnica.forEach(p=>{
        
        p.iscrtajProdavnicu(glavniKontejner);
    })
}

fetch("https://localhost:5001/Ispit/VratiSveProdavnice",{
    method:"GET"
}).then(data=>{data.json().then(info=> {
    
    info.forEach(p=>{
        
        let prodavnica= new Prodavnica(p.id,p.naziv,p.marke,p.modeli,p.boje);

        nizProdavnica.push(prodavnica);

    });
    iscrtajProdavnice();
    });
        

})

