let root=document.getElementById('root');

let cimsor2=document.createElement('h2');
cimsor2.textContent="Elemek létrehozása";
root.appendChild(cimsor2);

let nevek=["Elek","Géza","Ella","Ubul","Éva"];

//Készítsünk egy listát a nevekkel, amely az oldalban megjelenik!

let lista=document.createElement('ul');

for (let i =0; i< nevek.length; i++){
    let listaelem=document.createElement('li');
    listaelem.textContent=nevek[i];
    lista.appendChild(listaelem);
}
    
root.appendChild(lista);


