import axios, { AxiosResponse } from "axios";

import IProductRequest from "src/interfaces/IProductRequest";

export function requestGetProduct() {
    return axios.get('https://localhost:5000/api/products');
}

export function requestCreateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.post('https://localhost:5000/api/products', formData);
}

export function requestGetProductById(id: string): Promise<AxiosResponse<any>> {
    return axios.get(`https://localhost:5000/api/products/${id}`);
}

export function requestUpdateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.put(`https://localhost:5000/api/products/${request.productId}`, formData);
}

export function requestDeleteProduct(id: string): Promise<AxiosResponse<any>> {
    return axios.delete(`https://localhost:5000/api/products/${id}`);
}