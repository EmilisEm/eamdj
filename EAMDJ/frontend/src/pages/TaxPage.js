import React, { useState } from 'react';
import TaxForm from '../components/Tax/TaxForm';
import TaxList from '../components/Tax/TaxList';

const TaxPage = () => {
  const [selectedTax, setSelectedTax] = useState(null);

  const handleTaxCreated = (newTax) => {
    // Optionally handle new order creation logic
    setSelectedTax(newTax);
  };

  return (
    <div>
      <h1>Tax Management</h1>
      
      <div style={{ display: 'flex' }}>
        <div style={{ flex: 1, marginRight: '20px' }}>
          <TaxForm onSuccess={handleTaxCreated} />
        </div>
        
        <div style={{ flex: 1, marginRight: '20px' }}>
          <TaxList onTaxSelect={setSelectedTax} />
        </div>
      </div>
    </div>
  );
};

export default TaxPage;