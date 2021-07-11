import React from 'react'
import PageNoContent from "../../../assets/PageNoContent.jpg";
import '../Advice.css'

export default function NoContent(props){
    return (
        <>
        <div className="image-area">
        <div className="bg-image-area">
            <h3>{props.title || "Não existem eventos cadastrados!"}</h3>
            <span>Cadastre eventos pela rota <b>/api/Evento</b> da api e recarregue a página.</span>
            <img src={PageNoContent} alt=""></img>
        </div>
        </div>
        </>
      );
}