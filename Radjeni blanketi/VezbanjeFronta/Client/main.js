import { novo } from "./novo.js";

 let glavniKontejner=document.createElement("div");
 glavniKontejner.className="glavniKontejner";
 document.body.appendChild(glavniKontejner);
 let n = new novo();
 function iscrtaj1(){
    
    n.iscrtaj2(glavniKontejner);
 }
 iscrtaj1();

 