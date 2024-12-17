import React, { useState, useContext } from 'react';
import { myContext } from '../../App';
import { createTax } from '../../api/tax';

const TaxForm = ({ onSuccess }) => {
  const { 
    currentBusiness, 
    businesses, 
    setCurrentBusiness 
  } = useContext(myContext);

  const [taxName, setTaxName] = useState('');
  const [percentage, setPercentage] = useState('');

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