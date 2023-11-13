import React, { useState } from "react";
import "./TipoEventosPage.css";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Container from "../../components/Container/Container";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";

import tipoEventoImage from '../../assets/images/tipo-evento.svg'
const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(true);//está em modo edição?

  function handleSubmit() {
    alert('Bora Cadastrar');
  }
  function handleUpdate() {
    alert('Bora Editar');
  }
  return (
    <>
      <MainContent>
        <section className="cadastro-evento-section">
            <Container>
                <div className="cadastro-evento__box">
                    <Title titleText={"Cadastro Tipo de Eventos"} />
                    
                    <ImageIllustrator 
                      imageRender={tipoEventoImage}
                    />
                    
                    <form 
                      className="ftipo-evento"
                      onSubmit={frmEdit ? handleUpdate: handleSubmit}  
                    >
                        {/* cadastrar ou editar? */}
                        {
                          !frmEdit ? (<p>Tela de Cadastro</p>) : (<p>Tela de Edição</p>)
                        }
                    </form>
                </div>
            </Container>
        </section>
      </MainContent>
    </>
  );
};

export default TipoEventosPage;
