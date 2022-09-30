import { Mec } from "./Mec.js";

let nizMeceva=[];

let glavniKontejner=document.createElement("div");
glavniKontejner.className="glavniKontejner";
document.body.appendChild(glavniKontejner);

function iscrtajMeceve(){
    nizMeceva.forEach(p=>{
        p.iscrtajMec(glavniKontejner);
    })
}

fetch("https://localhost:5001/Mec/VratiMeceve",{
    method:"GET"
}).then(p=>{
    p.json().then(info=>{
        info.forEach(m=>{
            let p=new Mec(m.id,m.lokacija,m.datum,m.s1,m.s2,m.pS11,m.pS12,m.pS21,m.pS22,m.igraci);
            nizMeceva.push(p);
        })
        iscrtajMeceve();
    })
})