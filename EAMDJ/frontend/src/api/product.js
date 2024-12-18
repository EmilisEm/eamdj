import axiosInstance from './axiosInstance';

export const fetchProductsByCategory = async (categoryId) => {
  const response = await axiosInstance.get(`/api/v1/product/by-product-category/${categoryId}`);
  return response.data;
};

export const fetchProductById = async (id) => {
    const response = await axiosInstance.get(`/api/v1/product/${id}`);
    return response.data;
};

export const createProduct = async (data) => {
  const response = await axiosInstance.post('/api/v1/product', data);
  return response.data;
};

export const updateProduct = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/product/${id}`, data);
  return response.data;
};

export const deleteProduct = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/product/delete/${id}`);
  return response.data;
};
