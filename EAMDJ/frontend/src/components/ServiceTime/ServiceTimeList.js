// src/components/service-time/ServiceTimeList.js
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { fetchServiceTimesByProduct } from '../../api/servicetime'; // Adjust the API call name if needed

function ServiceTimeList() {
    const [serviceId, setServiceId] = useState('');
    const [serviceTimes, setServiceTimes] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleFetchServiceTimes = async () => {
        if (!serviceId) {
            setError('Please enter a valid Service ID.');
            return;
        }

        setLoading(true);
        setError(null);
        setServiceTimes([]);

        try {
            const response = await fetchServiceTimesByProduct(serviceId);
            setServiceTimes(response || []);
        } catch (err) {
            setError('Failed to fetch service times. Please check the Service ID.');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Service Times</h2>

            <div>
                <label htmlFor="serviceId">Enter Product ID: </label>
                <input
                    type="text"
                    id="serviceId"
                    value={serviceId}
                    onChange={(e) => setServiceId(e.target.value)}
                />
                <button onClick={handleFetchServiceTimes} disabled={loading}>
                    {loading ? 'Fetching...' : 'Fetch Service Times'}
                </button>
            </div>

            {error && <div style={{ color: 'red' }}>{error}</div>}

            {loading ? (
                <div>Loading service times...</div>
            ) : (
                <ul>
                    {serviceTimes.length > 0 ? (
                        serviceTimes.map((time) => (
                            <li key={time.id}>
                                <p>Start: {time.start}</p>
                                <p>End: {time.end}</p>
                                <Link to={`/service-time/${time.id}`}>Edit/Delete</Link>
                            </li>
                        ))
                    ) : (
                        <li>No service times available for this Service ID</li>
                    )}
                </ul>
            )}
        </div>
    );
}

export default ServiceTimeList;
