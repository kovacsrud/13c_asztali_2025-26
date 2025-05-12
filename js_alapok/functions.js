
function osszead(a,b,c){
    return a+b+c;
}

console.log(osszead(10,20,30));

function osszead2(a,b=10,c=20){
    return a+b+c;
}

console.log(osszead2(10));
console.log(osszead2(20,30));
console.log(osszead2(30,30,40));

//Arrow function
const osszeg=(a,b,c)=>a+b+c;

console.log(osszeg(100,100,100));

//Hogyan lehetne olyan függvényt írni, amely tetszőleges számú paramétert képes fogadni?

function sum(){
    let osszeg=0;
    for(let i=0;i<arguments.length;i++){
        osszeg+=arguments[i];
    }
    return osszeg;
}

console.log(sum(1,2));
console.log(sum(1,2,45,78));
console.log(sum(1,2,113,789,56,1233));