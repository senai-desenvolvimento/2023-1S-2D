const ulrViaCep = "https://viacep.com.br/ws";
const ulrCepProfessor = "http://172.16.35.155:3000/myceps";
const ulrContato = "http://localhost:3000/contatos";

async function cadastrar(e) {
  e.preventDefault();
  
  //pega os valores dos campos de formulário
  const nome = document.getElementById("nome").value.trim();
  const email = document.getElementById("email").value.trim();
  const cep = document.getElementById("cep").value;
  const endereco = document.getElementById("endereco").value.trim();
  const numero = document.getElementById("numero").value;
  const cidade = document.getElementById("cidade").value.trim();
  const estado = document.getElementById("estado").value.trim();
  
  // extra - fazer a validação (dica - crie uma função : bool)
  // if( validaForm(nome, endereco, cep) ) {//tem campo vazio
  //   alert("Preencher todos os campos");
  //   return;
  // }

  ojbCadastro = { nome, email, cep, endereco, numero, cidade, estado }

  try {
    const promise = await fetch(ulrContato,{
      body: JSON.stringify(ojbCadastro),
      method: "post",
      headers: {"Content-type" : "application/json"} 
    });

    const dados = await promise.json()

  } catch (error) {
    console.log("Deu ruim");
    console.log(error);
  }
    

}







// function validaForm(nome, endereco, cep) {//tem campo sem preencher
//   console.log(nome);
//   console.log(endereco);
//   console.log(cep);

//   if(
//     nome.length == 0  ||  nome === undefined || 
//     endereco.length == 0  ||  endereco === undefined ||
//     cep.length < 8 || cep === undefined
//   ){ //algum campo estiver sem preencher
//     return false
//   }

//   return true;
// }

async function buscarEndereco(cep) {
  // complemento do endereço da api
  const resource = `/${cep}/json/`;

  try {
    const promise = await fetch(ulrViaCep + resource);

    // const promise = await fetch(`${ulrCepProfessor}/${cep}`);
    
    //transformo o json retonado em um objeto ou array
    const endereco = await promise.json();
    console.log(endereco);
    
    //preencher o formulário
    preencherCampos({ 
        logradouro: endereco.logradouro,
        localidade: endereco.localidade,
        uf: endereco.uf
     });

    //resetar o span do cep inválido
    document.getElementById("not-found").innerText = "";

  } catch (error) {
    console.log(error);

    document.getElementById("not-found").innerText = "cep inválido";
  }
}

function preencherCampos(endereco) {
    document.getElementById("endereco").value = endereco.logradouro;
    document.getElementById("cidade").value = endereco.localidade;
    document.getElementById("estado").value = endereco.uf;
}
