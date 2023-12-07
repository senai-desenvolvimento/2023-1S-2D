import React from "react";

import "./Toggle.css";

const Toggle = ({manipulationFunction = null, toggleActive = false}) => {




  // const todosEventos = [
  //   {tipoEvento: 1, nomeEvento: "Evento de JS"},
  //   {tipoEvento: 10, nomeEvento: "Evento de SQL", presenca: true},
  //   {tipoEvento: 22, nomeEvento: "Evento de Mysql"},
  //   {tipoEvento: 50, nomeEvento: "Evento de React", presenca: true},
  //   {tipoEvento: 2, nomeEvento: "Evento de C#"},
  // ];

  // const meusEvento = [//presenças no evento
  // {tipoEvento: 10, nomeEvento: "Evento de SQL", presenca: true},
  // {tipoEvento: 50, nomeEvento: "Evento de React", presenca: true},
  // ];
















  const fakeId = Math.random();

  return (
    <>
      <input type="checkbox" id={`switch-check${fakeId}`} className="toggle__switch-check " />

      <label className={`toggle ${toggleActive ? "toggle--active" : ""}`} htmlFor="switch-check" onClick={manipulationFunction}>
        <div className={`toggle__switch ${toggleActive ? "toggle__switch--active" : ""}`}></div>
      </label>
    </>
  );
};

export default Toggle;
