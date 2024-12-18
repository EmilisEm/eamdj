// src/components/service-time/ServiceTimeDetails.js
import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import {
    fetchServiceTime,
    updateServiceTime,
    deleteServiceTime,
} from '../../api/servicetime';

function ServiceTimeDetails() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [serviceTime, setServiceTime] = useState(null);
    const [isEditing, setIsEditing] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        const getServiceTime = async () => {
            try {
                const data = await fetchServiceTime(id);
                setServiceTime(data);
            } catch (err) {
                console.error('Failed to fetch service time:', err);
                setError('Failed to load service time.');
            }
        };

        getServiceTime();
    }, [id]);

    const handleUpdate = async () => {
        try {
            await updateServiceTime(id, serviceTime);
            alert('Service time updated!');
            navigate('/service-time/service-timelist');
        } catch (err) {
            console.error('Failed to update service time:', err);
            alert('Failed to update service time.');
        }
    };

    const handleDelete = async () => {
        if (window.confirm('Are you sure you want to delete this service time?')) {
            try {
                await deleteServiceTime(id);
                alert('Service time deleted!');
                navigate('/service-time/service-timelist');
            } catch (err) {
                console.error('Failed to delete service time:', err);
                alert('Failed to delete service time.');
            }
        }
    };

    const handleChange = (field, value) => {
        setServiceTime((prev) => ({ ...prev, [field]: value }));
    };

    if (!serviceTime) return <div>Loading...</div>;

    return (
        <div>
            <h2>Service Time Details</h2>
            {error && <div style={{ color: 'red' }}>{error}</div>}

            <p>
                Product ID:{' '}
                <input
                    value={serviceTime.serviceId}
                    onChange={(e) => handleChange('serviceId', e.target.value)}
                    disabled={!isEditing}
                />
            </p>
            <p>
                Start:{' '}
                <input
                    value={serviceTime.start}
                    onChange={(e) => handleChange('start', e.target.value)}
                    disabled={!isEditing}
                />
            </p>
            <p>
                End:{' '}
                <input
                    value={serviceTime.end}
                    onChange={(e) => handleChange('end', e.target.value)}
                    disabled={!isEditing}
                />
            </p>

            {isEditing ? (
                <button onClick={handleUpdate}>Save</button>
            ) : (
                <button onClick={() => setIsEditing(true)}>Edit</button>
            )}
            <button onClick={handleDelete}>Delete</button>
        </div>
    );
}

export default ServiceTimeDetails;
