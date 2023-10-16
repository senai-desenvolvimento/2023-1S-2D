let eduardo = {
    nome : "Eduardo",
    idade: 41,
    altura: 1.87
};

eduardo.peso = 89;

let carlos = new Object();

carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque";

let pessoas = [];
// let pessoas2 = new Array();

pessoas.push(carlos);
pessoas.push(eduardo);

// console.log(pessoas);
// exibir os nomes das pessoas utilizando o foreach - 3 minutos
pessoas.forEach((v, i) => {
    console.log(`Nome${i + 1}: ${v.nome}`);
});