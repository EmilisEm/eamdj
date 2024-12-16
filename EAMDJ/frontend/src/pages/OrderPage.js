import React from 'react';
import { Link, Route, Routes } from 'react-router-dom';
import OrderForm from '../components/Order/OrderForm';
import OrderList from '../components/Order/OrderList';

function OrderPage() {
  return (
    <div>
      <h2>Order Management</h2>
      <nav>
        <ul>
          <li><Link to="/create-order">Create Order</Link></li>
          <li><Link to="/orders">List Orders</Link></li>
        </ul>
      </nav>

      <Routes>
        <Route path="create-order" element={<OrderForm onSuccess={() => {}} />} />
        <Route path="orders" element={<OrderList />} />
      </Routes>
    </div>
  );
}

export default OrderPage;
