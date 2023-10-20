const numeros = [1, 2, "200", 10, 7, 12, 15, 8];

// console.log(numeros);

const nMenor10 = numeros.filter((n) => {
    return n < 10;
})
// console.log(nMenor10);

const doisDuzentos = numeros.filter((n) => {
    return n === 2 || n === '200';
})

console.log(doisDuzentos);


const comentarios = [
    {comentario: "bla bla bla", exibe: true},
    {comentario: "Evento é uma merda", exibe: false},
    {comentario: "Ótimo Evento!", exibe: true}
];

const comentariosOk = comentarios.filter( (c) => {
    return c.exibe === true;
});

// console.log(comentariosOk);


