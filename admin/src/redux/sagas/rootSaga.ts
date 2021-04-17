import {takeLatest} from 'redux-saga/effects';

import { 
    getUser, login, loginCallBack, logout, logoutCallBack
} from '../ducks/auth';
import { 
    handleCompleteLogin, handleGetUser, handleLogin, handleLogout, handleLogoutCallBack 
} from './handlers/auth';

import { createCategory, getCatgories } from '../ducks/category';
import { handleCreateCategory, handleGetCategory } from './handlers/category';

import { getProducts } from '../ducks/product';
import { handleGetProduct } from './handlers/product';

export function* watcherSaga() {
    yield takeLatest(getUser.type, handleGetUser);
    yield takeLatest(loginCallBack.type, handleCompleteLogin);
    yield takeLatest(login.type, handleLogin);
    yield takeLatest(logout.type, handleLogout);
    yield takeLatest(logoutCallBack.type, handleLogoutCallBack);

    yield takeLatest(getCatgories.type, handleGetCategory);
    yield takeLatest(createCategory.type, handleCreateCategory);

    yield takeLatest(getProducts.type, handleGetProduct);
}