import React, { useState } from 'react';
import OrderForm from '../components/Order/OrderForm';
import OrderList from '../components/Order/OrderList';
import OrderDetails from '../components/Order/OrderDetails';

const OrderPage = () => {
  const [selectedOrder, setSelectedOrder] = useState(null);

  const handleOrderCreated = (newOrder) => {
    // Optionally handle new order creation logic
    setSelectedOrder(newOrder);
  };

  return (
    <div>
      <h1>Orders Management</h1>
      
      <div style={{ display: 'flex' }}>
        <div style={{ flex: 1, marginRight: '20px' }}>
          <OrderForm onSuccess={handleOrderCreated} />
        </div>
        
        <div style={{ flex: 1, marginRight: '20px' }}>
          <OrderList onOrderSelect={setSelectedOrder} />
        </div>
        
        <div style={{ flex: 1 }}>
          <OrderDetails order={selectedOrder} />
        </div>
      </div>
    </div>
  );
};

export default OrderPage;