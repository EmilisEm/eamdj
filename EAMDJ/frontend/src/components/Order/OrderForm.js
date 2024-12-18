import React, { useState, useContext, useEffect } from 'react';
import { myContext } from '../../App';
import { v4 as uuidv4 } from 'uuid';
import { createOrder } from '../../api/order';
import { fetchBusinesses } from '../../api/business';

const OrderForm = ({ onSuccess }) => {
  const { 
    currentBusiness, 
    businesses, 
    setCurrentBusiness,
    setBusinesses
  } = useContext(myContext);

  const [orderItems, setOrderItems] = useState([]);
  const [productId, setProductId] = useState('');
  const [quantity, setQuantity] = useState(1);

  const handleBusinessChange = (event) => {
    const selectedId = event.target.value;
    const selectedBusiness = businesses.find(business => business.id === selectedId);
    if (selectedBusiness) {
      setCurrentBusiness(selectedBusiness);
      console.log('Selected Business:', selectedBusiness); // Add this line
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

      const newOrder = await createOrder(orderCreateDto);

      console.log('Order created successfully:', newOrder);
      onSuccess(newOrder);
      setOrderItems([]);
    } catch (error) {
      console.error('Failed to create order:', error);
      alert('An error occurred while creating the order');
    }
  };

  useEffect(() => {
    const getBusinesses = async () => {
      try {
        const response = await fetchBusinesses({ page: 1, pageSize: 20 });
        setBusinesses(response.items);
      } catch (err) {
        console.error(err);
      }     
    };
    
    getBusinesses();
  }, []);

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create New Order</h2>

      <div>
        <label>
          Select Business:
          <select
            value={currentBusiness ? currentBusiness.id : ''}
            onChange={handleBusinessChange}
          >
            <option value="">Select a business</option>
            {businesses.map(business => (
              <option key={business.id} value={business.id}>
                {business.name}
              </option>
            ))}
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
          />
        </label>
      </div>

      <div>
        <label>
          Quantity:
          <input
            type="number"
            value={quantity}
            onChange={(e) => setQuantity(parseInt(e.target.value))}
          />
        </label>
      </div>

      <button type="button" onClick={handleAddItem}>Add Item</button>

      <ul>
        {orderItems.map((item, index) => (
          <li key={item.id}>
            {item.productId} - {item.quantity}
            <button type="button" onClick={() => handleRemoveItem(index)}>Remove</button>
          </li>
        ))}
      </ul>

      <button type="submit">Submit Order</button>
    </form>
  );
};

export default OrderForm;