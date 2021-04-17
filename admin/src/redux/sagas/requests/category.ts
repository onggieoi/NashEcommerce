import axios, { AxiosResponse } from "axios";

import ICategoryRequest from "src/interfaces/ICategoryRequest";

export function requestGetCategory(): Promise<AxiosResponse<any>> {
    return axios.get('https://localhost:5000/api/categories');
}

export function requestCreateCategory(request: ICategoryRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.post('https://localhost:5000/api/categories', formData);
}

export function requestGetCategoryById(id: string): Promise<AxiosResponse<any>> {
    return axios.get(`https://localhost:5000/api/categories/${id}`);
}

export function requestUpdateCategory(request: ICategoryRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.put(`https://localhost:5000/api/categories/${request.categoryId}`, formData);
}

export function requestDeleteCategory(id: string): Promise<AxiosResponse<any>> {
    return axios.delete(`https://localhost:5000/api/categories/${id}`);
}