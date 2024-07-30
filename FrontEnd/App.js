import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BuyerList from './components/BuyerList';
import BuyerForm from './components/BuyerForm';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<BuyerList />} />
        <Route path="/add" element={<BuyerForm />} />
        <Route path="/edit/:id" element={<BuyerForm />} />
      </Routes>
    </Router>
  );
}

export default App;
