// Você pode utilizar bibliotecas de terceiroa para obter um componente de notificação - a React-toastify :)
// https://fkhadra.github.io/react-toastify/introduction

import React, { useEffect } from "react";
// , { useEffect, useState }
import successIlustrator from "../../assets/images/success-illustration.svg";
import warningIlustrator from "../../assets/images/warning-illustration.svg";
import dangerIllustrator from "../../assets/images/error-illustration.svg";
import defaultIllustrator from "../../assets/images/default-image.jpeg";

import "./Notification.css";

function Notification({
  titleNote = "Título não informado",
  textNote = "Mensagem não informada",
  imgIcon = "default",
  imgAlt = "Icone da ilustração",
  showMessage = false,
  setNotifyUser,
}) {
  // resolver, está sendo chamada duas vezes.. componente sendo montado duas vezes na inicializa'ão
  useEffect(() => {
    let initTimeout = () => {
      const hide = () => {
        setNotifyUser({});
      };

      setTimeout(() => {
        hide();
        clearTimeout(initTimeout);
      }, 5000);
    };

    initTimeout();
  }, [showMessage, setNotifyUser]);

  function imageRender(nameImage) {
    let imgIllustrator; //undefined

    // com o return não é necessário o break porém por questões didática ele ficará aí
    switch (nameImage.toLowerCase()) {
      case "success":
        imgIllustrator = successIlustrator;
        break;
      case "warning":
        imgIllustrator = warningIlustrator;
        break;
      case "danger":
        imgIllustrator = dangerIllustrator;
        break;

      default:
        imgIllustrator = defaultIllustrator;
        break;
    }

    return imgIllustrator;
  }

  return (
    // <article className={`notification ${showNotification ? 'notification--show' : ''}`}>
    <article
      className={`notification ${showMessage ? "notification--show" : ""}`}
    >
      <span
        className="notification__close"
        onClick={() => {
          setNotifyUser({});
        }}
      >
        x
      </span>
      <img
        className="notification__icon"
        src={imageRender(imgIcon)}
        alt={imgAlt}
      />
      <div className="notification__message-box">
        <h2 className="notification__title">{titleNote}</h2>
        <p className="notification__text">{textNote}</p>
      </div>
    </article>
  );
}

export default Notification;
