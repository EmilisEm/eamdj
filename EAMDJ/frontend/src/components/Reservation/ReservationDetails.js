import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchReservation, updateReservation, deleteReservation } from '../../api/reservation';

function ReservationDetails() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [reservation, setReservation] = useState(null);
    const [isEditing, setIsEditing] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        if (!id) {
            console.error('Reservation ID is missing');
            navigate('/reservation/reservationlist');
            return;
        }

        const getReservation = async () => {
            try {
                const data = await fetchReservation(id);
                // Extract serviceTimeId from nested serviceTime object
                setReservation({
                    ...data,
                    serviceTimeId: data.serviceTime?.id || '', // Handle cases where serviceTime might be missing
                });
            } catch (err) {
                console.error('Failed to fetch reservation:', err);
                setError('Failed to load reservation');
            }
        };

        getReservation();
    }, [id, navigate]);

    const handleUpdate = async () => {
        try {
            const updatedData = {
                ...reservation,
                serviceTime: { id: reservation.serviceTimeId }, // Re-nest serviceTimeId as serviceTime object
            };
            delete updatedData.serviceTimeId; // Remove serviceTimeId to avoid conflicts
            await updateReservation(id, updatedData);
            alert('Reservation updated successfully!');
            navigate('/reservation/reservationlist');
        } catch (err) {
            console.error('Failed to update reservation:', err);
            setError('Failed to update reservation');
        }
    };

    const handleDelete = async () => {
        if (window.confirm('Are you sure you want to delete this reservation?')) {
            try {
                await deleteReservation(id);
                alert('Reservation deleted successfully!');
                navigate('/reservation/reservationlist');
            } catch (err) {
                console.error('Failed to delete reservation:', err);
                setError('Failed to delete reservation');
            }
        }
    };

    const handleChange = (field, value) => {
        setReservation((prev) => ({ ...prev, [field]: value }));
    };

    if (!reservation) return <div>Loading...</div>;
    if (error) return <div style={{ color: 'red' }}>{error}</div>;

    return (
        <div>
            <h2>Reservation Details</h2>

            <div>
                <label>Product ID:</label>
                <input
                    type="text"
                    value={reservation.productId}
                    onChange={(e) => handleChange('productId', e.target.value)}
                    disabled
                />
            </div>
            <div>
                <label>Service Time ID:</label>
                <input
                    type="text"
                    value={reservation.serviceTimeId}
                    onChange={(e) => handleChange('serviceTimeId', e.target.value)}
                    disabled={!isEditing}
                />
            </div>
            <div>
                <label>Employee ID:</label>
                <input
                    type="text"
                    value={reservation.employeeId}
                    onChange={(e) => handleChange('employeeId', e.target.value)}
                    disabled={!isEditing}
                />
            </div>

            {isEditing ? (
                <button onClick={handleUpdate}>Save</button>
            ) : (
                <button onClick={() => setIsEditing(true)}>Edit</button>
            )}
            <button onClick={handleDelete}>Delete</button>
        </div>
    );
}

export default ReservationDetails;
