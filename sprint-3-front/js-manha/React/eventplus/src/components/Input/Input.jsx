import React from "react";

const Input = ({ onChange, type, placeholder, name, id, value }) => {

  return (
    <>
      <input
        type={type}
        placeholder={placeholder}
        name={name}
        id={id}
        value={value}
        onChange={onChange}
      />
      <span>{value}</span>
    </>
  );
};

export default Input;
