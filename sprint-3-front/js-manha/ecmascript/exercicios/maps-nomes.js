const nomes = [
    "Eduardo",
    "Carlos"
]
const sobrenomes = [
    "Mendes",
    "Roque"
]

const nomesCompletos = nomes.map((v, i) => `${v} ${sobrenomes[i]}`)

nomesCompletos.forEach(nC => {
    console.log(nC);
});
