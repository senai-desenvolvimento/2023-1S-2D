const numeros = [1, 2, 5, 10, 300];
// map passa por cada item do array original 
//e retorna um novo array, modificado
// 
const arrDobro = numeros.map((n) => {
    return n * 2;
})

console.log(numeros);
console.log(arrDobro);

const nomes = ["Eduardo", "Carlos", "Wender", "Eduardo", "Matheus"];
const sobrenomes = ["Mendes", "Roque", "Castro", "Merbach" , "Macedo"];
sobrenomes.reverse();//inverte o array

const nomesCompletos = nomes.map((nome,indice) => `${nome} ${sobrenomes[indice]}`);

nomesCompletos.forEach( nc => { console.log(nc);});

// crie 2 arrays nomes e sobrenomes
// crie um terceiro array de nomesCompletos
//ao final exiba os nomes completos no console com o foreach
//é necessário contem pelo menos 5 nomes

