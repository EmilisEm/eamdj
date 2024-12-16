// src/components/Business/BusinessDetails.js
import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

function BusinessDetails({ isUpdate = false, isDelete = false }) {
  const { id } = useParams(); // Get business ID from the route
  const navigate = useNavigate();
  const [business, setBusiness] = useState(null);
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('');

  // Fetch the business details when the component loads
  useEffect(() => {
    const fetchBusiness = async () => {
      const response = await fetch(`/api/v1/business/${id}`);
      const data = await response.json();
      setBusiness(data);
      setName(data.name);
      setEmail(data.email);
      setAddress(data.address);
    };
    fetchBusiness();
  }, [id]);

  // Handle the Update operation
  const handleUpdate = async () => {
    const response = await fetch(`/api/v1/business/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ name, email, address }),
    });
    if (response.ok) {
      navigate('/business/businesslist');
    } else {
      console.error('Failed to update business');
    }
  };

  // Handle the Delete operation
  const handleDelete = async () => {
    const response = await fetch(`/api/v1/business/${id}`, { method: 'DELETE' });
    if (response.ok) {
      navigate('/business/businesslist');
    } else {
      console.error('Failed to delete business');
    }
  };

  if (!business) return <div>Loading...</div>;

  return (
    <div>
      <h2>{isUpdate ? 'Update' : isDelete ? 'Delete' : 'Business Details'}</h2>
      <p>Name: <input type="text" value={name} onChange={(e) => setName(e.target.value)} disabled={!isUpdate} /></p>
      <p>Email: <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} disabled={!isUpdate} /></p>
      <p>Address: <input type="text" value={address} onChange={(e) => setAddress(e.target.value)} disabled={!isUpdate} /></p>

      {/* Conditionally render the buttons for Update and Delete */}
      {isUpdate && <button onClick={handleUpdate}>Update Business</button>}
      {isDelete && (
        <>
          <p>Are you sure you want to delete this business?</p>
          <button onClick={handleDelete}>Delete Business</button>
        </>
      )}
    </div>
  );
}

export default BusinessDetails;
