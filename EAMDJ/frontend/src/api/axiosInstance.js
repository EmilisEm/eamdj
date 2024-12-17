import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:56552/',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add a request interceptor
axiosInstance.interceptors.request.use(
  (config) => {
    // You can modify the request before it is sent (e.g., add an Authorization header)
    const token = localStorage.getItem('authToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

// Add a response interceptor
axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      // Handle unauthorized responses (e.g., redirect to login)
    }
    return Promise.reject(error);
  }
);

export default axiosInstance;
