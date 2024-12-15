import React, { useEffect, useState } from 'react';
import { fetchUsersByBusiness, deleteUser } from '../../api/user';
import LoadingSpinner from '../Shared/LoadingSpinner';

const UserList = ({ businessId }) => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadUsers = async () => {
            try {
                const data = await fetchUsersByBusiness(businessId);
                setUsers(data);
            } catch (error) {
                console.error(error);
            } finally {
                setLoading(false);
            }
        };

        loadUsers();
    }, [businessId]);

    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this user?')) {
            await deleteUser(id);
            setUsers(users.filter((user) => user.id !== id));
        }
    };

    if (loading) return <LoadingSpinner />;

    return (
        <div>
            <h1>Users</h1>
            <ul>
                {users.map((user) => (
                    <li key={user.id}>
                        <p>{user.email}</p>
                        <button onClick={() => handleDelete(user.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default UserList;