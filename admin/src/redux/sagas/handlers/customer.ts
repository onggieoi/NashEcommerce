import { call, put } from "redux-saga/effects";

import { setCustomers } from "src/redux/ducks/customer";
import { requestGetCustomers } from "../requests/customer";

export function* handleGetCustomers() {
    try {
        const respone = yield call(requestGetCustomers);
        yield put(setCustomers(respone.data));
    } catch (error) {
        console.log('errors get customers', error);
    }
}
