import React from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';

import eventTypeImage from '../../assets/images/tipo-evento.svg'
import Container from "../../Components/Container/Container";
import { Input } from "../../Components/FormComponents/FormComponents";

const TipoEventosPage = () => {
  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
        <div className="cadastro-evento__box">
          <Title titleText={"Página Tipos de Eventos"} />
          <ImageIllustrator 
            alterText={"??????"}
            imageRender={eventTypeImage}
          />

          <form action="">
            <p>Componente de Formulário</p>
            <Input 
              type={"text"}
              required={"required"}
            />
          </form>
        </div>
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
