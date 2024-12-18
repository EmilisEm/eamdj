import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { fetchReservationsByProduct } from '../../api/reservation';

function ReservationList() {
    const [productId, setProductId] = useState('');
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleFetchReservations = async () => {
        if (!productId) {
            setError('Please enter a valid Product ID.');
            return;
        }

        setLoading(true);
        setError(null);
        setReservations([]);

        try {
            const response = await fetchReservationsByProduct(productId);
            setReservations(response || []);
        } catch (err) {
            setError('Failed to fetch reservations. Please check the Product ID.');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Reservations</h2>
            <div>
                <label htmlFor="productId">Enter Product ID: </label>
                <input
                    type="text"
                    id="productId"
                    value={productId}
                    onChange={(e) => setProductId(e.target.value)}
                />
                <button onClick={handleFetchReservations} disabled={loading}>
                    {loading ? 'Fetching...' : 'Fetch Reservations'}
                </button>
            </div>

            {error && <div style={{ color: 'red' }}>{error}</div>}

            {loading ? (
                <div>Loading reservations...</div>
            ) : (
                <ul>
                    {reservations.length > 0 ? (
                        reservations.map((reservation) => (
                            <li key={reservation.id}>
                                <Link to={`/reservation/${reservation.id}`}>
                                    {`Service Time ID: ${reservation.serviceTimeId}, Employee ID: ${reservation.employeeId}`}
                                </Link>
                            </li>
                        ))
                    ) : (
                        <li>No reservations available for this product</li>
                    )}
                </ul>
            )}
        </div>
    );
}

export default ReservationList;
