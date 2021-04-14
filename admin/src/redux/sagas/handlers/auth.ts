import { call, put } from "@redux-saga/core/effects";

import { setAuthen, setUser } from "src/redux/ducks/auth";
import authService from "src/services/auth-service";

export function* handleGetUser(action) {
    try {
        const user = yield call(requestGetUser);
        yield put(setUser(user));
        
    } catch (error) {
        console.log('errr', error);
        yield put(setAuthen({ isAuth: false }));
    }
}

export function* handleCompleteLogin(action) {
    try {
        yield call(completeLogin);
        yield put(setAuthen({ isAuth: true}));
    } catch (error) {
        console.log(error);
    }
}

export function* handleLogin(action) {
    try {
        yield call(login);
    } catch (error) {
        console.log(error);
    }
}

function requestGetUser() {
    return authService.loginSilent();
}

function completeLogin() {
    return authService.completeLoginAsync(window.location.href);
}

function login() {
    return authService.loginAsync();
}
