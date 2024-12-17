import React, { useState, useEffect } from 'react';

const OrderDetails = ({ order }) => {
  const [orderItems, setOrderItems] = useState([]);

  useEffect(() => {
    const fetchOrderItems = async () => {
      if (!order) return;

      try {
        const response = await fetch(`https://localhost:8081/api/v1/order-item/by-order/${order.id}`);
        
        if (response.ok) {
          const itemsData = await response.json();
          setOrderItems(itemsData);
        } else {
          console.error('Failed to fetch order items');
        }
      } catch (error) {
        console.error('Error fetching order items:', error);
      }
    };

    fetchOrderItems();
  }, [order]);

  if (!order) return <p>Select an order to see details.</p>;
  
  return (
    <div>
      <h2>Order Details</h2>
      <div>
        <p><strong>Order ID:</strong> {order.id}</p>
        <p><strong>Order Date:</strong> {new Date(order.createdAt).toLocaleString()}</p>
        <p><strong>Status:</strong> {order.status}</p>
      </div>

      <h3>Order Items</h3>
      <table>
        <thead>
          <tr>
            <th>Product ID</th>
            <th>Quantity</th>
          </tr>
        </thead>
        <tbody>
          {orderItems.map(item => (
            <tr key={item.id}>
              <td>{item.productId}</td>
              <td>{item.quantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default OrderDetails;