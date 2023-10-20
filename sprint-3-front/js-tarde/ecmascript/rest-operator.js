// const camisaLacoste = {
//     descricao: "Camisa Lacoste",
//     preco: 399.98,
//     marca: "Lacoste",
//     tamanho: "G",
//     cor: "Azul",
//     promo: false
// }
// const { descricao, preco, promo } = camisaLacoste;

// console.log(`
//     Produto: ${descricao}
//     Preço: R$${preco}
//     Promoção: ${promo ? "sim" : "Não"}
// `);

/*
    Crie um objeto evento com as propriedades 
        * DATA EVENTO
        * DESCRIÇÃO DO EVENTO
        * TÍTULO
        * PRESENÇA
        * COMENTÁRIO

    Crie uma destructuring das propriedades do objeto evento e as exiba no console.

    OBS: para a presença deve-se exibir "sim" ou "não"

*/
const evento = {
    dataEvento: new Date(),
    descricao : "Venha aprender JavaScript e todo seu poder!!",
    titulo: "Mão na massa EcmaScript",
    presenca : true,
    comentario: "Gostei do evento"
}
//o rest 
const {dataEvento, descricao, titulo, ...resto} = evento;


console.log(dataEvento);
console.log(descricao);
console.log(titulo);
console.log(resto);


// console.log(`
//     Evento: ${titulo}
//     Descrição: ${descricao}
//     Data: ${dataEvento}
//     Presença: ${presenca ? "Confirmada": "Não confirmada"}
//     Comentário: ${comentario}
// `);