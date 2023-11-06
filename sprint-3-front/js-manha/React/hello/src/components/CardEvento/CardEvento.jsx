import React from "react";
import "./CardEvento.css";

const CardEvento = ( { titulo, texto, textoLink }  ) => {
  return (
    <div className="card-evento">
      <h3 className="card-evento__titulo">{titulo}</h3>
      <p className="card-evento__text">
        {texto}
      </p>
      <a href="" className="card-evento__conection">
        {textoLink}
      </a>

    </div>
  );
};

export default CardEvento;
