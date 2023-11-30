import React, { useContext } from "react";
import iconeLogout from "../../assets/images/icone-logout.svg";
import { UserContext } from "../../context/AuthContext";
import { Link, useNavigate } from "react-router-dom";

import "./PerfilUsuario.css";

const PerfilUsuario = () => {
    const { userData, setUserData } = useContext(UserContext);
    const navigate = useNavigate();

    const logout = () => {
        localStorage.clear();
        setUserData({})
        navigate("/");
    }

  return (
    <div className="perfil-usuario">
      {userData.name ? (
        <>
          <span className="perfil-usuario__menuitem">{userData.name}</span>

          <img
          onClick={logout}
            title="Deslogar"
            className="perfil-usuario__icon"
            src={iconeLogout}
            alt="imagem ilustrativa de uma porta de saída do usuário "
          />
        </>
      ) : (
        <Link to="/login" className="perfil-usuario__menuitem">Login</Link>
      )}
    </div>
  );
};

export default PerfilUsuario;
