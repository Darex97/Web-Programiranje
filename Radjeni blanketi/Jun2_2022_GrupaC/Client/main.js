import { Prodavnica } from "./Prodavnica.js";

let nizProdavnica = [];

let glavniKontejner = document.createElement("div");
glavniKontejner.className="glavniKontejner";
document.body.appendChild(glavniKontejner);

function iscrtajProdavnice(){
    nizProdavnica.forEach(e=>{
        e.iscrtajProdavnicu(glavniKontejner);
    })
}

fetch("https://localhost:5001/Ispit/Prodavnice",{
    method:"GET"
}).then(data=> { data.json().then(info=>{
    info.forEach(i=>{
            let prod = new Prodavnica(i.id,i.ime,i.podrucje,i.cvet,i.list,i.stablo)
            nizProdavnica.push(prod);
    })
    iscrtajProdavnice();
})
})