import React, { useEffect, useState } from 'react';
import { fetchReservationsByBusiness, deleteReservation } from '../../api/reservation';
import LoadingSpinner from '../Shared/LoadingSpinner';

const ReservationList = ({ businessId }) => {
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        const loadReservations = async () => {
        try {
            const data = await fetchReservationsByBusiness(businessId);
            setReservations(data);
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
        };
    
        loadReservations();
    }, [businessId]);
    
    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this reservation?')) {
        await deleteReservation(id);
        setReservations(reservations.filter((reservation) => reservation.id !== id));
        }
    };
    
    if (loading) return <LoadingSpinner />;
    
    return (
        <div>
        <h1>Reservations</h1>
        <ul>
            {reservations.map((reservation) => (
            <li key={reservation.id}>
                <p>{reservation.date}</p>
                <button onClick={() => handleDelete(reservation.id)}>Delete</button>
            </li>
            ))}
        </ul>
        </div>
    );
}

export default ReservationList;