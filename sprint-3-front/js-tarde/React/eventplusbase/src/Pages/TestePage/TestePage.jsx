import React, { useEffect, useState } from "react";

const TestePage = () => {
  const [count, setCount] = useState(100);
  const [calculation, setCalculation] = useState(0);

  //executa quando o componente for montado
  //e quando o state count for alterado
  useEffect(() => {
    setCalculation( count * 2 );
    console.log(`Rodou ${count}`);
  }, []);

  return (
    <>
      <p>Count: {count}</p>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
      <p>Calculation: {calculation}</p>
    </>
  );
};

export default TestePage;
