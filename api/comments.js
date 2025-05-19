

//Adatok letöltése a kiszolgálóról
fetch("https://jsonplaceholder.typicode.com/comments")
.then(res=>res.json())
.then(kommentek=>{
    //Mindent itt kell megcsinálni az adatokkal
    let comments=document.getElementById('comments');
    kommentek.forEach(komment => {
        //név
        let kontener=document.createElement('div');
        kontener.setAttribute('class','w-96 h-70 bg-sky-200 m-5');
        let name=document.createElement('p');
        name.textContent=komment.name;
        name.setAttribute('class','font-bold text-sky-600 mx-5');
        kontener.appendChild(name);
        //email
        let p=document.createElement('p');
        p.textContent=komment.email;
        p.setAttribute('class','font-bold text-sky-800 mx-5');
        kontener.appendChild(p);
        //body
        let body=document.createElement('p');
        body.textContent=komment.body;
        body.setAttribute('class','text-sky-400 m-5');
        kontener.appendChild(body);

        comments.appendChild(kontener);
        
    });

})
.catch(err=>console.log(err));