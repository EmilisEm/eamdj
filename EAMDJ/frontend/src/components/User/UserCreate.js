import React, { useState } from "react";
import { createUser } from "../../api/user";
import { userType } from "../../api/userType";

function UserCreate({ onCreate, onCancel }) {
	const [user, setUser] = useState({
		username: "",
		password: "",
		firstName: "",
		lastName: "",
		email: "",
		userType: userType.admin,
		businessId: null,
	});

	const handleChange = (e) => {
		setUser((prevUser) => ({
			...prevUser,
			[e.target.name]: e.target.value,
		}));
	};

	const handleSubmit = async (e) => {
		e.preventDefault();
		try {
			const response = await createUser(user);
			onCreate(response);
		} catch (error) {
			console.error("Failed to create user");
		}
	};

	return (
		<form onSubmit={handleSubmit}>
			<label>
				Username:
				<input
					type="text"
					name="username"
					value={user.username}
					onChange={handleChange}
				/>
			</label>
			<label>
				Password:
				<input
					type="password"
					name="password"
					value={user.password}
					onChange={handleChange}
				/>
			</label>
			<label>
				Email:
				<input
					type="email"
					name="email"
					value={user.email}
					onChange={handleChange}
				/>
			</label>
			<label>
				First Name:
				<input
					type="text"
					name="firstName"
					value={user.firstName}
					onChange={handleChange}
				/>
			</label>
			<label>
				Last Name:
				<input
					type="text"
					name="lastName"
					value={user.lastName}
					onChange={handleChange}
				/>
			</label>
			<button type="submit">Create User</button>
			<button onClick={onCancel}>Cancel</button>
		</form>
	);
}

export default UserCreate;