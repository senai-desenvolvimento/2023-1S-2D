import React, { useState } from "react";
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";
import Title from "../../components/Title/Title";

const TestePage = () => {
  //variáveis do componente!
  // const [n1, setN1] = useState(0); //number
  // const [n2, setN2] = useState(0); //number
  // const [total, setTotal] = useState();

  // function handleCalcular(e) {
  //   e.preventDefault(); //event
  //   setTotal(parseFloat(n1) + parseFloat(n2));
  // }





  
  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
      <p>Calculation: {calculation}</p>

      {/* <Title titleText="Teste Page" />
      <h2>Calculator</h2>

      <form onSubmit={handleCalcular} >
        <Input
          type="number"
          placeholder="Primeiro número"
          name="n1"
          id="n1"
          value={n1}
          onChange={(e) => {
            setN1(e.target.value);
          }}
        />
        <br />
        <Input
          type="number"
          placeholder="Segundo número"
          name="n2"
          id="n2"
          value={n2}
          onChange={(e) => {
            setN2(e.target.value);
          }}
        />

        <br />

        <Button
          textButton="Calcular"
          type="submit"
        />
        <span>
          Resultado:
          <strong>{total}</strong>
        </span>
      </form> */}

      {/* <p>VALOR DO N1: {n1}</p>
            <p>VALOR DO N2: {n2}</p> */}
    </div>
  );
};

export default TestePage;
