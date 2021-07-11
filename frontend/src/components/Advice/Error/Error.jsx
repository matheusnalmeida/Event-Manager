import React from 'react'
import '../Advice.css'
import Image from '../../../assets/PageNotFound.gif'

export default function Error() {
  return (
    <div className="image-area">
      <div className="bg-image-area">
        <h3>Aconteceu algum erro!</h3>
        <span>O servidor não está respondendo, tente novamente em alguns minutos...</span>
        <img src={Image} alt=""></img>
      </div>
    </div>
  )
}