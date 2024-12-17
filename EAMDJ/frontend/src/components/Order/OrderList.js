import React, { useState, useEffect, useContext } from 'react';
import { myContext } from '../../App';

const OrderList = ({ onOrderSelect }) => {
  const { currentBusiness, setCurrentOrders } = useContext(myContext);
  const [orders, setOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchOrders = async () => {
      if (!currentBusiness || !currentBusiness.id) return;

      setIsLoading(true);
      try {
        const response = await fetch(`https://localhost:8081/api/v1/order/by-business/${currentBusiness.id}`);
        
        if (response.ok) {
          const orderData = await response.json();
          setOrders(orderData);
          setCurrentOrders(orderData);
        } else {
          console.error('Failed to fetch orders');
        }
      } catch (error) {
        console.error('Error fetching orders:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchOrders();
  }, [currentBusiness]);

  if (isLoading) return <div>Loading orders...</div>;

  return (
    <div>
      <h2>Orders for {currentBusiness.name}</h2>
      {orders.length === 0 ? (
        <p>No orders found</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Order ID</th>
              <th>Date</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {orders.map(order => (
              <tr key={order.id}>
                <td>{order.id}</td>
                <td>{new Date(order.createdAt).toLocaleString()}</td>
                <td>{order.status}</td>
                <td>
                  <button onClick={() => onOrderSelect(order)}>
                    View Details
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default OrderList;