import React from "react";
import "./Title.css";
// as props você pode dar o nome que quiser, porém tome cuidado, não vá me locoloar no seu portifólio!
const Title = ({ titleText, color = "", potatoClass = "" }) => {
  return (
        <h1 
            className={ `title ${potatoClass}` } style={{color: color}}
        >
            {titleText}
            <hr 
                className="title__underscore"
                style={{borderColor: color}}
            />
        </h1>
    );

};

export default Title;
