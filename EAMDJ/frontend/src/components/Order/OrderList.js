import React, { useEffect, useState } from 'react';
import { fetchOrdersByBusiness, deleteOrder } from '../../api/order';
import LoadingSpinner from '../Shared/LoadingSpinner';

const OrderList = () => {
    const [orders, setOrders] = useState([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        const loadOrders = async () => {
        try {
            const data = await fetchOrdersByBusiness();
            setOrders(data);
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
        };
    
        loadOrders();
    }, []);
    
    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this order?')) {
        await deleteOrder(id);
        setOrders(orders.filter((order) => order.id !== id));
        }
    };
    
    if (loading) return <LoadingSpinner />;
    
    return (
        <div>
        <h1>Orders</h1>
        <ul>
            {orders.map((order) => (
            <li key={order.id}>
                <p>{order.id}</p>
                <button onClick={() => handleDelete(order.id)}>Delete</button>
            </li>
            ))}
        </ul>
        </div>
    );
}

export default OrderList;
