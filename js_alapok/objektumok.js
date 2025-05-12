//Objektumok ->adatok, metódusok (metódus=függvény)

let szemely={
    vezeteknev:"Kocsis",
    keresztnev:"Emma",
    szulev:1994,
    kor(){
        return new Date().getFullYear()-this.szulev;
    }
};

console.log(szemely);
console.log(szemely.vezeteknev+" "+szemely.keresztnev);
console.log(szemely.kor());

class Szemely {
    constructor(vezeteknev,keresztnev,szuletesiev){
        this.vezeteknev=vezeteknev,
        this.keresztnev=keresztnev,
        this.szuletesiev=szuletesiev
    }
    kor(){
        return new Date().getFullYear()-this.szuletesiev;
    }

}

let zoltan=new Szemely("Novák","Zoltán",2001);

console.log(zoltan.vezeteknev);
console.log(zoltan.keresztnev);
console.log(zoltan.kor());

const dolgozo={
    vezeteknev:"Váradi",
    keresztnev:"Miklós",
    szulev:1999,
    lakhely:{
        helyseg:"Szeged",
        utca:"Petőfi",
        hazszam:34
    },
    munkahely:{
        cegnev:"Csőd Kft",
        beosztas:"éjjeliőr"
    },
    vegzettsegek:["lakatos","kőműves","portás"]
}

console.log(dolgozo.lakhely);
console.log(dolgozo.vegzettsegek);