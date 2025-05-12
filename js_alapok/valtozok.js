//A változók kezelése JS-ben dinamikus

//A var globális
var a=115; 
a="Bármi";

console.log(a);
//document.writeln(a);

//A let-el deklarált változó csak abban a scope-ban létezik, ahol létrehozták
//scope ->hatókör
let b=345;

if(b>3){
    let c="valami";
}

const konstans=567;

let szamok=[12,33,45,678];