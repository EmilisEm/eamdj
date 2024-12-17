import axiosInstance from './axiosInstance';

export const fetchTaxesByBusiness = async (businessId) => {
  const response = await axiosInstance.get(`/api/v1/tax/by-business/${businessId}`);
  return response.data;
};

export const fetchTax = async (taxId) => {
    const response = await axiosInstance.get(`/api/v1/tax/${taxId}`);
    return response.data;
};

export const createTax = async (data) => {
  const response = await axiosInstance.post('/api/v1/tax', data);
  return response.data;
};

export const updateTax = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/tax/${id}`, data);
  return response.data;
};

export const deleteTax = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/tax/delete/${id}`);
  return response.data;
};
