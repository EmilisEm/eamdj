import React, { useEffect, useContext, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { myContext } from '../../App';  // Your context
import { fetchBusinessById, updateBusiness, deleteBusiness } from '../../api/business';  // Import fetch, update and delete functions
import BusinessUserList from '../BusinessUser/BusinessUserList' 

function BusinessDetails() {
  const { id } = useParams();  // Get the ID from the URL
  const navigate = useNavigate();
  const { business, setBusiness } = useContext(myContext);  // Context for business data
  const [isUpdating, setIsUpdating] = useState(false);  // Track if the form is in update mode

  useEffect(() => {
    const getBusiness = async () => {
      try {
        const businessData = await fetchBusinessById(id);  // Fetch the business by ID
        setBusiness(businessData);  // Store the data in context
      } catch (error) {
        console.error('Failed to fetch business:', error);
        navigate('/business/businesslist');
      }
    };

    getBusiness();
  }, [id, navigate, setBusiness]);

  // Handle loading state and business details rendering
  if (!business) return <div>Loading...</div>;

  // Handle Update operation
  const handleUpdate = async () => {
    try {
      await updateBusiness(id, business);  // Update the business
      alert('Business updated!');
      navigate('/business/businesslist');  // Navigate back to the business list
    } catch (error) {
      console.error('Failed to update business:', error);
      alert('Failed to update business');
    }
  };

  // Handle Delete operation
  const handleDelete = async () => {
    const confirmation = window.confirm('Are you sure you want to delete this business?');
    if (confirmation) {
      try {
        await deleteBusiness(id);  // Delete the business
        alert('Business deleted!');
        navigate('/business/businesslist');  // Navigate back to the business list
      } catch (error) {
        console.error('Failed to delete business:', error);
        alert('Failed to delete business');
      }
    }
  };

  // Handle input change for updating business fields
  const handleChange = (field, value) => {
    setBusiness((prevBusiness) => ({
      ...prevBusiness,
      [field]: value
    }));
  };

  return (
    <div>
      <h2>Business Details</h2>
      <div>
        <p>Name: 
          <input 
            type="text" 
            value={business.name} 
            onChange={(e) => handleChange('name', e.target.value)} 
            disabled={!isUpdating}
          />
        </p>
        <p>Email: 
          <input 
            type="email" 
            value={business.email} 
            onChange={(e) => handleChange('email', e.target.value)} 
            disabled={!isUpdating}
          />
        </p>
        <p>Address: 
          <input 
            type="text" 
            value={business.address} 
            onChange={(e) => handleChange('address', e.target.value)} 
            disabled={!isUpdating}
          />
        </p>
      </div>

      {/* Show update and delete buttons */}
      <div>
        {isUpdating ? (
          <button onClick={handleUpdate}>Update Business</button>
        ) : (
          <button onClick={() => setIsUpdating(true)}>Edit</button>
        )}

        <button onClick={handleDelete} style={{ marginLeft: '10px' }}>Delete Business</button>
      </div>

      <div>
        <BusinessUserList businessId={id} />
      </div>
    </div>
  );
}

export default BusinessDetails;
