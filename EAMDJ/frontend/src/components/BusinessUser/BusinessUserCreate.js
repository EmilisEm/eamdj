import React, { useState } from "react";
import { createUser } from "../../api/user";
import { userType } from "../../api/userType";

function BusinessUserCreate({ businessId, onCreate, onCancel }) {
	const [user, setUser] = useState({
		username: "",
		password: "",
		firstName: "",
		lastName: "",
		email: "",
		userType: userType.employee,
		businessId: businessId,
	});

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
			<label>
				User Type:
				<select
					name="userType"
					value={user.userType}
					onChange={handleSelectChange}
				>
					<option value={userType.businessOwner}>Business Owner</option>
					<option value={userType.employee}>Employee</option>
				</select>
			</label>
			<button type="submit">Create User</button>
			<button onClick={onCancel}>Cancel</button>
		</form>
	);
}

export default BusinessUserCreate;