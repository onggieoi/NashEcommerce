import { call, put } from "@redux-saga/core/effects";
import { PayloadAction } from "@reduxjs/toolkit";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";

import ICategoryRequest from "src/interfaces/ICategoryRequest";
import { setCatgories, setCreateResult } from "src/redux/ducks/category";

export function* handleGetCategory(action) {
    try {
        const respone = yield call(requestGetCategory);
        yield put(setCatgories(respone.data));

    } catch (error) {
        console.log('getCatgories Error', error);
    }
}

export function* handleCreateCategory(action: PayloadAction<ICategoryRequest>) {
    const request = action.payload;

    try {
        const respone = yield call(requestCreateCategory, request);

        yield put(setCreateResult({
            isSuccess: true,
            category: respone.data
        }));
    } catch (error) {
        console.log('create category Error', error);
        yield put(setCreateResult({
            isSuccess: false,
        }));
    }
}

function requestGetCategory(): Promise<AxiosResponse<any>> {
    return axios.get('https://localhost:5000/api/categories');
}

function requestCreateCategory(request: ICategoryRequest): Promise<AxiosResponse<any>> {
    const formData = new FormData();
    
    Object.keys(request).forEach(key => {
        formData.append(key, request[key]);
    });

    return axios.post('https://localhost:5000/api/categories', formData);
}
