import React from 'react';
import ReactDOM from 'react-dom';
import './index.css'; // Arquivo de estilos globais, se necessário
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter as Router } from 'react-router-dom';

// Renderiza o componente principal do aplicativo
ReactDOM.render(
  <React.StrictMode>
    <Router>
      <App />
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// Reporte de métricas de desempenho (opcional)
reportWebVitals();
