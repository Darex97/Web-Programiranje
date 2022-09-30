import { Planeta } from "./Planeta.js";
import { BorbaSvetova } from "./BorbeSvetova.js";
import { Galaksija } from "./Galaksija.js";

var listaGalaksija = []
var listaPlaneta = [];
fetch("https://localhost:5001/Planeta/PrikaziPlanete")
    .then(p => {
        p.json().then(planete => {
            planete.forEach(planeta => {

                var p = new Planeta(planeta.idPlanete, planeta.imePlanete, planeta.ratnici);

                listaPlaneta.push(p);
            });

            fetch("https://localhost:5001/Galaksija/SamoNaziviGalaksija")
                .then(p => {
                    p.json().then(galaksije => {
                        galaksije.forEach(galaksija => {
                            var g = new Galaksija(galaksija.id, galaksija.imeGalaksije);
                            listaGalaksija.push(g);

                        });
                        var B = new BorbaSvetova(listaPlaneta, listaGalaksija);
                        B.crtaj(document.body);
                    });
                });
        });
    });

