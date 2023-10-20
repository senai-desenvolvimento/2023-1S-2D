//exercicio

//criar uma desestruturação para um objeto filmes
//trazer somente 3 propriedades
//crie um arquivo a parte e tente executar sem consulta

//desafio : crie um array de objetos , use desestruturação e exiba no console

// var - global scope
// let - local scope variable
// const - local scope non variable value

const filmes = [
  {
    titulo: "A Bela e a Fera",
    genero: ["Fantasia", "Romance", "Infantil"],
    descricao: "Descrição do filme",
    anoLancamento: 1980,
  },
  {
    titulo: "A Era do Gelo",
    genero: ["Ação", "Infantil"],
    descricao: "Descrição do filme",
    anoLancamento: 1980,
  },
  {
    titulo: "A Fuga das Galinhas",
    genero: ["Aventura", "Comédia", "Infantil"],
    descricao: "Descrição do filme",
    anoLancamento: 1980,
  },
];//fim do array de objetos (json??)

filmes.forEach( ( {titulo, genero}, i ) => {
//   const { titulo, genero } = f;

  console.log(`
        Fiilme${i+1}: ${titulo.toUpperCase()}
        Gênero: ${genero.toString()}
    `);
});
