import { AxiosResponse } from "axios";
import { EndPoints } from "src/constants/configs";

import RequestService from 'src/services/request';
import ICategoryRequest from "src/interfaces/ICategoryRequest";

export function requestGetCategory(): Promise<AxiosResponse<any>> {
    return RequestService.axios.get(EndPoints.Categories);
}

export function requestCreateCategory(request: ICategoryRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });


    return RequestService.axios.post(EndPoints.Categories, formData);
}

export function requestGetCategoryById(id: string): Promise<AxiosResponse<any>> {
    return RequestService.axios.get(EndPoints.Category(id));
}

export function requestUpdateCategory(request: ICategoryRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();

    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return RequestService.axios.put(EndPoints.Category(request.categoryId!), formData);
}

export function requestDeleteCategory(id: string): Promise<AxiosResponse<any>> {
    return RequestService.axios.delete(EndPoints.Category(id));
}