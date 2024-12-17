// src/components/Business/BusinessList.js
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { fetchBusinesses } from '../../api/business';

function BusinessList() {
  const [businesses, setBusinesses] = useState([]);

  useEffect(() => {
    const getBusinesses = async () => setBusinesses(await fetchBusinesses());
    
    getBusinesses();
  }, []);

  return (
    <div>
      <h2>Businesses</h2>
      <ul>
        {businesses.map((business) => (
          <li key={business.id}>
            <Link to={`/business/${business.id}`}>{business.name}</Link>
            <Link to={`/business/update/${business.id}`} style={{ marginLeft: '10px' }}>
              Update
            </Link>
            <Link to={`/business/delete/${business.id}`} style={{ marginLeft: '10px' }}>
              Delete
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default BusinessList;