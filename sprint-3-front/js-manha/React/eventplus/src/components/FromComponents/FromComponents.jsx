import React from 'react';
import './FromComponents.css'

export const Input = ( {
    type,
    id,
    value,
    required,
    additionalClass,
    name,
    placeholder,
    manipulationFunction
} ) => {
    return (
        <input 
            type={type} 
            id={id} 
            name={name} 
            value={value} 
            required={required ? "required" : ""} 
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoComplete="off"
        />
    );
};

export const Label = ({htmlFor, labelText}) => {
    return <label htmlFor={htmlFor}>{labelText}</label>
}

// componente criado na forma tradicional props ao invés do destructuring
export const Button = ( props ) => {
    return (
        <button
            id={props.id}
            name={props.name}
            type={props.type}
            className={props.additionalClass}
            onClick={props.manipulationFunction}
        >
            {props.textButton}
        </button>
    );
}

options = [
    {value: "", text: "Selecione" },
    {value: "asjkfhkajsfjhask", text: "SQL Server" },
    {value: "asjkfhkajsfjhaskufr34", text: "JavaScript" }
];//veio do banco de dados pela api


export const Select = ({
    required,
    id,
    name,
    options,
    manipulationFunction,
    additionalClass = "",
    defaultValue
}) => {
    return (
        <select 
            name={name} 
            id={id}
            required={required}
            className={`input-component ${additionalClass}`}
            onChange={manipulationFunction}
            value={defaultValue}

        >
            {/* <option value="">Selecione</option> */}
            {options.map((o) =>{
                return (
                    <option key={Math.random()} value={o.value}>{o.text}</option>
                );
            })}
        </select>
    );
}