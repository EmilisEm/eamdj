import React from 'react';
import { Link, Outlet } from 'react-router-dom';

function ReservationPage() {
    return (
        <div>
            <h2>Reservation Management</h2>
            <nav>
                <ul>
                    <li><Link to="/reservation/create">Create Reservation</Link></li>
                    <li><Link to="/reservation/reservationlist">List Reservations</Link></li>
                </ul>
            </nav>
            <Outlet />
        </div>
    );
}

export default ReservationPage;
