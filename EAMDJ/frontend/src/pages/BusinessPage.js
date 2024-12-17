// src/pages/BusinessPage.js
import React from 'react';
import { Link, Outlet } from 'react-router-dom';

function BusinessPage() {
  return (
    <div>
      <h2>Business Management</h2>
      <nav>
        <ul>
          <li><Link to="/business/create">Create Business</Link></li>
          <li><Link to="/business/businesslist">List Businesses</Link></li>
        </ul>
      </nav>
    <Outlet />
    </div>
  );
}

export default BusinessPage;
