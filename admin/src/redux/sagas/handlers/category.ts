import { call, put } from "@redux-saga/core/effects";
import axios from "axios";
import { setCatgories } from "src/redux/ducks/category";

export function* handleGetCategory(action) {
    try {
        const respone = yield call(requestGetCategory);
        yield put(setCatgories(respone.data));

    } catch (error) {
        console.log('getCatgories Error', error);
    }
}

function requestGetCategory() {
    return axios.get('https://localhost:5000/api/categories');
}
