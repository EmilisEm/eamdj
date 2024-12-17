import axiosInstance from './axiosInstance';

export const fetchOrdersByBusiness = async (businessId) => {
  const response = await axiosInstance.get(`https://localhost:8081/api/v1/order/by-business/${businessId}`);
  return response.data;
};

export const createOrder = async (data) => {
  const response = await axiosInstance.post('https://localhost:8081/api/v1/order', data);
  return response.data;
};

export const updateOrder = async (id, data) => {
  const response = await axiosInstance.put(`https://localhost:8081/api/v1/order/${id}`, data);
  return response.data;
};

export const deleteOrder = async (id) => {
  const response = await axiosInstance.delete(`https://localhost:8081/api/v1/order/delete/${id}`);
  return response.data;
};
