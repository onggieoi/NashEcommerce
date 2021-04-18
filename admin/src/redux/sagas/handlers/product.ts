import { call, put } from "@redux-saga/core/effects";
import { PayloadAction } from "@reduxjs/toolkit";
import IProductRequest from "src/interfaces/IProductRequest";

import { setProduct, setProductResult, setProducts } from "src/redux/ducks/product";
import { requestCreateProduct, requestDeleteProduct, requestGetProduct, requestGetProductById, requestUpdateProduct } from "../requests/product";

export function* handleGetProduct() {
    try {
        const respone = yield call(requestGetProduct);
        yield put(setProducts(respone.data));

    } catch (error) {
        console.log('get product Error', error);
    }
}

export function* handleCreateProduct(action: PayloadAction<IProductRequest>) {
    const request = action.payload;

    try {
        const respone = yield call(requestCreateProduct, request);

        yield put(setProductResult({
            isSuccess: true,
            product: respone.data
        }));
    } catch (error) {
        console.log('create product Error', error);
        yield put(setProductResult({
            isSuccess: false,
        }));
    }
}

export function* handleGetProductById(action: PayloadAction<string>) {
    const id = action.payload;

    try {
        const respone = yield call(requestGetProductById, id);

        yield put(setProduct(respone.data));
    } catch (error) {
        console.log('get product byId Error', error);

    }
}

export function* handleUpdateProduct(action: PayloadAction<IProductRequest>) {
    const request = action.payload;

    try {
        const respone = yield call(requestUpdateProduct, request);

        yield put(setProductResult({
            isSuccess: true,
            product: respone.data
        }));
    } catch (error) {
        console.log('updated product Error', error);
        yield put(setProductResult({
            isSuccess: false,
        }));
    }
}

export function* handleDeleteProduct(action: PayloadAction<string>) {
    const id = action.payload;

    try {
        const respone = yield call(requestDeleteProduct, id);

        yield put(setProductResult({
            isSuccess: true,
            product: respone.data,
        }));
    } catch (error) {
        console.log('delete product Error', error);
        yield put(setProductResult({
            isSuccess: false,
        }));
    }
}