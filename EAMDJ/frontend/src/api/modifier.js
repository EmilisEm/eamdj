import axiosInstance from './axiosInstance';

const BASE_URL = '/api/v1/product-modifier';

export const fetchProductModifiers = async (productId) => {
    const response = await axiosInstance.get(`${BASE_URL}/by-product/${productId}`);
    return response.data; 
};

export const createModifier = async (modifier) => {
    const response = await axiosInstance.post(BASE_URL, modifier);
    return response.data;
};

export const updateModifier = async (id, modifier) => {
    const response = await axiosInstance.put(`${BASE_URL}/${id}`, modifier);
    return response.data;
};

export const deleteModifier = async (id) => {
    await axiosInstance.delete(`${BASE_URL}/delete/${id}`);
};
