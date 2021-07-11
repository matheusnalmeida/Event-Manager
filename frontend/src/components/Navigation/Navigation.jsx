import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { Navbar, Nav } from "react-bootstrap";

export default function Navigation(props) {
  return (
    <>
    <Navbar bg="dark" variant="dark">
      <Navbar.Brand href="/home">Gerenciador de Eventos</Navbar.Brand>
      <Nav className="mr-auto">
        <Nav.Link href="/list_eventos">Lista de Eventos</Nav.Link>
        <Nav.Link href="/list_eventos_numeric">Gráfico de Eventos</Nav.Link>
      </Nav>
    </Navbar>
    </>
  );
}
