// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import BusinessPage from './pages/BusinessPage'; // Ensure the import
import OrderPage from './pages/OrderPage';
import ProductPage from './pages/ProductPage';
import ReservationPage from './pages/ReservationPage';
import UserPage from './pages/UserPage';

function App() {
  return (
    <Router>
      <div className="App">
        <nav>
          <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/business">Businesses</Link></li>
            <li><Link to="/order">Orders</Link></li>
            <li><Link to="/product">Products</Link></li>
            <li><Link to="/reservation">Reservations</Link></li>
            <li><Link to="/user">Users</Link></li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<h1>Welcome to the Restaurant Management App</h1>} />
          
          <Route path="/business/*" element={<BusinessPage />} />
          <Route path="/order/*" element={<OrderPage />} />
          <Route path="/product/*" element={<ProductPage />} />
          <Route path="/reservation/*" element={<ReservationPage />} />
          <Route path="/user/*" element={<UserPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
