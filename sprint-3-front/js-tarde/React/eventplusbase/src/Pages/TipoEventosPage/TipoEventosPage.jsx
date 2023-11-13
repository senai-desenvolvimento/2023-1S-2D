import React from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
const TipoEventosPage = () => {
  return (
    <MainContent>
      <section className="cadastro-evento-section">
        
        <div className="cadastro-evento__box">
          <Title titleText={"Página Tipos de Eventos"} />
          <ImageIllustrator />

          <form action="">
            <p>Componente de Formulário</p>
          </form>
        </div>
      
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
