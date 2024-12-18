// src/pages/ProductPage.js
import React from 'react';
import { Link, Outlet } from 'react-router-dom';

function ProductPage() {
    return (
        <div>
            <h2>Product Management</h2>
            <nav>
                <ul>
                    <li><Link to="/product/create">Create Product</Link></li>
                    <li><Link to="/product/productlist">List Products</Link></li>
                </ul>
            </nav>
            <Outlet />
        </div>
    );
}

export default ProductPage;
