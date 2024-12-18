// src/components/service-time/ServiceTimeForm.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createServiceTime } from '../../api/servicetime';

function ServiceTimeForm({ onSuccess }) {
    const [serviceTime, setServiceTime] = useState({
        serviceId: '',
        start: '',
        end: '',
    });
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();
        setLoading(true);
        setError(null);

        try {
            await createServiceTime(serviceTime);
            onSuccess && onSuccess();
            navigate('/service-time/service-timelist');
        } catch (error) {
            setError(error.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Create Service Time</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Product ID:
                    <input
                        type="text"
                        value={serviceTime.serviceId}
                        onChange={(e) =>
                            setServiceTime({ ...serviceTime, serviceId: e.target.value })
                        }
                        required
                    />
                </label>
                <label>
                    Start Time:
                    <input
                        type="text"
                        value={serviceTime.start}
                        onChange={(e) =>
                            setServiceTime({ ...serviceTime, start: e.target.value })
                        }
                        required
                    />
                </label>
                <label>
                    End Time:
                    <input
                        type="text"
                        value={serviceTime.end}
                        onChange={(e) =>
                            setServiceTime({ ...serviceTime, end: e.target.value })
                        }
                        required
                    />
                </label>
                <button type="submit" disabled={loading}>
                    {loading ? 'Creating...' : 'Create Service Time'}
                </button>
            </form>
        </div>
    );
}

export default ServiceTimeForm;
