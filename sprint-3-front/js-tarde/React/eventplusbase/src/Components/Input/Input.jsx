import React, { useState } from "react";

const Input = (props) => {//construtor
  

  return (
    <div>
      <input 
            type={props.tipo} 
            id={props.id} 
            name={props.nome} 
            placeholder={props.dicaCampo} 
            value={props.valor}
            onChange={(e)=>{
              props.fnAltera(e.target.value)//valor do input
            }}
        />
        <span>{props.valor}</span>
    </div>
  );
};

export default Input;
