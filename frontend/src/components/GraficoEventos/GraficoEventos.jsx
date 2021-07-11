import React, { useState, useEffect } from "react";
import Chart from "react-apexcharts";
import Error from "../Advice/Error/Error";
import NoContent from "../Advice/NoContent/NoContent";
import { GroupByRegiao, GenerateGraphBarOptions } from "../../util";
import "./GraficoEventos.css";

export default function GraficoEventos() {
  const [error, setError] = useState();
  const [dataChartOptions, setDataChartOptions] = useState([]);
  const [noContent, setNoContent] = useState();

  function GetDataCharOptions(eventos) {
    let eventosPorRegiao = GroupByRegiao(eventos);
    let dataChartOptions = GenerateGraphBarOptions(eventosPorRegiao);
    return dataChartOptions;
  }

  useEffect(() => {
    async function GetEventos() {
      await fetch(process.env.REACT_APP_API + "/Evento/GetNumeric")
        .then((response) => response.json())
        .then((data) => {
          let dataCharOptions = GetDataCharOptions(data.retorno);
          setDataChartOptions(dataCharOptions);
          setError(false);
          setNoContent(!dataCharOptions.length);
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
        <NoContent title="Não existem eventos númericos cadastrados!"/>
      ) : (
        <div className="main-charts">
          {dataChartOptions.map((chartOptions, i) => (
            <div key={i} className="chart">
              <Chart
                options={chartOptions.options}
                series={chartOptions.series}
                type="bar"
                width={1300}
                height={500}
              />
            </div>
          ))}
        </div>
      )}
    </>
  );
}
