import React, { useState } from "react";
import { Link } from "react-router-dom";
import { userType } from "../../api/userType";
import { updateUser } from "../../api/user";

const UserListRowEdit = ({user, onSave, onCancel}) => {
    const [userData, setUser] = useState({...user});
    const handleChange = (e) => {
        setUser((prevUser) => ({
            ...prevUser,
            [e.target.name]: e.target.value,
        }));
    };

    const handleSelectChange = (e) => {
		setUser((prevUser) => ({
			...prevUser,
			[e.target.name]: Number(e.target.value),
		}));
	}

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await updateUser(userData.id, userData);
            onSave(userData);
        } catch (error) {
            console.error("Failed to edit user");
        }
    };

    return (
        <tr>
            <th>{userData.id}</th>
            <th>
                <input
                    type="text"
                    name="username"
                    value={userData.username}
                    onChange={handleChange}
                />
            </th>
            <th>
                <input
                    type="email"
                    name="email"
                    value={userData.email}
                    onChange={handleChange}
                />
            </th>
            <th>
                <input
                    type="text"
                    name="firstName"
                    value={userData.firstName}
                    onChange={handleChange}
                />
            </th>
            <th>
                <input
                    type="text"
                    name="lastName"
                    value={userData.lastName}
                    onChange={handleChange}
                />
            </th>
            <th>
                <select
                    name="userType"
                    value={userData.userType}
                    onChange={handleSelectChange}
                >
                    <option value={userType.businessOwner}>BusinessOwner</option>
                    <option value={userType.employee}>Employee</option>
                </select>
            </th>
            <th>
                <button onClick={handleSubmit}>Save</button>
            </th>
            <th>
                <button onClick={onCancel}>Cancel</button> 
            </th>
        </tr>
    );
}

export default UserListRowEdit;