let eduardo = {
    nome : "Eduardo",
    idade: 41,
    altura: 1.67
}; // objeto literal

let carlos = new Object();
carlos.nome = "Carlos";
carlos.idade = 36;

// console.log(  typeof(eduardo));
// console.log(  typeof(carlos) );

const fruta = {}


const sacola = new Object();
sacola.itens = [];//lista/array

sacola.guardarItem = function(item) {//método
    this.itens.push(item);
}

sacola.guardarItem("banana");

console.log(sacola.itens);







// console.log( typeof(fruta) );
// console.log( typeof(sacola) );

// fruta.descricao = "Maçã"

// console.log( fruta );

// fruta.peso = 0.300;

// console.log( fruta );