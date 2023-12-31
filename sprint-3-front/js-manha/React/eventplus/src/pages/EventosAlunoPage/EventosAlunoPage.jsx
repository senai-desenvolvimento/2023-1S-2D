import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    loadEventsType();
  }, [tipoEvento, userData.userId]);

  async function loadEventsType() {
    setShowSpinner(true);
    try {
      if (tipoEvento === "1") {
        //todos os eventos
        const promise = await api.get("/Evento");
        const promiseEventos = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );

        console.clear();
        console.log("TODOS OS EVENTOS");
        console.log(promise.data); //

        console.log("MEUS EVENTOS");
        console.log(promiseEventos.data);

        const dadosMarcados = verificaPresenca(
          promise.data,
          promiseEventos.data
        );
        console.log("DADOS MARCADOS");
        console.log(dadosMarcados);

        setEventos(promise.data);
        // console.log(promise.data);
      } else {
        //meus eventos
        let arrEventos = [];
        const promiseEventos = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );
        promiseEventos.data.forEach((element) => {
          arrEventos.push({
            ...element.evento,
            situacao: element.situacao,
            idPresencaEvento: element.idPresencaEvento,
          });
        });
        setEventos(arrEventos);
        console.log(promiseEventos.data);
      }
    } catch (error) {
      console.log("Erro ao carregar os eventos");
      console.log(error);
    }
    setShowSpinner(false);
  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      //para cada evento (todos)

      //varifica se o aluno está participando do evento atual (x)
      for (let i = 0; i < eventsUser.length; i++) {
        //verifica em meus eventos
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break;
        }
      }
    }
    //devolve o array modificado
    return arrAllEvents;
  };

  // const todosEventos = [
  //   {tipoEvento: 1, nomeEvento: "Evento de JS"},
  //   {tipoEvento: 10, nomeEvento: "Evento de SQL", presenca: true},//sql
  //   {tipoEvento: 22, nomeEvento: "Evento de Mysql"},
  //   {tipoEvento: 50, nomeEvento: "Evento de React", presenca: true},//
  //   {tipoEvento: 2, nomeEvento: "Evento de C#"},
  // ];

  // const meusEvento = [//presenças no evento
  // {tipoEvento: 10, nomeEvento: "Evento de SQL", presenca: true},
  // {tipoEvento: 50, nomeEvento: "Evento de React", presenca: true},
  // ];

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }


  // ler um comentário - get
  async function loadMyComentary(idComentary) {
    
    alert("Carregar o comentário");
  }
  
  // cadastrar comentário - post
  async function postMyComentary() {
    alert("Cadastrar o comentário");
  }

  // remove o comentário - delete
  const commentaryRemove = async () => {
    alert("Remover o comentário");
  };

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  

  async function handleConnect(idEvent,whatTheFunction,idPresencaEvento = null) {
    // conecta o usuário e atualiza a tela
    if (whatTheFunction === "connect") {
      try {
        const promise = await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });

        if (promise.status === 201) {
          loadEventsType();
          alert("Presença confirmada, parabéns");
        }
      } catch (error) {
        console.log("Erro ao conectar");
        console.log(error);
      }
      return;
    }

    // unconnect - desconecta o usuário e atualiza a listagem
    const promiseDelete = await api.delete("/PresencasEvento/" + idPresencaEvento);
    if (promiseDelete.status === 204) {
      loadEventsType();
      alert("Desconectado do evento");
    }
  }


  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadMyComentary}
          fnPost={postMyComentary}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
