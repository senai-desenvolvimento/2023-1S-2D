function calcular() {
    event.preventDefault();//parar o submit do formulário

    //criar uma variável para cada número
    let n1 = parseFloat(document.getElementById('n1').value);//campo 1
    let n2 = parseFloat(document.getElementById('n2').value);//campo 2
    let op = document.getElementById('operacao').value;//valor selecionado no select
    let resultado;//undefined
    
    // if ( isNaN(n1) || isNaN(n2) ) {
    //     alert("É necessário digitar apenas números");
    //     return;
    // }


    if (op == '+') {
        resultado = somar(n1, n2);
    } else if (op == '-') {
        resultado = subtrair(n1, n2);
    } else if (op == '*') {
        resultado = multiplicar(n1, n2);
    } else if (op == '/') {
        resultado = dividir(n1, n2);
    } else {
        resultado = "Operação Inválida"
    }
    
    //inserir o resultado no HTML (DOM)
    
    document.getElementById('result').innerText = resultado;

    // alert(`Resultado da soma é: ${resultado}`);
}//fim da função calcular

function somar(x, y) {
    return x + y;
}

function subtrair(x, y) {
    return x - y;
}

function multiplicar(x, y) {
    return x * y;
}

function dividir(x, y) {
    if (y == 0) {
        return "Não é um número";
    }
    return x / y;
}