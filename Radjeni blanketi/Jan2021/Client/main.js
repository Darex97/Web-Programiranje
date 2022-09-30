import { Gradovi } from "./Gradovi.js";


let GradoviInstance=[];

let glavniKontejner=document.createElement("div");
glavniKontejner.className="glavniKontejner";
document.body.appendChild(glavniKontejner);

function iscrtajGradove(){
    GradoviInstance.forEach(e=> {
        e.iscrtajGrad(glavniKontejner);
    })
}

fetch("https://localhost:5001/Grad/UzmiGradove",{
    method:"GET"
}).then(data => {data.json().then(info=> {
    info.forEach(i =>{
        let grad=new Gradovi(i.id,i.nazivGrada,i.x,i.y,i.meteoroloskiPodataci);
        GradoviInstance.push(grad);
    })
    iscrtajGradove(); 
});
});