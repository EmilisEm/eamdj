// src/pages/ServiceTimePage.js
import React from 'react';
import { Link, Outlet } from 'react-router-dom';

function ServiceTimePage() {
    return (
        <div>
            <h2>Service Time Management</h2>
            <nav>
                <ul>
                    <li><Link to="/service-time/create">Create Service Time</Link></li>
                    <li><Link to="/service-time/service-timelist">List Service Times</Link></li>
                </ul>
            </nav>
            <Outlet />
        </div>
    );
}

export default ServiceTimePage;
