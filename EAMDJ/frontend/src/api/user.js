import axiosInstance from './axiosInstance';

export const fetchUsersByBusiness = async (businessId) => {
  const response = await axiosInstance.get(`/api/v1/user/by-business/${businessId}`);
  return response.data;
};

export const createUser = async (data) => {
  const response = await axiosInstance.post('/api/v1/user', data);
  return response.data;
};

export const updateUser = async (id, data) => {
  const response = await axiosInstance.put(`/api/v1/user/${id}`, data);
  return response.data;
};

export const deleteUser = async (id) => {
  const response = await axiosInstance.delete(`/api/v1/user/delete/${id}`);
  return response.data;
};

export const login = async (username) => {
  const response = await axiosInstance.post('api/auth/login', {username, password: "secret"});
  return response.data;
};

export const fetchUsers = async () => {
  const response = await axiosInstance.get('/api/v1/user/all');
  return response.data;
};
