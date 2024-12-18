import axiosInstance from './axiosInstance';

export const fetchReservationsByProduct = async (productId) => {
    const response = await axiosInstance.get(`/api/v1/reservation/by-product/${productId}`);
    return response.data;
};

export const fetchReservation = async (id) => {
    const response = await axiosInstance.get(`/api/v1/reservation/${id}`);
    return response.data;
};


export const createReservation = async (data) => {
    const response = await axiosInstance.post('/api/v1/reservation', data);
    return response.data;
};

export const updateReservation = async (id, data) => {
    const response = await axiosInstance.put(`/api/v1/reservation/${id}`, data);
    return response.data;
};

export const deleteReservation = async (id) => {
    const response = await axiosInstance.delete(`/api/v1/reservation/delete/${id}`);
    return response.data;
};