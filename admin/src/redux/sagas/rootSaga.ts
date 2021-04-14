import {takeEvery, takeLatest} from 'redux-saga/effects';

import { getUser, login, loginCallBack } from '../ducks/auth';
import { handleCompleteLogin, handleGetUser, handleLogin } from './handlers/auth';

export function* watcherSaga() {
    yield takeLatest(getUser.type, handleGetUser);
    yield takeLatest(loginCallBack.type, handleCompleteLogin);
    yield takeLatest(login.type, handleLogin);
}