import { AxiosResponse } from "axios";

import { EndPoints } from "src/constants/configs";
import RequestService from 'src/services/request';
import IProductRequest from "src/interfaces/IProductRequest";

export function requestGetProduct() {
    return RequestService.axios.get(EndPoints.Products);
}

export function requestCreateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return RequestService.axios.post(EndPoints.Products, formData);
}

export function requestGetProductById(id: string): Promise<AxiosResponse<any>> {
    return RequestService.axios.get(EndPoints.Product(id));
}

export function requestUpdateProduct(request: IProductRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return RequestService.axios.put(EndPoints.Product(request.productId!), formData);
}

export function requestDeleteProduct(id: string): Promise<AxiosResponse<any>> {
    return RequestService.axios.delete(EndPoints.Product(id));
}