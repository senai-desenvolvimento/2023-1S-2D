import Title from "./components/Title/Title";
import CardEvento from "./components/CardEvento/CardEvento";

import Container from "./components/Container/Container";

import "./App.css";
import Contador from "./components/Contador/Contador";
import Rotas from "./routes";

function App() {
  // Criar as propriedades titulo, texto, textoLink
  // passar as propriedades em cada um dios 3 componentes abaixo.
  return (
    <div className="App">
      <Rotas />
    </div>
  );
}

export default App;
