import { call, put } from "@redux-saga/core/effects";
import axios from "axios";

import { setProducts } from "src/redux/ducks/product";

export function* handleGetProduct(action) {
    try {
        const respone = yield call(requestGetProduct);
        yield put(setProducts(respone.data));

    } catch (error) {
        console.log('get product Error', error);
    }
}

function requestGetProduct() {
    return axios.get('https://localhost:5000/api/products');
}
