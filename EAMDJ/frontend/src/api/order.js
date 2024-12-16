import axiosInstance from './axiosInstance';

export const fetchOrdersByBusiness = async (businessId) => {
  const response = await axiosInstance.get(`/api/v1/order/by-business/${businessId}`);
  return response.data;
};

export const createOrder = async (data) => {
  const response = await axiosInstance.post('/api/v1/order', data);
  return response.data;
};

export const updateOrder = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/order/${id}`, data);
  return response.data;
};

export const deleteOrder = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/order/delete/${id}`);
  return response.data;
};
