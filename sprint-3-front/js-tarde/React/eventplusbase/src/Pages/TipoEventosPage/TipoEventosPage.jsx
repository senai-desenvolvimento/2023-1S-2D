import React, { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";

import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";



const TipoEventosPage = () => {

  // state do componente Notification
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(false);

  const [frmEdit, setFrmEdit] = useState(false);
  
  const [titulo, setTitulo] = useState("");
  const [idEvento, setIdEvento] = useState(null);//usar apenas para a edição

  const [tipoEventos, setTipoEventos] = useState([]); //array mocado

  // Ao carregar a página
  useEffect(()=> {
    async function getTipoEventos() {
     setShowSpinner(true);
      try {
        const retorno = await api.get('/TiposEvento');
        console.log(retorno);
        setTipoEventos(retorno.data)

      } catch (error) {
        console.log("Deu ruim na api");
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Deu ruim na api`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
        // console.log(error);
      }
      
      setShowSpinner(false);
    }

    getTipoEventos();
  }, []);


  
// Cadastrar
  async function handleSubmit(e) {
    // parar o submit do formulário
    e.preventDefault();
    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O Título deve ter no mínimo 3 caracteres`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }
    // chamar a api
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });
      
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      console.log(retorno.data);
      setTitulo(""); //limpa a variável

      const retornoGet = await api.get('/TiposEvento');
      setTipoEventos(retornoGet.data);

    } catch (error) {
      console.log("Deu ruim na api:");
      console.log(error);
    }
  }

  /********************* EDITAR CADASTRO *********************/

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    // criar um state para idEvento igual ao título ***

    try {
      // fazer um get by id para pegar os dados
      const retorno = await api.get('/TiposEvento/' + idElemento );
      
      // preencher o título e o id no state 
      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);

    } catch (error) {
      alert("Não foi possível mostrar a tela de edição. tente novamente")
    }

  }

  async function handleUpdate(e) {
    e.preventDefault();

    try {
      // salvar os dados
      const retorno = await api.put('/TiposEvento/' + idEvento, {
        titulo: titulo
      })

      // atualizar o state (api get)
      const retornoGet = await api.get('/TiposEvento');
      setTipoEventos(retornoGet.data);//atualiza o state da tabela
      alert("Atualizado com sucesso!");
      // limpar o state do título e do idEvento
      editActionAbort();

    } catch (error) {
      alert ("Problemas na atualização. Verifique a conexão com a internet!")
    }
  }

  // reseta o state e cancela a tela de edição
  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("");
    setIdEvento(null);
  }

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);

      // alert("Registro apagado com sucesso");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Registro apagado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      
      const retornoGet = await api.get('/TiposEvento');
      setTipoEventos(retornoGet.data)

    } catch (error) {
      console.log("Erro ao excluir");
    }
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      { showSpinner ? <Spinner /> : null }
      
      {/* Cadastro de tipo de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator
              alterText={"??????"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                <>
                  {/* Cadastrar */}
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <>
                  {/* Editar */}
                  <Input 
                    id="titulo"
                    placeholder="Título"
                    name="titulo"
                    type="text"
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) =>{
                      setTitulo(e.target.value)
                    }}
                  />

                  <div className="buttons-editbox">
                    <Button 
                      textButton="Atualizar"
                      id="atualizar"
                      name="atualizar"
                      type="submit"
                      additionalClass="button-component--middle"
                    />
                    <Button 
                      textButton="Cancelar"
                      id="cancelar"
                      name="cancelar"
                      type="button"
                      manipulationFunction={editActionAbort}
                      additionalClass="button-component--middle"
                    />
                  </div>
                </>
              )}

              {/*  */}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipo de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />

          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>

    </MainContent>
  );
};

export default TipoEventosPage;
