import { Fabrika } from "./Fabrika.js";

let nizFabrika=[];

let glavniKontejner=document.createElement("div");
glavniKontejner.className="glavniKontejner";
document.body.appendChild(glavniKontejner);

function iscrtajFabrike(){
    nizFabrika.forEach(p=>{
        p.iscrtajFabriku(glavniKontejner);
    })
}

fetch("https://localhost:5001/Fabrika/VratiFabrike",{
    method:"GET"
}).then(data=>{data.json().then(info=>{
    info.forEach(i=>{
        let fabrika=new Fabrika(i.id,i.naziv,i.silosi);
        
        nizFabrika.push(fabrika);

    })
    iscrtajFabrike();
    
});
});