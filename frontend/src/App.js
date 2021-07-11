import "./App.css";
import Navigation from "./components/Navigation/Navigation";
import Routes from "./components/Routes/Routes";

export default function App(props) {
  return (
    <>
      <div className="App">
        <Navigation />
      </div>
      <Routes/>
    </>
  );
}
