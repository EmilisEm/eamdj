// src/components/Business/BusinessForm.js
import React, { useState } from 'react';

function BusinessForm({ onSuccess }) {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('');
  const [error, setError] = useState(null); // To capture any errors during form submission
  const [loading, setLoading] = useState(false); // To track loading state

  const handleSubmit = async (event) => {
    event.preventDefault(); // Prevent default form submission
    setLoading(true); // Show loading state
    setError(null); // Reset error state

    try {
      const response = await fetch('/api/v1/business', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, email, address }),
      });

      if (!response.ok) {
        throw new Error('Failed to create business');
      }

      // Call onSuccess when the business is created
      onSuccess();
      // Optionally reset the form here
      setName('');
      setEmail('');
      setAddress('');
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
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </label>
        <label>
          Email:
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </label>
        <label>
          Address:
          <input
            type="text"
            value={address}
            onChange={(e) => setAddress(e.target.value)}
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