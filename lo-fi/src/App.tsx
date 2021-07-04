import React from 'react';

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import CreditCard from './components/CreditCard/CreditCard';
import Menu from "./components/NavigationMenu/Menu";

function App() {
  return (
    <div className="App">
      <Menu />
      <CreditCard />
    </div>
  );
}

export default App;
