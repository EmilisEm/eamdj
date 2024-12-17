import React, { useContext, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { myContext } from '../../App';
import { deleteBusiness, fetchBusinessById, updateBusiness } from '../../api/business';

function BusinessDetails({ isUpdate = false, isDelete = false }) {
  const { id } = useParams(); // Get business ID from the route
  const navigate = useNavigate();
  const {business, setBusiness} = useContext(myContext);

  // Fetch the business details when the component loads
  useEffect(() => {
    const getBusiness = async () => {
      try {
        setBusiness(await fetchBusinessById(id));
      } catch {
        navigate('/business/businesslist');
      }
    }

    getBusiness();
  }, [id, navigate, setBusiness]);

  // Handle the Update operation
  const handleUpdate = async () => {
    try {
      await updateBusiness(id, business);
    } catch {
      alert('Failed to update business');
      navigate('/business/businesslist')
    }
      alert('Business updated!');
  };

  // Handle the Delete operation
  const handleDelete = async () => {
    await deleteBusiness(id);
    navigate('/business/businesslist');
  };

  if (!business) return <div>Loading...</div>;

  return (
    <div>
      <h2>{isUpdate ? 'Update' : isDelete ? 'Delete' : 'Business Details'}</h2>
      <p>Name: <input type="text" value={business.name} onChange={(e) => setBusiness((business) => {return {...business, name: e.target.value }})} disabled={!isUpdate} /></p>
      <p>Email: <input type="email" value={business.email} onChange={(e) => setBusiness((business) => {return {...business, email: e.target.value }})} disabled={!isUpdate} /></p>
      <p>Address: <input type="text" value={business.address} onChange={(e) => setBusiness((business) => {return {...business, address: e.target.value }})} disabled={!isUpdate} /></p>

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
