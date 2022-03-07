export class GalaksijaBorbe {

    constructor(ime, planetaDomacin, borbe) {
        this.ime = ime;
        this.planetaDomacin = planetaDomacin;
        this.borbe = borbe;
        this.container = null;
    }
    crtajBorbe(host, listaplaneta) {

        var el = document.createElement("td");
        el.className="td2";
        var borba = "";
        var protivnik = "";
        var planeta = "";
        this.borbe.forEach(e => {

            if (this.planetaDomacin == e.pobednik && e.pobednik != -1) {
                listaplaneta.forEach(p => {

                    if (p.id == e.druga)
                        protivnik = p.ime;

                })
                borba = borba + e.vreme + "<br>" + this.ime + " je pobednik <br>protivnik je: " + protivnik + "<br>";
            }
            else if (this.planetaDomacin != e.pobednik && e.pobednik != -1) {
                listaplaneta.forEach(p => {

                    if (p.id == e.prva)
                        protivnik = p.ime;

                })
                borba = borba + e.vreme + "<br>" + this.ime + " je gubitnik <br>protivnik je: " + protivnik + "<br>";

            }
            else {
                listaplaneta.forEach(p => {

                    if (p.id == e.druga) {
                        protivnik = p.ime;
                    }
                    else if (p.id == e.prva) {
                        planeta = p.ime;
                    }
                })
                borba = borba + e.vreme + "<br>" + "Nereseno " + planeta + " i<br> " + protivnik + "<br>";

            }
            el.innerHTML = borba;

        })
        host.appendChild(el);

    }
}