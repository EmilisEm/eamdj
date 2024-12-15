// src/pages/BusinessPage.js
import React from 'react';
import { Link, Route, Routes } from 'react-router-dom';
import BusinessForm from '../components/Business/BusinessForm';
import BusinessList from '../components/Business/BusinessList';
import BusinessDetails from '../components/Business/BusinessDetails';

function BusinessPage() {
  return (
    <div>
      <h2>Business Management</h2>
      <nav>
        <ul>
          <li><Link to="/business/create">Create Business</Link></li>
          {/* Link to the Business List */}
          <li><Link to="/business/businesslist">List Businesses</Link></li>
        </ul>
      </nav>

      <Routes>
        <Route path="create" element={<BusinessForm onSuccess={() => {}} />} />
        <Route path="businesslist" element={<BusinessList />} />
        {/* Route to show details for specific business */}
        <Route path="business/:id" element={<BusinessDetails />} />
        {/* Update and Delete routes */}
        <Route path="update/:id" element={<BusinessDetails isUpdate={true} />} />
        <Route path="delete/:id" element={<BusinessDetails isDelete={true} />} />
      </Routes>
    </div>
  );
}

export default BusinessPage;
