import React from "react";
import { getUserTypeName } from "../../api/userType";
import { Link } from "react-router-dom"

const BusinessUserListRow = ({user, onEdit, onDelete}) => {
    return (
        <tr>
            <th>{user.id}</th>
            <th>{user.username}</th>
            <th>{user.email}</th>
            <th>{user.firstName}</th>
            <th>{user.lastName}</th>
            <th>{getUserTypeName(user.userType)}</th>
            <th><button onClick={onEdit}>Edit</button></th>
            <th><button onClick={onDelete}>Delete</button></th>
        </tr>
    );
}

export default BusinessUserListRow;