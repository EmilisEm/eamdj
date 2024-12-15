import axiosInstance from './axiosInstance';

export const fetchCategoriesByBusiness = async (businessId) => {
  const response = await axiosInstance.get(`/api/v1/category/by-business/${businessId}`);
  return response.data;
};

export const createCategory = async (data) => {
  const response = await axiosInstance.post('/api/v1/category', data);
  return response.data;
};

export const updateCategory = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/category/${id}`, data);
  return response.data;
};

export const deleteCategory = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/category/delete/${id}`);
  return response.data;
};
