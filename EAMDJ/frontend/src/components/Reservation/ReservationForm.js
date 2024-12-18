import React, { useState } from 'react';
import { createReservation } from '../../api/reservation';
import { useNavigate } from 'react-router-dom';

function ReservationForm() {
    const [newReservation, setNewReservation] = useState({
        productId: '',
        serviceTimeId: '',
        employeeId: '',
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        try {
            await createReservation(newReservation);
            alert('Reservation created successfully!');
            navigate('/reservation/reservationlist');
        } catch (error) {
            setError('Failed to create reservation');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Create Reservation</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Product ID:
                    <input
                        value={newReservation.productId}
                        onChange={(e) => setNewReservation({ ...newReservation, productId: e.target.value })}
                    />
                </label>
                <label>
                    Service Time ID:
                    <input
                        value={newReservation.serviceTimeId}
                        onChange={(e) => setNewReservation({ ...newReservation, serviceTimeId: e.target.value })}
                    />
                </label>
                <label>
                    Employee ID:
                    <input
                        value={newReservation.employeeId}
                        onChange={(e) => setNewReservation({ ...newReservation, employeeId: e.target.value })}
                    />
                </label>
                <button type="submit" disabled={loading}>{loading ? 'Creating...' : 'Create Reservation'}</button>
            </form>
        </div>
    );
}

export default ReservationForm;
