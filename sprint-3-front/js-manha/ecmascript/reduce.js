const numeros = [10, 12, 20];

const somatorio = numeros.reduce((total, n) => {
    return total + n
}, 0);

// console.log(somatorio);

const produtos = [
    {produto: "Camiseta", preco: 129.90},
    {produto: "Tênis", preco: 350.97},
    {produto: "Jaqueta de Couro", preco: 700.01},
];

const vendedor = "Eduardo costa";

let comissao = produtos.reduce((vlInicial, oP)=> { 
    return vlInicial + (oP.preco * 0.05);
 }, 0);

 console.log(`Comissão de ${vendedor} neste mês:  R$${comissao.toFixed(2)}`);