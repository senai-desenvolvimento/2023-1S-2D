const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 589.97,
    tamanho: "m",
    cor: "Amarela",
    presente: true
}

const {descricao, preco} = camisaLacoste;
const {presente} = camisaLacoste;

console.log(`
PRODUTO:
    Descrição: ${descricao}
    Preço: ${preco}
    Presente: ${ presente ? "sim" : "Não" } 
`);


const evento = {
    dataEvento : new Date(),
    descricaoEvento : "evento de javascript",
    titulo : "programação web",
    presencaEvento : true,
    comentario : "evento top com o edu"
}

const {dataEvento,descricaoEvento,titulo,presencaEvento,comentario} = evento


console.log(`
${dataEvento}
${descricaoEvento}
${titulo}
${presencaEvento}
${comentario}
`);

