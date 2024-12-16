import React from "react";

const OrderDetails = ({ order }) => {
    if (!order) return <p>Select an order to see details.</p>;
    
    return (
        <div>
        <h2>Order Details</h2>
        <p>
            <strong>Order ID:</strong> {order.id}
        </p>
        <p>
            <strong>Order Date:</strong> {order.orderDate}
        </p>
        <p>
            <strong>Order Status:</strong> {order.status}
        </p>
        <p>
            <strong>Order Total:</strong> {order.total}
        </p>
        </div>
    );
};

export default OrderDetails;