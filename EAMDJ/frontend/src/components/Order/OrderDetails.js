import React, { useState, useEffect } from 'react';
import { fetchOrderItems } from '../../api/order';

const OrderDetails = ({ order }) => {
  const [orderItems, setOrderItems] = useState([]);

  useEffect(() => {
    const loadOrderItems = async () => {
      if (order && order.id) {
        const items = await fetchOrderItems(order.id);
        setOrderItems(items);
      }
    };

    loadOrderItems();
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