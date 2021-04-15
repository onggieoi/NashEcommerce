import {takeLatest} from 'redux-saga/effects';

import { 
    getUser, login, loginCallBack, logout, logoutCallBack
} from '../ducks/auth';
import { 
    handleCompleteLogin, handleGetUser, handleLogin, handleLogout, handleLogoutCallBack 
} from './handlers/auth';

export function* watcherSaga() {
    yield takeLatest(getUser.type, handleGetUser);
    yield takeLatest(loginCallBack.type, handleCompleteLogin);
    yield takeLatest(login.type, handleLogin);
    yield takeLatest(logout.type, handleLogout);
    yield takeLatest(logoutCallBack.type, handleLogoutCallBack);
}