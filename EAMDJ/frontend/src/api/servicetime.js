import axiosInstance from './axiosInstance';

// Fetch service times by product ID
export const fetchServiceTimesByProduct = async (productId) => {
    const response = await axiosInstance.get(`/api/v1/service-time/by-product/${productId}`);
    return response.data;
};

// Fetch a single service time by ID
export const fetchServiceTime = async (id) => {
    const response = await axiosInstance.get(`/api/v1/service-time/${id}`);
    return response.data;
};

// Create a new service time
export const createServiceTime = async (data) => {
    const response = await axiosInstance.post('/api/v1/service-time', data);
    return response.data;
};

// Update an existing service time
export const updateServiceTime = async (id, data) => {
    const response = await axiosInstance.put(`/api/v1/service-time/${id}`, data);
    return response.data;
};

// Delete a service time by ID
export const deleteServiceTime = async (id) => {
    const response = await axiosInstance.delete(`/api/v1/service-time/delete/${id}`);
    return response.data;
};
