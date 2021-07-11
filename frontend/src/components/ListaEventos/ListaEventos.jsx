import React, { useState, useEffect } from "react";
import { GroupByRegiao } from "../../util";
import "bootstrap/dist/css/bootstrap.min.css";
import "./ListaEventos.css";
import Error from "../Advice/Error/Error";
import NoContent from "../Advice/NoContent/NoContent";

export default function ListaEventos() {
  const [eventos, setEventos] = useState([]);
  const [error, setError] = useState();
  const [noContent, setNoContent] = useState();

  useEffect(() => {
    async function GetEventos() {
      await fetch(process.env.REACT_APP_API + "/Evento")
        .then((response) => response.json())
        .then((data) => {
          var eventos = GroupByRegiao(data.retorno);
          setEventos(eventos);
          setError(false);
          setNoContent(!eventos.length)
        })
        .catch((error) => {
          setError(true);
        });
    }

    GetEventos();
  }, []);

  return (
    <>
      {error ? (
        <Error />
      ) : noContent ? (
        <NoContent />
      ) : (
        <div className="main-list">
          {eventos.map((it) => (
            <>
              <h1
                style={{ textAlign: "center", marginBottom: "2rem" }}
              >{`Região ${it.regiao}`}</h1>
              <table className="table table-striped table-dark">
                <thead>
                  <tr key={it.regiao}>
                    <th scope="col">Pais</th>
                    <th scope="col">Região</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Valor</th>
                    <th scope="col">Gerado Em</th>
                    <th scope="col">Unix TimeStamp</th>
                  </tr>
                </thead>
                <tbody>
                  {it.eventos.map((eve) => (
                    <>
                      <tr key={eve.id}>
                        <td>{eve.pais}</td>
                        <td>{eve.regiao}</td>
                        <td>{eve.nomeSensor}</td>
                        <td>{eve.valor}</td>
                        <td>{new Date(eve.timestampDt).toLocaleString()}</td>
                        <td>{eve.timestamp}</td>
                      </tr>
                    </>
                  ))}
                </tbody>
              </table>
            </>
          ))}
        </div>
      )}
    </>
  );
}
