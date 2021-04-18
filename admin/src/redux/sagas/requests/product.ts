import axios, { AxiosResponse } from "axios";
import { EndPoints } from "src/constants/configs";

import IProductRequest from "src/interfaces/IProductRequest";

export function requestGetProduct() {
    return axios.get(EndPoints.Products);
}

export function requestCreateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.post(EndPoints.Products, formData);
}

export function requestGetProductById(id: string): Promise<AxiosResponse<any>> {
    return axios.get(EndPoints.Product(id));
}

export function requestUpdateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.put(EndPoints.Product(request.productId!), formData);
}

export function requestDeleteProduct(id: string): Promise<AxiosResponse<any>> {
    return axios.delete(EndPoints.Product(id));
}