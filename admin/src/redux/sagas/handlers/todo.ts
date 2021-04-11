import { call, put } from "@redux-saga/core/effects";

import { setTodos } from "src/redux/ducks/todo";
import { requestGetTodos } from "../requests/todo";

export function* handleGetUser(action) {
    try {
        const respone = yield call(requestGetTodos);
        const data = yield respone.json();
        
        yield put(setTodos(data));

    } catch (error) {
        console.log(error);
    }
}