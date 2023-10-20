const convidados = [
  "Coral",
  "Anna",
  "Demétrio",
  "Vinícius",
  "Lacerda",
  "Evelyn",
  "Luiz",
];

// calback funcitons
convidados.forEach(
    function Carlos(cadaPessoa) {
        console.log('Bom dia ' + cadaPessoa);
    }
);

// função anônima
// mesa.forEach(function (cadaPessoa) {
//   console.log("Bom dia " + cadaPessoa);
// });

// arrow functions
// mesa.forEach( (cadaPessoa) => {
//   console.log("Bom dia " + cadaPessoa);
// });


const dobro =  function(x) {
    return x * 2;
};

console.log( dobro(5) );//10

// const dobro =  (x) => {
//     return x * 2;
// };

// forma simplificada com return implícito
// const dobro =  (x) => x * 2; //retorna o dobro

// console.log( dobro(10) );

// forma simplificada com return implícito
// const dobro =  x => x * 2; //retorna o dobro

// console.log( dobro(10) );


// const bomDia = () => "Bom dia";//retorna o texto bom dia

// console.log( bomDia() );

