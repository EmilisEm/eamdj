import React, { useState, useContext } from 'react';
import { myContext } from '../../App';
import { v4 as uuidv4 } from 'uuid';

const OrderForm = ({ onSuccess }) => {
  const { 
    currentBusiness, 
    businesses, 
    setCurrentBusiness 
  } = useContext(myContext);

  const [orderItems, setOrderItems] = useState([]);
  const [productId, setProductId] = useState('');
  const [quantity, setQuantity] = useState(1);

  const handleBusinessChange = (event) => {
    const selectedId = event.target.value;
    const selectedBusiness = businesses.find(business => business.id === selectedId);
    if (selectedBusiness) {
      setCurrentBusiness(selectedBusiness);
    }
  };

  const handleAddItem = () => {
    if (!productId) {
      alert('Product ID is required');
      return;
    }

    if (quantity > 0) {
      setOrderItems([...orderItems, { 
        id: uuidv4(), 
        productId, 
        quantity 
      }]);
      setProductId('');
      setQuantity(1);
    }
  };

  const handleRemoveItem = (index) => {
    const newOrderItems = orderItems.filter((_, i) => i !== index);
    setOrderItems(newOrderItems);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    
    if (!currentBusiness || !currentBusiness.id) {
      alert('Please select a business first');
      return;
    }

    const orderCreateDto = {
      businessId: currentBusiness.id,
      orderItems: orderItems.map(item => ({
        productId: item.productId,
        quantity: item.quantity
      }))
    };

    try {
      console.log('Sending Order Create DTO:', orderCreateDto);

      const response = await fetch('https://localhost:8081/api/v1/order', {
        method: 'POST',
        headers: { 
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        },
        body: JSON.stringify(orderCreateDto)
      });

      console.log('Response status:', response.status);

      if (response.ok) {
        const newOrder = await response.json();
        onSuccess(newOrder);
        setOrderItems([]);
      } else {
        const errorText = await response.text();
        console.error('Failed to create order. Status:', response.status);
        console.error('Error response:', errorText);
        alert(`Failed to create order: ${errorText}`);
      }
    } catch (error) {
      console.error('Network or parsing error:', error);
      alert('An error occurred while creating the order');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create New Order</h2>

      <div>
        <label>
          Select Business:
          <select
            value={currentBusiness ? currentBusiness.id : ''}
            onChange={handleBusinessChange}
            required
          >
            <option value="" disabled>Select a business</option>
            {businesses && businesses.length > 0 ? (
              businesses.map((business) => (
                <option key={business.id} value={business.id}>
                  {business.name}
                </option>
              ))
            ) : (
              <option value="" disabled>No businesses available</option>
            )}
          </select>
        </label>
      </div>

      <div>
        <label>
          Product ID:
          <input
            type="text"
            value={productId}
            onChange={(e) => setProductId(e.target.value)}
            required
          />
        </label>
        <label>
          Quantity:
          <input
            type="number"
            value={quantity}
            onChange={(e) => setQuantity(parseInt(e.target.value))}
            min="1"
            required
          />
        </label>
        <button 
          type="button" 
          onClick={handleAddItem}
          disabled={!productId || quantity <= 0}
        >
          Add Item
        </button>
      </div>

      <div>
        <h3>Order Items:</h3>
        {orderItems.map((item, index) => (
          <div key={item.id}>
            Product: {item.productId}, Quantity: {item.quantity}
            <button type="button" onClick={() => handleRemoveItem(index)}>
              Remove
            </button>
          </div>
        ))}
      </div>

      <button type="submit" disabled={orderItems.length === 0}>
        Create Order
      </button>
    </form>
  );
};

export default OrderForm;