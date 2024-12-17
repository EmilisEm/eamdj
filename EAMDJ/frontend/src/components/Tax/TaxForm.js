import React, { useState, useContext, useEffect } from 'react';
import { myContext } from '../../App';
import { createTax } from '../../api/tax';
import { fetchBusinesses } from '../../api/business';

const TaxForm = ({ onSuccess }) => {
  const { 
    currentBusiness, 
    businesses, 
    setBusinesses, 
    setCurrentBusiness 
  } = useContext(myContext);

  const [taxName, setTaxName] = useState('');
  const [percentage, setPercentage] = useState('');

  useEffect(() => {
    const loadBusinesses = async () => {
      try {
        const page = 1; // Hardcoded page number
        const pageSize = 20; // Hardcoded page size

        const response = await fetchBusinesses(page, pageSize);
        const data = response.items; // Extract businesses array
        setBusinesses(data);
      } catch (error) {
        console.error('Failed to fetch businesses:', error);
      }
    };

    loadBusinesses();
  }, [setBusinesses]);

  const handleBusinessChange = (event) => {
    const selectedId = event.target.value;
    const selectedBusiness = businesses.find(business => business.id === selectedId);
    if (selectedBusiness) {
      setCurrentBusiness(selectedBusiness);
      console.log('Selected Business:', selectedBusiness);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    
    if (!currentBusiness || !currentBusiness.id) {
      alert('Please select a business first');
      return;
    }

    const taxCreateDto = {
      businessId: currentBusiness.id,
      name: taxName,
      percentage: parseFloat(percentage)
    };

    try {
      console.log('Sending Tax Create DTO:', taxCreateDto);

      const newTax = await createTax(taxCreateDto);

      console.log('Tax created successfully:', newTax);
      onSuccess(newTax);
      setTaxName('');
      setPercentage('');
    } catch (error) {
      console.error('Failed to create tax:', error);
      alert('An error occurred while creating the tax');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create New Tax</h2>

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
          Tax Name:
          <input
            type="text"
            value={taxName}
            onChange={(e) => setTaxName(e.target.value)}
          />
        </label>
      </div>

      <div>
        <label>
          Percentage:
          <input
            type="number"
            value={percentage}
            onChange={(e) => setPercentage(e.target.value)}
          />
        </label>
      </div>

      <button type="submit">Submit Tax</button>
    </form>
  );
};

export default TaxForm;
