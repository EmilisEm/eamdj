import React, { useState } from 'react';

function OrderForm({ onSuccess }) {
  const [businessId, setBusinessId] = useState('');
  const [orderItems, setOrderItems] = useState([]);
  const [productId, setProductId] = useState('');
  const [quantity, setQuantity] = useState(1);

  const handleAddItem = () => {
    setOrderItems([...orderItems, { productId, quantity }]);
    setProductId('');
    setQuantity(1);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const response = await fetch('/api/v1/order', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ businessId, orderItems }),
    });
    if (response.ok) {
      onSuccess();
    } else {
      console.error('Failed to create order');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Business ID:
        <input
          type="text"
          value={businessId}
          onChange={(e) => setBusinessId(e.target.value)}
        />
      </label>
      <div>
        <label>
          Product ID:
          <input
            type="text"
            value={productId}
            onChange={(e) => setProductId(e.target.value)}
          />
        </label>
        <label>
          Quantity:
          <input
            type="number"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
          />
        </label>
        <button type="button" onClick={handleAddItem}>Add Item</button>
      </div>
      <button type="submit">Create Order</button>
    </form>
  );
}

export default OrderForm;
