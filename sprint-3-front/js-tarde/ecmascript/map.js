//foreach - void
//map - novo array modificado
//filter - novo array modificado
//reduce - valor unificado do array

// MAP
// const numeros = [1, 2, 5, 10, 300];

// const dobro = numeros.map( (n) => {
    //     return n * 2
    // } );
    
    // console.log(numeros);
    // console.log(dobro);






    // FILTER - retorna um novo array apenas com elementos que atenderam a uma condição

    // const numeros = [1, 2, 5, 10, 300];

    // const maior10 = numeros.filter((e) => {
    //     return e >= 10;
    // });
    
    // console.log(maior10);



    // const comentarios = [
    //     {comentario: "bla bla bla", exibe: true},
    //     {comentario: "Evento foi uma", exibe: false},
    //     {comentario: "Ótimo Evento!", exibe: true},
    // ];

    // const comentariosOk = comentarios.filter((c) => {
    //     return c.exibe === true;
    //     // return c.exibe;
    // })

    // console.log(comentarios);
    // console.log(comentariosOk);
    // ===
    // exibir os comentários no console, utilizando o foreach
    // comentariosOk.forEach((c) => {
    //     console.log(c.comentario);
    // });




    const numeros = [1, 2, 5, 10, 300];

    const soma = numeros.reduce( (vlInicial, numero)=>{
        return  vlInicial + numero;
    }, 20);

    console.log(soma);



