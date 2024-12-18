import axiosInstance from './axiosInstance';

export const fetchBusinesses = async ({ page, pageSize }) => {
  const response = await axiosInstance.get(`/api/v1/business`, {
    params: { page, pageSize }
  });
  return response.data;
};

export const fetchBusinessById = async (id) => {
  try {
    const response = await axiosInstance.get(`/api/v1/business/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching business by ID:', error);
    throw error;
  }
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
