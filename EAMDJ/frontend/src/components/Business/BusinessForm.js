import React, { useState } from 'react';
import { createBusiness } from '../../api/business';
import { useNavigate } from 'react-router-dom';

function BusinessForm({ onSuccess }) {
  const [newBusiness, setNewBusiness] = useState({
    name: ' ',
    email: ' ',
    address: ' ',
  });
  const [error, setError] = useState(null); // To capture any errors during form submission
  const [loading, setLoading] = useState(false); // To track loading state
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault(); // Prevent default form submission
    setLoading(true); // Show loading state
    setError(null); // Reset error state

    try {
      await createBusiness(newBusiness);
      onSuccess();
      navigate('/business/businesslist');
    } catch (error) {
      // Capture any errors and set them in state
      setError(error.message);
    } finally {
      setLoading(false); // Hide loading state
    }
  };

  return (
    <div>
      <h2>Create Business</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>} {/* Show error if there's an issue */}
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input
            type="text"
            value={newBusiness.name}
            onChange={(e) => setNewBusiness({...newBusiness, name: e.target.value})}
            required
          />
        </label>
        <label>
          Email:
          <input
            type="email"
            value={newBusiness.email}
            onChange={(e) => setNewBusiness({...newBusiness, email: e.target.value})}
            required
          />
        </label>
        <label>
          Address:
          <input
            type="text"
            value={newBusiness.address}
            onChange={(e) => setNewBusiness({...newBusiness, address: e.target.value})}
            required
          />
        </label>
        <button type="submit" disabled={loading}>
          {loading ? 'Creating...' : 'Create Business'}
        </button>
      </form>
    </div>
  );
}

export default BusinessForm;