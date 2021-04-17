import { call, put } from "@redux-saga/core/effects";

import { setProducts } from "src/redux/ducks/product";
import { requestGetProduct } from "../requests/product";

export function* handleGetProduct(action) {
    try {
        const respone = yield call(requestGetProduct);
        yield put(setProducts(respone.data));

    } catch (error) {
        console.log('get product Error', error);
    }
}
