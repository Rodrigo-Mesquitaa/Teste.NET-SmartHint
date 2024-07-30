import axios from 'axios';

const API_URL = 'https://localhost:5001/api/buyers'; // Ajuste a URL conforme necessário

export const getBuyers = async (page = 1, search = '') => {
    try {
        const response = await axios.get(`${API_URL}?page=${page}&search=${search}`);
        return response.data;
    } catch (error) {
        console.error('Erro ao buscar compradores:', error);
        throw error;
    }
};

export const getBuyerById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    } catch (error) {
        console.error('Erro ao buscar comprador:', error);
        throw error;
    }
};

export const createBuyer = async (buyer) => {
    try {
        const response = await axios.post(API_URL, buyer);
        return response.data;
    } catch (error) {
        console.error('Erro ao criar comprador:', error);
        throw error;
    }
};

export const updateBuyer = async (id, buyer) => {
    try {
        const response = await axios.put(`${API_URL}/${id}`, buyer);
        return response.data;
    } catch (error) {
        console.error('Erro ao atualizar comprador:', error);
        throw error;
    }
};
