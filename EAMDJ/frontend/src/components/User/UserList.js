import React, { useEffect, useState } from "react";
import { fetchUsers, deleteUser } from "../../api/user";
import UserListRow from "./UserListRow";
import UserListRowEdit from "./UserListRowEdit";
import UserCreate from "./UserCreate";

function UserList() {
	const [users, setUsers] = useState([]);
	const [editingId, setEditingId] = useState(null);
	const [creatingUser, setCreatingUser] = useState(false);

	useEffect(() => {
		const fetchData = async () => {
		  try {
			const data = await fetchUsers();
			setUsers(data);
		  } catch (error) {
			console.error(error);
		  }
		};
	  
		fetchData();
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
				<UserCreate onCreate={handleFinishCreate} onCancel={handleCancelCreate}/>
			)}
			<table>
				<thead>
					<tr>
                        <th>Id</th>
						<th>Username</th>
                        <th>Email</th>
						<th colSpan={2}>Legal name</th>
						<th>Type</th>
						<th>Business</th>
						<th colspan={2}>Actions</th>
					</tr>
				</thead>
				<tbody>
					{users.map((user) => (
						editingId === user.id ? (
							<UserListRowEdit key={user.id} user={user} onSave={handleSave} onCancel={handleCancel}/>
						) : (
							<UserListRow key={user.id} user={user} onEdit={() => handleEdit(user.id)} onDelete={() => handleDelete(user.id)}/>
						)
					))}
				</tbody>
			</table>
		</div>
	);
};

export default UserList;