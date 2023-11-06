import React from "react";

const Button = ({ textButton, type }) => {
  return (
    <button 
      type={type}
    >
      {textButton}
    </button>
  );
};

export default Button;
