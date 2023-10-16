let pratileira = [
    "Cerveja", 
    "Coca-Cola", 
    "Água", 
    "Gatorade", 
    "Corote",
    "H2O",
    "Guaraná Antártica",
    "Tubaina"
];

let bebida = pratileira[7]

switch (bebida) {
    case "Cerveja":
        console.log("Achei sua Cerveja!!");
        break;
    case "Coca-Cola":
        console.log("Achei sua Coca!!");
        break;
    case "Água":
        console.log("Achei sua Água!!");
        break;
    case "Gatorade":
        console.log("Achei seu Gatorade!!");
        break;
    case "Tubaina":
        console.log("Toma aki sua Tuba!!");
        break;
    case "Guaraná Antártica":
        console.log("Guaraná bem gelado saindo!!");
        break;
    case "H2O":
        console.log("H2O na mesa!!");
        break;
    case "Corote":
        console.log("Corote");
        break;
    default:
        console.log(`Não temos essa bebina: (${bebida})`);
        break;
}

console.log("Eduardo Costa");