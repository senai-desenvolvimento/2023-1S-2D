import React from "react";
import "./NextEvent.css";

const NextEvent = ({ title, description, eventDate, idEvent }) => {
    
    function conectar(idEvent) {
        // dá pra usar a prop idEvent? testar
        alert(`Chamar o recurso para conectar: ${idEvent}`)
    }
  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>
      
      <p className="event-card__description">{description}</p>
      
      <p className="event-card__description">{eventDate}</p>

      <a onClick={() => {conectar(idEvent)}}  className="event-card__connect-link">Conectar</a>
    </article>
  );
};

export default NextEvent;
