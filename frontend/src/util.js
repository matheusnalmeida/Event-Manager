// Organizando dados de eventos agrupando por região
export const GroupByRegiao = function GroupByRegiao(eventos) {
  if (!eventos) {
    return [];
  }

  // Agrupando dados pelo nome da regiao. O objeto resultante estará no formato {nomeRegiao: [eventos]}
  let result = eventos.reduce(function (r, a) {
    r[a.regiao] = r[a.regiao] || [];
    r[a.regiao].push(a);
    return r;
  }, Object.create(null));

  // Colocando objetos no formato {regiao: nomeRegiao, eventos: []}
  result = Object.keys(result).map((regiao) => ({
    regiao: regiao,
    eventos: result[regiao],
  }));

  return result;
};

// Função para mapear dados dos eventos agrupados em regiao para opções do gráfico de barra
export const GenerateGraphBarOptions = function GenerateGraphBarOptions(
  eventosPorRegiao
) {
  var chartOptions = eventosPorRegiao.map((eventosPorRegiao) => ({
    options: {
      title: {
        text: `Região ${eventosPorRegiao.regiao} - ${SomaTotalEventos(
          eventosPorRegiao.eventos
        )}`,
        align: "center",
        margin: 10,
        offsetX: 0,
        offsetY: 0,
        floating: false,
        style: {
          fontSize: "40px",
          fontWeight: "bold",
          color: "#263238",
        },
      },
      chart: {
        id: "apexchart",
      },
      xaxis: {
        categories: eventosPorRegiao.eventos.map(
          (evento) => `${evento.pais}.${evento.regiao}.${evento.nomeSensor}`
        ),
        labels: {
          show: true,
          style: {
            colors: [],
            fontSize: "15px",
            fontFamily: "Helvetica, Arial, sans-serif",
            fontWeight: 400,
            cssClass: "apexcharts-xaxis-label",
          },
        },
      },
    },
    series: [
      {
        name: "Total",
        data: eventosPorRegiao.eventos.map((evento) => evento.valor),
      },
    ],
  }));

  return chartOptions;
};

const SomaTotalEventos = function GenerateGraphBarOptions(eventos) {
  let valoresEventos = eventos.map((evento) => evento.valor);

  if (!valoresEventos.length) {
    return 0;
  }

  let somaTotal = valoresEventos.reduce((a, b) => a + b, 0);

  return somaTotal;
};
