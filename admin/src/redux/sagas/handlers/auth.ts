import { call, put } from "@redux-saga/core/effects";

import { setAuthen, setUser } from "src/redux/ducks/auth";
import { requestGetUser, completeLogin, loginRequest, logoutRequest, logoutCallBack } from "../requests/auth";

export function* handleGetUser(action) {
    try {        
        const userResponse = yield call(requestGetUser);

        if (userResponse) {
            const user = JSON.stringify(userResponse) as any;
            yield put(setUser(userResponse));
        } else {
            yield call(loginRequest);
        }

    } catch (error) {
        console.log('requestGetUser Error', error);
        yield put(setAuthen({ isAuth: false }));
    }
}

export function* handleCompleteLogin(action) {
    try {
        const userResponse = yield call(completeLogin);
        const user = JSON.stringify(userResponse) as any;
        
        yield put(setUser(userResponse));

    } catch (error) {
        console.log(error);
    }
}

export function* handleLogin(action) {
    try {
        yield call(loginRequest);

    } catch (error) {
        console.log(error);
    }
}

export function* handleLogout(action) {
    try {
        yield call(logoutRequest);

    } catch (error) {
        console.log(error);
    }
}

export function* handleLogoutCallBack(action) {
    try {
        yield call(logoutCallBack);
        
        yield put(setAuthen({ isAuth: false }));

    } catch (error) {
        console.log(error);
    }
}
