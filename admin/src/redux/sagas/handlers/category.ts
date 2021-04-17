import { call, put } from "@redux-saga/core/effects";
import { PayloadAction } from "@reduxjs/toolkit";

import ICategoryRequest from "src/interfaces/ICategoryRequest";
import { setCategory, setCatgories, setCreateResult } from "src/redux/ducks/category";
import { requestGetCategory, requestCreateCategory, requestGetCategoryById, requestUpdateCategory, requestDeleteCategory } from "../requests/category";

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

export function* handleGetCategoryById(action: PayloadAction<string>) {
    const id = action.payload;

    try {
        const respone = yield call(requestGetCategoryById, id);

        yield put(setCategory(respone.data));
    } catch (error) {
        console.log('get category byId Error', error);

    }
}

export function* handleUpdateCategory(action: PayloadAction<ICategoryRequest>) {
    const request = action.payload;

    try {
        const respone = yield call(requestUpdateCategory, request);

        yield put(setCreateResult({
            isSuccess: true,
            category: respone.data
        }));
    } catch (error) {
        console.log('updated category Error', error);
        yield put(setCreateResult({
            isSuccess: false,
        }));
    }
}

export function* handleDeleteCategory(action: PayloadAction<string>) {
    const id = action.payload;

    try {
        const respone = yield call(requestDeleteCategory, id);

        yield put(setCreateResult({
            isSuccess: true,
            category: respone.data,
        }));
    } catch (error) {
        console.log('delete category Error', error);
        yield put(setCreateResult({
            isSuccess: false,
        }));
    }
}
