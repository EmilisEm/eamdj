import React, { useState, useEffect, useContext } from 'react';
import { myContext } from '../../App';
import { fetchTaxesByBusiness } from '../../api/tax';

const TaxList = ({ onTaxSelect }) => {
  const { currentBusiness, setCurrentTaxes } = useContext(myContext);
  const [taxes, setTaxes] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchTaxes = async () => {
      if (!currentBusiness || !currentBusiness.id) return;

      setIsLoading(true);
      try {
        const taxData = await fetchTaxesByBusiness(currentBusiness.id);
        
        setTaxes(taxData);
        setCurrentTaxes(taxData);
      } catch (error) {
        console.error('Error fetching taxes:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchTaxes();
  }, [currentBusiness]);

  if (isLoading) return <div>Loading taxes...</div>;

  return (
    <div>
      <h2>Taxes for {currentBusiness.name}</h2>
      {taxes.length === 0 ? (
        <p>No taxes found</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Tax ID</th>
              <th>Name</th>
              <th>Percentage</th>
              <th>Business ID</th>
            </tr>
          </thead>
          <tbody>
            {taxes.map(tax => (
              <tr key={tax.id}>
                <td>{tax.id}</td>
                <td>{tax.name}</td>
                <td>{tax.percentage}%</td>
                <td>{tax.businessId}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default TaxList;