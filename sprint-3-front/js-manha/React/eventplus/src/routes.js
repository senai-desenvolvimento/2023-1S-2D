import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";//v6

// imports dos componentes de página
import HomePage from "./pages/HomePage/HomePage";
import TipoEventos from "./pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "./pages/EventosPage/EventosPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import TestePage from "./pages/TestePage/TestePage";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";

// Componente Rota
const Rotas = () => {
  return (
      <BrowserRouter>
       <Header />
        
        <Routes>
          <Route element={<HomePage />} path="/" exact />
          <Route element={<TipoEventos />} path="/tipo-eventos" />
          <Route element={<EventosPage />} path="/eventos" />
          <Route element={<LoginPage />} path="/login" />
          <Route element={<TestePage />} path="/testes" />
        </Routes>
        
        <Footer />
      </BrowserRouter>
  );
};

export default Rotas;
