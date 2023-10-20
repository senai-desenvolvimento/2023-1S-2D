const ulrViaCep = "https://viacep.com.br/ws";

function cadastrar(e) {
  e.preventDefault();
  alert("Cadastrar ...");
}

async function buscarEndereco(cep) {
  // complemento do endereço da api
  const resource = `/${cep}/json/`;

  try {
    const promise = await fetch(ulrViaCep + resource);
    
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
