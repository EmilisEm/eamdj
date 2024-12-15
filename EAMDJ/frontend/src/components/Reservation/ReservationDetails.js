import React from "react";

const ReservationDetails = ({ reservation }) => {
    if (!reservation) return <p>Select a reservation to see details.</p>;
    
    return (
        <div>
        <h2>Reservation Details</h2>
        <p>
            <strong>Reservation ID:</strong> {reservation.id}
        </p>
        <p>
            <strong>Reservation Date:</strong> {reservation.reservationDate}
        </p>
        <p>
            <strong>Reservation Time:</strong> {reservation.reservationTime}
        </p>
        <p>
            <strong>Reservation Status:</strong> {reservation.status}
        </p>
        </div>
    );
}

export default ReservationDetails;