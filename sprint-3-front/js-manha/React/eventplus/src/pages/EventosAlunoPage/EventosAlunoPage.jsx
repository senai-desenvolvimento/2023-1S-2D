import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api, { eventsResource, myEventsResource } from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile

  const [eventos, setEventos] = useState([]);
  // select mocado
  // const [quaisEventos, setQuaisEventos] = useState([
  const quaisEventos = [
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ];

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData } = useContext(UserContext);

  useEffect(() => {
    async function loadEventsType() {
      setShowSpinner(true);
      // setEventos([]); //zera o array de eventos
      if (tipoEvento === "1") {
        //todos os eventos (Evento)
        try {
          const retornoEventos = await api.get(eventsResource);
          setEventos(retornoEventos.data);
          console.log(retornoEventos.data);
        } catch (error) {
          //colocar o notification
          console.log("Erro na API");
          console.log(error);
        }
      } else if (tipoEvento === "2") {
        /**
         * Lista os meus eventos (PresencasEventos) 
         * retorna um formato diferente de array
         */
        try {
          const retornoEventos = await api.get(
            `${myEventsResource}/${userData.userId}`
          );
          console.clear()
          console.log("MINHAS PRESENÇAS");
          console.log(retornoEventos.data);

            const arrEventos = [];//array vazio
            
            retornoEventos.data.forEach( e => {
              arrEventos.push(e.evento); 
            });

            // console.log(arrEventos);
          setEventos(arrEventos);
        } catch (error) {
          //colocar o notification
          console.log("Erro na API");
          console.log(error);
        }
      } else {
        setEventos([]);
      }
      setShowSpinner(false);
    }

    loadEventsType();
  }, [tipoEvento]); //userData.userId

  

  const verificaPresenca = (arrAllEvents, eventsUser) => {
      for (let x = 0; x < arrAllEvents.length; x++) {//para cada evento principal
        for (let i = 0; i < eventsUser.length; i++) {//procurar a correspondência em minhas presenças
          if(arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
            arrAllEvents[x].situacao = true;
            break;//paro de procurar para o evento principal atual
          }
        }
      }
  }


  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  // async function loadMyComentary(idComentary) {
  //   return "????";
  // }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
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
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
