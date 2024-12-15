import axiosInstance from './axiosInstance';

export const fetchBusinesses = async () => {
  const response = await axiosInstance.get('/api/v1/business');
  return response.data;
};

export const createBusiness = async (data) => {
  const response = await axiosInstance.post('/api/v1/business', data);
  return response.data;
};

export const updateBusiness = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/business/${id}`, data);
  return response.data;
};

export const deleteBusiness = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/business/${id}`);
  return response.data;
};
