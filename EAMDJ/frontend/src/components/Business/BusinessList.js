import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { fetchBusinesses } from '../../api/business';

function BusinessList() {
  const [businesses, setBusinesses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getBusinesses = async () => {
      try {
        const response = await fetchBusinesses({ page: 1, pageSize: 20 });
        setBusinesses(response.items);
      } catch (err) {
        setError('Failed to fetch businesses');
        console.error(err);
      } finally {
        setLoading(false);
      }
    };
    
    getBusinesses();
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>{error}</div>;

  return (
    <div>
      <h2>Businesses</h2>
      <ul>
        {businesses.length > 0 ? (
          businesses.map((business) => (
            <li key={business.id}>
              <Link to={`/business/${business.id}`}>{business.name}</Link>
            </li>
          ))
        ) : (
          <li>No businesses available</li>
        )}
      </ul>
    </div>
  );
}

export default BusinessList;