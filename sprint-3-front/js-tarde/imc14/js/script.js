// lista global
const listaPessoas = []; //lista vazia

function calcular(e) {
  e.preventDefault(); //interrompe/captura o evento disparado

  let nome = document.getElementById("nome").value.trim(); //limpa a string
  let altura = parseFloat(document.getElementById("altura").value); //NaN
  let peso = parseFloat(document.getElementById("peso").value);

  // verifica se há algum campo sem preencher
  if (isNaN(altura) || isNaN(peso) || nome.lenght < 2) {
    alert("É necessário preencher todos os campos");
    return;
  }

  const imc = calcularImc(peso, altura);
  const txtSituacao = geraSituacao(imc);

  const pessoa = {
    //object short sintaxe
    nome,
    altura,
    peso: peso,
    imc: imc,
    situacao: txtSituacao,
  };

  //insere uma pessoa no array
  listaPessoas.push(pessoa);

  exibirDados();
  limparFormulário();
}

function limparFormulário() {
  document.getElementById("nome").value = "";
  document.getElementById("altura").value = "";
  document.getElementById("peso").value = "";
}

function calcularImc(peso, altura) {
  return peso / Math.pow(altura, 2);
}

/*
    Resultado	        Situação
    Menor que 18.5      Magreza Severa
    Entre 18.5 e 24.99	Peso normal
    Entre 25 e 29.99	Acima do peso
    Entre 30 e 34.99	Obesidade I
    Entre 35 e 39.99	Obesidade II
    Acima de 40	        Cuidado!!! else
*/
function geraSituacao(imc) {
  if (imc < 18.5) {
    return "Magreza Severa";
  } else if (imc < 25) {
    return "Peso normal";
  } else if (imc < 30) {
    return "Acima do peso";
  } else if (imc < 35) {
    return "Obesidade I";
  } else if (imc < 40) {
    return "Obesidade II";
  } else {
    return "Cuidado!!!";
  }
}

function exibirDados() {
  let linhas = "";

  listaPessoas.forEach(function (oPessoa) {
    linhas += `
        <tr>
             <td>${oPessoa.nome}</td>
            <td>${oPessoa.altura}</td>
            <td>${oPessoa.peso}</td>
            <td>${oPessoa.imc.toFixed(2)}</td>
            <td>${oPessoa.situacao}</td>
          </tr>
    `;
  });

  document.getElementById("cadastro").innerHTML = linhas;
}