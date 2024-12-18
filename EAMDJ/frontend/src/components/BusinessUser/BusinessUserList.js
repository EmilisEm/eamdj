import React, { useEffect, useState } from "react";
import { fetchUsersByBusiness, deleteUser } from "../../api/user";
import BusinessUserListRow from "../BusinessUser/BusinessUserListRow";
import BusinessUserListRowEdit from "../BusinessUser/BusinessUserListRowEdit";
import BusinessUserCreate from "../BusinessUser/BusinessUserCreate";

const BusinessUserList = ({businessId}) => {
	const [users, setUsers] = useState([]);
	const [editingId, setEditingId] = useState(null);
	const [creatingUser, setCreatingUser] = useState(false);

	useEffect(async () => {
		try {
			const data = await fetchUsersByBusiness(businessId);
			setUsers(data);
		} catch (error) {
			console.error(error);
		}
	}, []);

	const handleDelete = async (id) => {
		if (window.confirm("Are you sure you want to delete this user?")) {
			await deleteUser(id);
			setUsers(users.filter((user) => user.id !== id));
		}
	};

	const handleEdit = async (id) => {
		setEditingId(id);
	};

	const handleCancel = () => {
		setEditingId(null);
	};

	const handleSave = (updatedElement) => {
		//Update the element in the state
		setUsers(users.map(el => (el.id === updatedElement.id ? updatedElement : el)));
		setEditingId(null);
	};

	const handleStartCreate = () => {
		setCreatingUser(true);
	}

	const handleCancelCreate = () => {
		setCreatingUser(false);
	}

	const handleFinishCreate = (user) => {
		setCreatingUser(false);
		users.push(user);
	}

	return (
		<div>
			<h2>Users</h2>
			{creatingUser === false ? (
				<button onClick={handleStartCreate}>Create user</button>
			) : (
				<BusinessUserCreate businessId={businessId} onCreate={handleFinishCreate} onCancel={handleCancelCreate}/>
			)}
			<table>
				<thead>
					<tr>
                        <th>Id</th>
						<th>Username</th>
                        <th>Email</th>
						<th colSpan={2}>Legal name</th>
						<th>Type</th>
						<th colspan={2}>Actions</th>
					</tr>
				</thead>
				<tbody>
					{users.map((user) => (
						editingId === user.id ? (
							<BusinessUserListRowEdit key={user.id} user={user} onSave={handleSave} onCancel={handleCancel}/>
						) : (
							<BusinessUserListRow key={user.id} user={user} onEdit={() => handleEdit(user.id)} onDelete={() => handleDelete(user.id)}/>
						)
					))}
				</tbody>
			</table>
		</div>
	);
};

export default BusinessUserList;