import { call, put } from "@redux-saga/core/effects";

import { setAuthen, setUser } from "src/redux/ducks/auth";
import authService from "src/services/auth-service";

export function* handleGetUser(action) {
    try {
        const userResponse = yield call(requestGetUser);

        if (userResponse) {
            const user = JSON.stringify(userResponse);
            yield put(setUser(user));
        } else {
            yield call(login);
        }

    } catch (error) {
        yield put(setAuthen({ isAuth: false }));
    }
}

export function* handleCompleteLogin(action) {
    try {
        yield call(completeLogin);
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

export function* handleLogout(action) {
    try {
        yield call(logout);

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

function requestGetUser() {
    return authService.getUserAsync();
}

function completeLogin() {
    return authService.completeLoginAsync(window.location.href);
}

function login() {
    return authService.loginAsync();
}

function logout() {
    return authService.logoutAsync();
}

function logoutCallBack() {
    return authService.completeLogoutAsync(window.location.href);
}
