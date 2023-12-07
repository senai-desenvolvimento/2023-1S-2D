import Rotas from "./routes/routes";
import { UserContext } from "./context/AuthContext";
import "./App.css";
import { useEffect, useState } from "react";
// importa nosso app encapsulado pelo sistema de roteamento

const App = () => {
  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");
    setUserData( token === null ? {}  : JSON.parse(token) );
  }, []);

  return (
    <UserContext.Provider value={{ userData, setUserData }}>
      <Rotas />
    </UserContext.Provider>
  );
};

export default App;
