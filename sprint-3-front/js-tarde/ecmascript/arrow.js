const somar = (x, y) => {
  return x + y;
};
// console.log( somar(50, 10) );

// const dobro = (numero) => {
//     return numero * 2;
// }

// const dobro = numero => {
//     return numero * 2;
// }

// const dobro = numero => numero * 2;
// console.log( dobro(10) );

// const boaTarde = () => { console.log("Boa tarde"); }

// boaTarde();

const convidados = [
    {nome: "Carlos", idade: 36}, 
    {nome: "Claiton", idade: 43}, 
    {nome: "Rebeca", idade: 16}, 
    {nome: "Magalhães", idade: 18}, 
    {nome: "Lucca", idade: 18}, 
    {nome: "Guilherme Henrique", idade: 18}, 
];

convidados.forEach( p => {
    console.log(`Convidado: ${p.nome}`);
})

