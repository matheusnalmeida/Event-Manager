import React from "react";
import "./Home.css";

export default function Home() {
  return (
    <div className="main-home">
      <header className="header-home" style={{ paddingTop: "2rem" }}>
        <h1 className="h1-header-home">Gerenciador de eventos</h1>
      </header>
      <div className="instru-div-home">
        <header className="header-intru-home">
          <h1 className="h1-header-intru-home">Informações Gerais</h1>
        </header>
        <p className="p-home">
          Olá bem vindo ao gerenciador de eventos. O objetivo desta aplicação é
          gerenciar os eventos gerados por diversos sensores espalhados pelo
          brasil, contendo informações dos eventos por pais, região, nome do
          evento, data de emissão do evento e valor.
        </p>
      </div>
      <div className="instru-div-home">
        <header className="header-intru-home">
          <h1 className="h1-header-intru-home">Lista de eventos</h1>
        </header>
        <p className="p-home">
          Na tela de lista de eventos podemos visualizar os eventos divididos
          por região, sendo cada evento listado com seus respectivos valores
        </p>
      </div>
      <div className="instru-div-home">
        <header className="header-intru-home">
          <h1 className="h1-header-intru-home">Gráfico de eventos</h1>
        </header>
        <p className="p-home">
          Na tela de gráficos de eventos podemos visualizar o gráfico de barras
          contendo somente eventos de valor númerico. Neste gráfico podemos
          visualizar os eventos divididos por região com cada evento contendo
          sua respectiva contagem.
        </p>
      </div>
    </div>
  );
}
