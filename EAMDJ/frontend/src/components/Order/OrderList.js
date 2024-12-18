import React, { useState, useEffect, useContext } from 'react';
import { myContext } from '../../App';
const { fetchOrdersByBusiness, deleteOrder } = require('../../api/order');

const OrderList = ({ onOrderSelect }) => {
  const { currentBusiness, setCurrentOrders } = useContext(myContext);
  const [orders, setOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [pageSize] = useState(20);
  const [totalPages, setTotalPages] = useState(1);

  useEffect(() => {
    const fetchOrders = async () => {
      if (!currentBusiness || !currentBusiness.id) return;

      setIsLoading(true);
      try {
        const response = await fetchOrdersByBusiness(currentBusiness.id, { page, pageSize });
        setOrders(response.items);
        setTotalPages(response.totalPages);
        setCurrentOrders(response.items);
      } catch (error) {
        console.error('Error fetching orders:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchOrders();
  }, [currentBusiness, page, pageSize, setCurrentOrders]);

  const handleNextPage = () => {
    if (page < totalPages) {
      setPage(page + 1);
    }
  };

  const handlePreviousPage = () => {
    if (page > 1) {
      setPage(page - 1);
    }
  };

  const handleDeleteOrder = async (orderId) => {
    if (window.confirm('Are you sure you want to delete this order?')) {
      try {
        await deleteOrder(orderId);
        setOrders(orders.filter(order => order.id !== orderId));
        setCurrentOrders(orders.filter(order => order.id !== orderId));
      } catch (error) {
        console.error('Error deleting order:', error);
      }
    }
  };

  if (isLoading) return <div>Loading orders...</div>;

  return (
    <div>
      <h2>Orders for {currentBusiness.name}</h2>
      {orders.length === 0 ? (
        <p>No orders found</p>
      ) : (
        <div>
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
                    <button onClick={() => handleDeleteOrder(order.id)}>
                      Delete
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div>
            <button onClick={handlePreviousPage} disabled={page === 1}>Previous</button>
            <span>Page {page} of {totalPages}</span>
            <button onClick={handleNextPage} disabled={page === totalPages}>Next</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default OrderList;