import { Switch, Route } from "react-router-dom";
import Home from "../Home/Home";
import ListaEventos from "../ListaEventos/ListaEventos";
import GraficoEventos from "../GraficoEventos/GraficoEventos"
import NotFound from "../NotFound/NotFound";

export default function Routes() {
  return (
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/home" component={Home} />
        <Route exact path="/list_eventos" component={ListaEventos} />
        <Route exact path="/list_eventos_numeric" component={GraficoEventos} />
        <Route render={NotFound} />
      </Switch>
    </div>
  );
}