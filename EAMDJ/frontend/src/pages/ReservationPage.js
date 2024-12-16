import React from "react";
import { Link, Route, Routes } from "react-router-dom";
import ReservationForm from "../components/Reservation/ReservationForm";
import ReservationList from "../components/Reservation/ReservationList";
import ReservationDetails from "../components/Reservation/ReservationDetails";

function ReservationPage() {
    return (
        <div>
        <h2>Reservation Management</h2>
        <nav>
            <ul>
            <li>
                <Link to="/create-reservation">Create Reservation</Link>
            </li>
            <li>
                <Link to="/reservations">List Reservations</Link>
            </li>
            </ul>
        </nav>
    
        <Routes>
            <Route
            path="create-reservation"
            element={<ReservationForm onSuccess={() => {}} />}
            />
            <Route path="reservations" element={<ReservationList />} />
            <Route path="reservation/:id" element={<ReservationDetails />} />
        </Routes>
        </div>
    );
}

export default ReservationPage;