import React, { useState } from 'react';
import { login } from '../api/user';
import { useNavigate } from 'react-router-dom';
function LoginPage() {
    const [username, setUsername] = useState('');
    const navigate = useNavigate();
    const loginUser = async (e) => {
        e.preventDefault();
        
        const response = await login(username);
        localStorage.setItem('authToken', response.token);
        alert("login successful");
        navigate();
    }
    return (
        <div>
            <h1>Login</h1>
            <form onSubmit={loginUser}>
                <label>Username: </label>
                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
                <input type="submit" value="Login" />
            </form>
        </div>
    );
}

export default LoginPage;
